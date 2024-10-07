using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using CalSystem2._0.DataContext;
using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using static CalSystem2._0.Models.BaseModel.CalMDataModel;
using CalSystem2._0.Entities;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;
using System.Text;
using CalSystem2._0.Concrete.Services.CommonServices;
using CalSystem2._0.Concrete.IServices.ICommonServices;
using System.Net.WebSockets;

namespace CalSystem2._0.Concrete.Services.BaseDataServices
{
    public class CalModelService : ICalModelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserServices _currentUserServices;
        public CalModelService(ApplicationDbContext context,IConfiguration configuration,ICurrentUserServices currentUserServices)
        {
            _context = context;
            _configuration = configuration;
            _currentUserServices = currentUserServices;
        }

        public async Task<ServiceResponse<List<DropDownModel>>> CalListAssetDDL()
        {
            try
            {
                var result = await _context.Calchecklists.Where(x => x.Status == "Y")
                    .Select(s => new DropDownModel
                    {
                        Data = s.Assetag,
                        Id = s.Id
                    }).ToListAsync();
                return new(200, "list retrived", result);
            }
            catch (Exception ex)
            {
                return new(400, ex.Message, null);
            }
        }

        public async Task<ApiResponse> AddorUpdateCalModel(AddCalModel model)
        {
            try
            {
                if (model.Id == null || model.Id == "")
                {
                    var result = new Calmodel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Model = model.ModelName,
                        Chinesedesc = model.Name,
                        Brand = model.Brand,
                        Cycle = model.Cycle,
                        Attribute = model.Attribute,
                        Caldepartment = model.Department,
                        Englishdesc = model.Name,
                        Loginid = _currentUserServices.EmpID,
                        Logdate = DateTime.Now
                    };
                    await _context.AddAsync(result);
                }
                else
                {
                    var results = await _context.Calmodels.FirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                    results.Attribute = model.Attribute;
                    results.Chinesedesc = model.Name;
                    results.Brand = model.Brand;
                    results.Cycle = model.Cycle;
                    results.Englishdesc = model.Name;
                    results.Caldepartment = model.Department;
                    results.Chinesedesc = model.Name;
                    results.Loginid = _currentUserServices.EmpID;
                    results.Logdate = DateTime.Now;
                    _context.Update(results);
                }
                await _context.SaveChangesAsync();
                return new(200, model.Id == null ? "Cal Model is Updated" : "New CalModel is Created");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }
        }


        public async Task<ServiceResponse<List<DropDownModel>>> CalAtrributeDDL()
        {
            var attribute = _configuration.GetValue<string>("Attribute:Attribute");
            var result = attribute?
                .Split(',')
                .Select(attr => new DropDownModel
                {
                    Id = new Random().Next(1, 10000).ToString(),
                    Data = attr.Trim()
                })
                .ToList() ?? new List<DropDownModel>();

            return new ServiceResponse<List<DropDownModel>>(200, "Data Retrieved", result);
        }

        public async Task<ServiceResponse<List<GetCalmodel>>> GetCalModel(CalModelFilter model)
        {
            try {
                var result = await _context.Calmodels
                    .Select(
                    x => new GetCalmodel
                    {
                        ModelName = x.Model,
                        Attribute = x.Attribute,
                        Cycle = x.Cycle,
                        Name = x.Chinesedesc,
                        Department = x.Caldepartment,
                        Brand = x.Brand,
                        Id = x.Id,
                        LogDate = x.Logdate.ToString(),
                        UserID = x.Loginid

                    })
                    .ToListAsync();
                if (result.Count != 0)
                {
                    if (model.FilterId == 1)
                    {
                        result = result.Where(x => x.ModelName.Equals(model.Content)).ToList();
                    }
                    else if (model.FilterId == 2)
                    {
                        result = result.Where(x => x.Attribute.Equals(model.Content)).ToList();
                    }
                } 
                return new(200, "Data Retrived", result);
            }
            catch(Exception ex)
            {
                return new(500, ex.Message, null);
            }
            }

        public async Task<ServiceResponse<String>> GenerateCalModelCsv([FromBody] CalModellistRequest calmodels)
        {
            if (calmodels == null || !calmodels.Data.Any())
            {
                return new(400, "No data provided.", "No data provided");
            }

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Model,Name,Brand,Attribute,Calibration cycle(M),Department,UserID,LogDate"); 

            foreach (var calmodel in calmodels.Data)
            {
                csvBuilder.AppendLine($"{calmodel.Id},{calmodel.ModelName},{calmodel.Name},{calmodel.Brand}," +
                    $"{calmodel.Attribute},{calmodel.Cycle},{calmodel.Department},{calmodel.UserID}," +
                    $"{calmodel.LogDate}");
            }

            var csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var base64Csv = Convert.ToBase64String(csvBytes);

            return new(200, "CSV File Created SucessFully", base64Csv);
        }

        public async Task<ApiResponse> DeleteCalModel(IdModel model)
        {
            try
            {
                var result = await _context.Calmodels.FirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                _context.Calmodels.Remove(result);
                await _context.SaveChangesAsync();
                return new(200, "Item Deleted");
            }
            catch (Exception ex)
            {
                return new(500, ex.Message);
            }
        }

    }
}
