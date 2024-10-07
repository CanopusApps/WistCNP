using CalSystem2._0.Concrete.IServices.ICommonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Controllers.CommonController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicDataController : ControllerBase
    {
        private readonly IDynamicDataServices _dynamicDataServices;
        public DynamicDataController(IDynamicDataServices dynamicDataServices)
        {
            _dynamicDataServices = dynamicDataServices;
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddCalCycle(int count, string type)
        {
            return await _dynamicDataServices.AddCalCycle(count, type);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> AddPlant(string plant)
        {
            return await _dynamicDataServices.AddPlant(plant);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<DropDownModel>>> GetCalCycleOrPlant(bool isPlant)
        {
            return await _dynamicDataServices.GetCalCycleOrPlant(isPlant);
        }

        
    }
}
