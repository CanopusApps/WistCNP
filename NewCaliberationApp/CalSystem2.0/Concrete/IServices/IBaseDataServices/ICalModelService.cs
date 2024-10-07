using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.CalMDataModel;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.IServices.IBaseDataServices
{
    public interface ICalModelService
    {
        Task<ServiceResponse<List<DropDownModel>>> CalListAssetDDL();
        Task<ApiResponse> AddorUpdateCalModel(AddCalModel model);
        Task<ServiceResponse<List<DropDownModel>>> CalAtrributeDDL();
        Task<ServiceResponse<List<GetCalmodel>>> GetCalModel(CalModelFilter model);
        Task<ServiceResponse<String>> GenerateCalModelCsv([FromBody] CalModellistRequest calmodels);
        Task<ApiResponse> DeleteCalModel(IdModel model);
    }
}
