using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.DataContext;
using CalSystem2._0.Entities;
using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.Services.CommonServices
{
    public class DynamicDataServices : IDynamicDataServices
    {
        private readonly ApplicationDbContext _context;
        public DynamicDataServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> AddCalCycle(int count, string type)
        {
            var content = count.ToString() + type.ToUpper();
            var result = await _context.CalDynamicData.FirstOrDefaultAsync(x => x.Content.Equals(content) && x.Type == 1);
            if (result == null)
            {
                var id = Guid.NewGuid();
                var cycle = new CalDynamicDatum()
                {
                    Id = id.ToString(),
                    Content = content,
                    Type = 1,
                    Name = "Cal Cycle"
                };
                await _context.CalDynamicData.AddAsync(cycle);
                await _context.SaveChangesAsync();
                return new(200, "Cal Cycle Added");
            }
            return new(400, "Period Allready exsisting");
        }

        public async Task<ApiResponse> AddPlant(string plant)
        {
            plant = plant.ToUpper();
            var result = await _context.CalDynamicData.FirstOrDefaultAsync(x => x.Content.Equals(plant) && x.Type == 2);
            if (result == null)
            {
                var id = Guid.NewGuid();
                var CalPlant = new CalDynamicDatum()
                {
                    Id = id.ToString(),
                    Content = plant,
                    Type = 2,
                    Name = "Plant"
                };
                await _context.CalDynamicData.AddAsync(CalPlant);
                await _context.SaveChangesAsync();
                return new(200, "Plant Added");
            }
            return new(400, "Plant Allready exsisting");
        }

        public async Task<ServiceResponse<List<DropDownModel>>> GetCalCycleOrPlant(bool isPlant)
        {
            var type = isPlant ? 2 : 1;

            var result = await _context.CalDynamicData.Where(x => x.Type == type)
           .Select(x => new DropDownModel
           {
               Id = x.Id,
               Data = x.Content
           }).ToListAsync();
            if (result.Count == 0)
            {
                return new(400, "", null);
            }
            return new(200, "", result);
        }
    }
}
