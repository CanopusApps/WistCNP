using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using static CalSystem2._0.Models.PmDetailsModel.PmDataModel;

namespace CalSystem2._0.Concrete.IServices.IPMServices
{
    public interface IPmServices
    {
        Task<ApiResponse> AddPmDetailsAdd(PMScheduleModel model, bool isAuto);
        Task<ApiResponse> UploadExcel(IFormFile file);
        Task<ApiResponse> DeletePM(PmIdModel model);
        // Task<ServiceResponse<List<PMScheduleModel>>> GetPmdeatilsAll();
        Task<ServiceResponses<List<PMScheduleModel>>> GetPmdeatilsAll(string searchTerm = null, int pageNumber = 1, int pageSize = 10);
        Task<ServiceResponse<ScheduleModel>> GetScheduleList(PmIdModel model);
        Task<ServiceResponse<string>> UpdatePmSchedule(ScheduleModel model, string machineId);
        Task<ApiResponse> IsCheckedPmMachine(string machineId,DateTime? checkDate);
    }
}
