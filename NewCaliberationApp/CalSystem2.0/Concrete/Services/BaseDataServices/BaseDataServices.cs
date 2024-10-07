using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.DataContext;
using CalSystem2._0.Entities;
using Microsoft.EntityFrameworkCore;
using static CalSystem2._0.Models.BaseModel.BaseDataModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.Services.BaseDataServices
{
    public class BaseDataServices : IBaseDataServices
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUserServices _currentUserServices;

        public BaseDataServices(IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, ICurrentUserServices currentUserServices)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _currentUserServices = currentUserServices;
        }

       

        public async Task<ServiceResponse<HrAtModel>> HrAtData(EmpIdModelModel model)
        {
            var result = await _context.HrAts.FirstOrDefaultAsync(x => x.Emplid == model.EmplId);
            if (result != null)
            {
                var ext = await _context.Calusers.FirstOrDefaultAsync(x => x.Emplid == model.EmplId);
                if (ext != null)
                {
                    return new(400, "CAl User Account Already created ", null);
                }
                var mod = new HrAtModel()
                {
                    Department = result.DeptDescrA,
                    UserName = result.Name
                };

                return new ServiceResponse<HrAtModel>(200, "", mod);
            }
            return new(400, "Please Check Employee Id ", null);
        }

        public async Task<ServiceResponse<List<UserListModel>>> GetCalUser()
        {
            var result = await _context.Calusers
                .Select(s => new UserListModel()
                {
                    Department = s.Department,
                    UserID = s.Emplid,
                    UserName = s.Username,
                    UserRole = s.Right
                }).ToListAsync();
            if (result != null)
            {
                return new(200, "Data", result);
            }
            return new(400, "", null);
        }

        public async Task<ApiResponse> DeleteUsers(EmpIdModelModel model)
        {
            var result = await _context.Calusers.Where(x => x.Emplid == model.EmplId).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Remove(result);
               await _context.SaveChangesAsync();

                return new(200, "Deleted Successfully");
            }
            return new(400, "error");
        }

        public async Task<ApiResponse>AddCalUsers(CalUserModel model)
        {
            try
            {
                var result = await _context.Calusers.FirstOrDefaultAsync(x => x.Emplid == model.EmplId);
                if (result == null)
                {
                    var id = Guid.NewGuid().ToString();
                    var user = new Caluser()
                    {
                        Username = model.UserName,
                        Password = model.Password,
                        Department = model.Department,
                        Emplid = model.EmplId,
                        Logdate = System.DateTime.Now,
                        Right = model.UserRole,
                        Loginid = model.UserID,
                        Id = id
                    };
                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return new(200, "User Added Sucessfully");
                }
                return new(400, "User Allredy exsistes");
            }
            catch (Exception ex)
            {
                return new(400,$"{ex}");
            }
        }

        public async Task<ApiResponse> AddModelList(ModeListModel model)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var existingModel = await _context.Calmodels
                    .Where(x => x.Chinesedesc == model.ChineseName || x.Englishdesc == model.Name)
                    .FirstOrDefaultAsync();

                if (existingModel == null)
                {
                    var newModel = new Calmodel
                    {
                        Englishdesc = model.Name,
                        Chinesedesc = model.Name,
                        Cycle = model.Cycle,
                        Model = model.Model,
                        Loginid = _currentUserServices.EmpID,
                        Brand = model.Brand,
                        Attribute = model.Attribute,
                        Logdate = DateTime.Now
                    };

                    await _context.Calmodels.AddAsync(newModel);
                    await _context.SaveChangesAsync();
                    return new ApiResponse(200, "Operation completed successfully.");
                }

                return new ApiResponse(400, "Model is alredy exists");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
