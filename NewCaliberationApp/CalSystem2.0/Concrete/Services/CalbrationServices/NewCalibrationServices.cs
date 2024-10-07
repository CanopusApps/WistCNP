using CalSystem2._0.Concrete.IServices.ICalbrationServices;
using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.Concrete.Services.PMServices;
using CalSystem2._0.DataContext;
using CalSystem2._0.Entities;
using CalSystem2._0.Models.CalibrationModel;
using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.Services.CalbrationServices
{
    public class NewCalibrationServices : INewCalibrationServices
    {
        private readonly ApplicationDbContext _context;
        ICurrentUserServices _currentUserServices;

        public NewCalibrationServices(ApplicationDbContext context, ICurrentUserServices currentUserServices)
        {
            _context = context;
            _currentUserServices = currentUserServices;
        }

        public async Task<ServiceResponse<List<DropDownModel>>> ModelDDL()
        {
            var result = await _context.Calmodels.Select(
                x => new DropDownModel
                {
                    Id = x.Id,
                    Data = x.Model
                }).ToListAsync();
            return new(200, "Data Featched", result);
        }

        public async Task<ServiceResponse<CalModelDetails>> GetCalModelDetail(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new(400, "Model name cannot be null or empty.", null);
            }

            try
            {
                var result = await _context.Calmodels
                    .Where(x => x.Model.Equals(name))
                    .Select(x => new CalModelDetails
                    {
                        Attribute = x.Attribute,
                        CalPeriod = x.Cycle,
                        CalDept = x.Caldepartment,
                        Name = x.Chinesedesc,
                        Brand = x.Brand,
                    }).FirstOrDefaultAsync();

                if (result != null)
                {
                    result.LastCalDate = DateOnly.FromDateTime(DateTime.Now);
                    result.NextCalDate = await CalculateNextCalDate(result.CalPeriod, result.LastCalDate);
                }

                return new ServiceResponse<CalModelDetails> { Data = result };
            }
            catch (Exception ex)
            {
                return new (500,$"An error occurred: {ex.Message}",null);
            };
        }

        public async Task<DateOnly?> CalculateNextCalDate(string calPeriod, DateOnly lastCalDate)
        {
            if (string.IsNullOrWhiteSpace(calPeriod))
            {
                return null;
            }

            var match = System.Text.RegularExpressions.Regex.Match(calPeriod, @"(\d+)([A-Za-z]+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int quantity))
            {
                string unit = match.Groups[2].Value.ToUpper();
                return unit switch
                {
                    "MONTH" or "MONTHS" => lastCalDate.AddMonths(quantity),
                    "WEEK" or "WEEKS" => lastCalDate.AddDays(quantity * 7),
                    _ => null,
                };
            }

            return null;
        }


        public async Task<ApiResponse> AddorUpdateNewCalibration(CalibrationDataModel model)
        {
            try
            { 
                var result = await _context.Calmains.FirstOrDefaultAsync(x => x.Id.Equals(model.Id)&& x.Assetag.Equals(model.AssetTag));

                if (result == null)
                {
                   var asset = await _context.Calmains.FirstOrDefaultAsync(x => x.Assetag.Equals(model.AssetTag));
                   if (asset != null)
                   {
                      return new ApiResponse(400, "Asset Tag Already Exsists");
                   }
                }
                    var cal = result ?? new Calmain
                    {
                      Id = Guid.NewGuid().ToString(),
                      Assetag = model.AssetTag
                    };
                        cal.Brand = model.Brand;
                        cal.Department =model.UserDept;
                        cal.Attribute = model.Attribute;
                        cal.Sendmail = model.Email;
                        cal.Sendpic = model.UserPic;
                        cal.Project = model.Project;
                        cal.Attach = model.Attach;
                        cal.Calfee = model.OldAssetTag;
                        cal.Keeper = model.Keeper;
                        cal.Pic = _currentUserServices.Name;
                        cal.Plant = model.PlantId;
                        cal.Project = model.Project;
                        cal.Model = model.Model;
                        cal.Serialno = model.SerialNo;
                        cal.LastDate = model.LastCalDate;
                        cal.NextDate = model.NextCalDate;
                        cal.Type = model.CalType;
                        cal.Status = model.CalStatus;
                        cal.Inspno = model.CALCertificationNo;

                        cal.Loginid = _currentUserServices.EmpID;
                        cal.Cycle = model.CalPeriod;
                        cal.Nocalremark = model.Remark;
                        _context.Calmains.Update(cal);
                        await _context.SaveChangesAsync();
                        return new ApiResponse(200, result != null ? "Item Upadated sucessfully" : "Item Created Sucessfully");
             
            }
            catch (Exception ex)
            {
                return new(500, ex.Message);
            }
        }

        public async Task<ServiceResponse<CalibrationDataModel>> GetCalListById(string assetTag)
        {
            var response = new ServiceResponse<List<CalibrationDataModel>>();

            try
            {
                var calibrationData = await _context.Calmains
                    .Where(a => a.Assetag.Contains(assetTag) && a.Model != null)
                    .Join(_context.Calmodels,
                        a => a.Model,
                        b => b.Model,
                        (a, b) => new CalibrationDataModel
                        {
                            Id = a.Id,
                            AssetTag = a.Assetag,
                            Model = a.Model,
                            Brand = b.Brand,
                            SerialNo = a.Serialno,
                            UserDept = a.Department,
                            UserPic = a.Sendpic,
                            Keeper = a.Keepername,
                            Attribute = b.Attribute,
                            Name = b.Chinesedesc,
                            PlantId = a.Plant,
                            CalStatus = (int)a.Status,
                            CalDept = b.Caldepartment,
                            Remark = a.Nocalremark,
                            LastCalDate = a.LastDate,
                            NextCalDate = a.NextDate,
                            LoginId = a.Loginid,
                            LogDate = a.Logdate.ToString(),
                            Email = a.Sendmail ?? " ", 
                            CalPeriod = b.Cycle,
                            CALCertificationNo = a.Inspno,
                           // Price = a.Price,
                            Project = a.Project,
                            CalType= a.Type,
                            OldAssetTag = a.Calfee
                        })
                    .OrderByDescending(a => a.NextCalDate)
                    .FirstOrDefaultAsync();

                if (calibrationData != null)
                {
                    return new(200, "Data Retrived ", calibrationData);
                }
                else
                {
                    return new(400, "", null);
                }
            }
            catch (Exception ex)
            {
                return new(500, $"An error occurred: {ex.Message}", null);
            }

        }


        public async Task<ServiceResponse<List<CalibrationDataModel>>> GetAllCalList()
        {

            var response = new ServiceResponse<CalibrationDataModel>();

            try
            {
                var calibrationData = await _context.Calmains
                    .Select(cal => new CalibrationDataModel
                    {
                        Id = cal.Id,
                        AssetTag = cal.Assetag,
                        Brand = cal.Brand,
                        UserDept = cal.Department,
                        Attribute = cal.Attribute,
                        Email = cal.Sendmail,
                        UserPic = cal.Sendpic,
                        Project = cal.Project,
                        Attach = cal.Attach,
                        OldAssetTag = cal.Calfee,
                        Keeper = cal.Keeper,
                        PlantId = cal.Plant,
                        Model = cal.Model,
                        SerialNo = cal.Serialno,
                        LastCalDate = cal.LastDate,
                        NextCalDate = cal.NextDate,
                        CalType = cal.Type,
                        CalStatus = (int)cal.Status,
                        CALCertificationNo = cal.Inspno,
                        Remark = cal.Nocalremark
                    })
                    .ToListAsync();

                if (calibrationData != null)
                {
                    return new(200, "", calibrationData);
                }
                else
                {
                    return new(400, "", null);
                }
            }
            catch (Exception ex)
            {
                return new(500, $"An error occurred: {ex.Message}", null);
            }
        }
    }
}
