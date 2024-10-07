using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.IServices.ICommonServices
{
    public interface IDynamicDataServices
    {
        Task<ApiResponse> AddCalCycle(int count, string type);
        Task<ApiResponse> AddPlant(string plant);
        Task<ServiceResponse<List<DropDownModel>>> GetCalCycleOrPlant(bool isPlant);
    }
}
