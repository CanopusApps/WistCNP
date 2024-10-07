using CalSystem2._0.Concrete.IServices.IPMServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using static CalSystem2._0.Models.PmDetailsModel.PmDataModel;

namespace CalSystem2._0.Controllers.PmControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PmMachineController : ControllerBase
    {
        private readonly IPmServices _services;
        public PmMachineController(IPmServices services)
        {
            _services = services;
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddPmDetailsAdd(PMScheduleModel model, bool isAuto)
        {
            return await _services.AddPmDetailsAdd(model, isAuto);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> UploadExcel(IFormFile file)
        {
            return await _services.UploadExcel(file);
        }

        [HttpPost("DeletePM")]
        [Authorize]
        public async Task<ApiResponse> DeletePM(PmIdModel model)
        {
            return await _services.DeletePM(model);
        }

        [HttpGet("[action]")]

        //public async Task<ServiceResponse<List<PMScheduleModel>>> GetPmdeatilsAll()
        //{
        //    return await _services.GetPmdeatilsAll();
        //}
        public async Task<ServiceResponses<List<PMScheduleModel>>> GetPmdeatilsAll(string searchTerm = null, int pageNumber = 1, int pageSize = 10)
        {
            return await _services.GetPmdeatilsAll(searchTerm,pageNumber,pageSize);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<ScheduleModel>> GetScheduleList(PmIdModel model)
        {
            return await _services.GetScheduleList(model);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<string>> UpdatePmSchedule(ScheduleModel model, string machineId)
        {
            return await _services.UpdatePmSchedule(model, machineId);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> IsCheckedPmMachine(string machineId, DateTime? checkDate)
        {
            return await _services.IsCheckedPmMachine(machineId, checkDate);
        }
    }
}
