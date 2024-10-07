using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;
using static CalSystem2._0.Models.BaseModel.CalMDataModel;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.IServices.IBaseDataServices
{
    public interface ICalCheckListServices
    {
        Task<ServiceResponses<List<GetCalChecklistModel>>> GetAllCheckList(CheckListFilter filter, bool isCalOff);
        Task<ApiResponse> AddOrUpdateCalCheckList(CalChecklistModel model);
        Task<ApiResponse> DeleteCalListdata(IdModel model);
        Task<ServiceResponse<String>> GenerateCsv([FromBody] CalChecklistRequest checklists);
        Task<ApiResponse> RejectOrApproveCalCheckList(ApproveModel model);
    }
}
