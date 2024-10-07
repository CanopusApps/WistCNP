using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using CalSystem2._0.DataContext;
using CalSystem2._0.Entities;
using CalSystem2._0.Models.CommonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Text;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using static CalSystem2._0.Models.PmDetailsModel.PmDataModel;

namespace CalSystem2._0.Concrete.Services.BaseDataServices
{
    public class CalCheckListServices : ICalCheckListServices
    {
        private readonly ApplicationDbContext _context;

        public CalCheckListServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> AddOrUpdateCalCheckList(CalChecklistModel model)
        {
            if (!DateTime.TryParse(model.PubDate, out DateTime publishDate))
            {
                return new ApiResponse(400, "Invalid Publish Date.");
            }

            var existingCalList = await _context.Calchecklists
                .FirstOrDefaultAsync(x => x.Assetag.Equals(model.Name) || x.Id == model.Id);

            var calListToUpdate = existingCalList ?? new Calchecklist
            {
                Id = Guid.NewGuid().ToString(),
                Createdate = DateTime.Now,
            };

            calListToUpdate.Assetag = model.Name;
            calListToUpdate.Cycletime = model.Cycle;
            calListToUpdate.Auditlevel = model.Criteria;
            calListToUpdate.Memo = model.Remarks;
            calListToUpdate.Publishdate = publishDate;
            calListToUpdate.Auditor = model.Approver;
            calListToUpdate.Status = model.Status switch
            {
                2 => "N",
                1 => "Y",
                _ => "O"
            };

            if (existingCalList == null)
            {
                _context.Calchecklists.Add(calListToUpdate);
            }
            else
            {
                _context.Calchecklists.Update(calListToUpdate);
            }

            try
            {
                await _context.SaveChangesAsync();
                return new ApiResponse(200, existingCalList == null ? "Calchecklist Item Added Successfully" : "Calchecklist Item Updated Successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, "An error occurred: " + ex.Message);
            }
        }



        public async Task<ServiceResponses<List<GetCalChecklistModel>>> GetAllCheckList(CheckListFilter filter,bool isCalOff)
        {
            try
            {
                filter ??= new CheckListFilter();

                var query = _context.Calchecklists.AsQueryable();

                if (!string.IsNullOrEmpty(filter.SearchName))
                {
                    query = query.Where(p => EF.Functions.Like(p.Assetag, $"%{filter.SearchName}%"));
                }

                if (!string.IsNullOrEmpty(filter.CalCycle))
                {
                    query = query.Where(p => p.Cycletime == filter.CalCycle);
                }

                if (DateTime.TryParse(filter.PubDate, out var parsedDate))
                {
                    query = query.Where(p => p.Publishdate.Date == parsedDate.Date);
                }

                if (!string.IsNullOrEmpty(filter.Criteria))
                {
                    query = query.Where(p => p.Auditlevel.Equals(filter.Criteria));
                }
                if (isCalOff)
                {
                    var statues = "O";
                    query=query.Where(p=>p.Status.Equals(statues));
                }
                else { 
                if (!string.IsNullOrEmpty(filter.Status))
                {
                    var status = filter.Status == "1" ? "Y" : filter.Status == "2" ? "N" : "O";
                    query = query.Where(p => p.Status == status);
                }
                }

                var totalRecords = await query.CountAsync();

                var pagedChecklists = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .Select(x => new GetCalChecklistModel
                    {
                        Id = x.Id,
                        SerialNo = x.Seq,
                        Name = x.Assetag,
                        Cycle = x.Cycletime,
                        Status = x.Status.Equals("Y")?1: x.Status.Equals("N") ? 2:0,
                        Criteria = x.Auditlevel,
                        PubDate = DateOnly.FromDateTime(x.Publishdate).ToString(),
                        Remarks = x.Memo,
                        Approver = x.Auditor,
                        Comments = x.ApproveMsg
                    })
                    .ToListAsync();

                return new ServiceResponses<List<GetCalChecklistModel>>(pagedChecklists.Any() ? 200 :401,
                    pagedChecklists.Any() ? "Data retrieved successfully." : "No data found.",
                    pagedChecklists)
                {
                    TotalCount = totalRecords,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponses<List<GetCalChecklistModel>>(500, $"An error occurred: {ex.Message}", null);
            }
        }


        public async Task<ApiResponse> DeleteCalListdata(IdModel model)
        {
            try
            {
                var result = await _context.Calchecklists.FirstOrDefaultAsync(c => c.Id.ToUpper().Equals(model.Id.ToUpper()));
                if (result != null)
                {
                    _context.Calchecklists.Remove(result);
                    _context.SaveChanges();
                    return new(200, "CalCheckList Item Deleted SucessFully");
                }
                else
                {
                    return new(400, "CalCheckList Id not not exist");
                }
            }
            catch (Exception ex)
            {
                return new(500, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<String>> GenerateCsv([FromBody] CalChecklistRequest checklists)
        {
            if (checklists == null || !checklists.Data.Any())
            {
                return new(400,"No data provided.", "No data provided");
            }

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Name,Approver,Cycle,PubDate,Criteria,Status,Remarks,SerialNo,Comments"); // Header

            foreach (var checklist in checklists.Data)
            {
                csvBuilder.AppendLine($"{checklist.Id},{checklist.Name},{checklist.Approver},{checklist.Cycle}," +
                    $"{checklist.PubDate},{checklist.Criteria},{checklist.Status},{checklist.Remarks}," +
                    $"{checklist.SerialNo},{checklist.Comments}");
            }

            var csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var base64Csv = Convert.ToBase64String(csvBytes);

            return new(200, "CSV File Created SucessFully", base64Csv);
        }

        public async Task<ApiResponse> RejectOrApproveCalCheckList(ApproveModel model)
        {
            foreach (var id in model.Id)
            { 
                var result = await _context.Calchecklists.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (result != null)
                {
                    result.Status = model.IsApprove ? "Y" : "N";
                    result.ApproveMsg =model.Comment;
                     _context.Update (result);
                }

                await _context.SaveChangesAsync();
            }
            return new ApiResponse(200,model.IsApprove ? "Accepted Successfully" : "Rejected Successfully");
        }

        //public async Task<ServiceResponse<GetCalChecklistModel>> GetCalChecklistByAssetId(string assetId)
        //{

        //}

    }
}
