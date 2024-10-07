using Microsoft.AspNetCore.Mvc.ApiExplorer;
using static CalSystem2._0.Models.BaseModel.BaseDataModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.IServices.IBaseDataServices
{
    public interface IBaseDataServices
    {
        Task<ServiceResponse<HrAtModel>> HrAtData(EmpIdModelModel model);
        Task<ServiceResponse<List<UserListModel>>> GetCalUser();
        Task<ApiResponse> DeleteUsers(EmpIdModelModel model);
        Task<ApiResponse> AddCalUsers(CalUserModel model);
        Task<ApiResponse> AddModelList(ModeListModel model);
    }
}
