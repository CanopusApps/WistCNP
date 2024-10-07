using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.BaseDataModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Controllers.BaseDataController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : ControllerBase
    {
        private readonly IBaseDataServices _baseDataServices;

        public BaseDataController(IBaseDataServices baseDataServices)
        {
            _baseDataServices = baseDataServices;
        }

        

        [HttpPost("[action]")]
        [Authorize(Roles = "CA")]
        public async Task<ServiceResponse<HrAtModel>> HrAtData(EmpIdModelModel model)
        {
            return await _baseDataServices.HrAtData(model);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "CA")]
        public async Task<ServiceResponse<List<UserListModel>>> GetCalUser()
        {
            return await _baseDataServices.GetCalUser();
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "CA")]
        public async Task<ApiResponse> DeleteUsers(EmpIdModelModel model)
        {
            return await _baseDataServices.DeleteUsers(model);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "CA")]
        public async Task<ApiResponse> AddCalUsers(CalUserModel model)
        {
            return await _baseDataServices.AddCalUsers(model);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "CH,CA")]
        public async Task<ApiResponse> AddModelList(ModeListModel model)
        {
            return await _baseDataServices.AddModelList(model);

        }
    }
}
