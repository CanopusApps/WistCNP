using CalSystem2._0.Concrete.IServices.ICalbrationServices;
using CalSystem2._0.Models.CalibrationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Controllers.CalibrationDataControler
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewCalibrationController : ControllerBase
    {
        private readonly INewCalibrationServices _services;

        public NewCalibrationController(INewCalibrationServices services)
        {
            _services = services;
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<DropDownModel>>> ModelDDL()
        {
            return await _services.ModelDDL();
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddorUpdateNewCalibration(CalibrationDataModel model)
        {
            return await _services.AddorUpdateNewCalibration(model);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<CalModelDetails>> GetCalModelDetail(string name)
        {
            return await _services.GetCalModelDetail(name);
        }

        [HttpPost("[action]")]
        public async Task<DateOnly?> CalculateNextCalDate(string calPeriod, DateOnly lastCalDate)
        {
            return await _services.CalculateNextCalDate(calPeriod, lastCalDate);

        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<CalibrationDataModel>> GetCalListById(string assetTag)
        {
            return await _services.GetCalListById(assetTag);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<List<CalibrationDataModel>>> GetAllCalList()
        {
            return await _services.GetAllCalList(); 
        }
    }
}
