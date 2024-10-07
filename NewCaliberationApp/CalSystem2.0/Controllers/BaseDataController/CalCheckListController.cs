using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Controllers.BaseDataController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalCheckListController : ControllerBase
    {
        private readonly ICalCheckListServices _calCheckListServices;
        public CalCheckListController(ICalCheckListServices calCheckListServices)
        {
            _calCheckListServices = calCheckListServices;
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponses<List<GetCalChecklistModel>>> GetAllCheckList(CheckListFilter filter, bool isCalOff)
        {
            return await _calCheckListServices.GetAllCheckList(filter,isCalOff);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddOrUpdateCalCheckList(CalChecklistModel model)
        {
            return await _calCheckListServices.AddOrUpdateCalCheckList(model);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> DeleteCalListdata(IdModel model)
        {
            return await _calCheckListServices.DeleteCalListdata(model);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<String>> GenerateCsv([FromBody] CalChecklistRequest checklists)
        {
            return await _calCheckListServices.GenerateCsv(checklists);
        }

        [HttpPost("[action]")]

        public async Task<ApiResponse> RejectOrApproveCalCheckList(ApproveModel model)
        {
            return await _calCheckListServices.RejectOrApproveCalCheckList(model);
        }
    }
}
