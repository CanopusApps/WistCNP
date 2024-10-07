using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using static CalSystem2._0.Models.BaseModel.CalMDataModel;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Controllers.BaseDataController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalModelController : ControllerBase
    {
        private readonly ICalModelService _calModelService;
        public CalModelController(ICalModelService calModelService)
        {
            _calModelService = calModelService;
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<DropDownModel>>> CalListAssetDDL()
        {
            return await _calModelService.CalListAssetDDL();
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddorUpdateCalModel(AddCalModel model)
        {
            return await _calModelService.AddorUpdateCalModel(model);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<DropDownModel>>> CalAtrributeDDL()
        {
            return await _calModelService.CalAtrributeDDL();
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<List<GetCalmodel>>> GetCalModel(CalModelFilter model)
        {
            return await _calModelService.GetCalModel(model);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<String>> GenerateCalModelCsv([FromBody] CalModellistRequest calmodels)
        {
            return await _calModelService.GenerateCalModelCsv(calmodels);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> DeleteCalModel(IdModel model)
        {
            return await _calModelService.DeleteCalModel(model);
        }
    }
}
