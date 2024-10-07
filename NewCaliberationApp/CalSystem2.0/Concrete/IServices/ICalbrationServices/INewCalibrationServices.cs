using CalSystem2._0.Models.CalibrationModel;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.IServices.ICalbrationServices
{
    public interface INewCalibrationServices
    {
        Task<ServiceResponse<List<DropDownModel>>> ModelDDL();
        Task<ServiceResponse<CalModelDetails>> GetCalModelDetail(string name);
        Task<ApiResponse> AddorUpdateNewCalibration(CalibrationDataModel model);
        Task<DateOnly?> CalculateNextCalDate(string calPeriod, DateOnly lastCalDate);
        Task<ServiceResponse<CalibrationDataModel>> GetCalListById(string assetTag);
        Task<ServiceResponse<List<CalibrationDataModel>>> GetAllCalList();
    }
}
