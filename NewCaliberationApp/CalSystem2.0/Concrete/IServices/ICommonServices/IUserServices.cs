using CalSystem2._0.Concrete.Services.CommonServices;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
namespace CalSystem2._0.Concrete.IServices.ICommonServices
{
    public interface IUserServices
    {
        Task<ServiceResponse<LoginResponce>> Login(LoginModel model);
        Task<ApiResponse> ForgotPassword(string empId, String email);
    }
}
