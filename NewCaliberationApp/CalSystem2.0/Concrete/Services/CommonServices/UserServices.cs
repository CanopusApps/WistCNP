using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;

namespace CalSystem2._0.Concrete.Services.CommonServices
{
    public class UserServices : IUserServices
    {
        private readonly IConfiguration _configuration;
        private readonly GlobalServices _globalServices;
        private readonly ApplicationDbContext _context;
        public UserServices(IConfiguration configuration, GlobalServices globalServices, ApplicationDbContext context)
        {
            _configuration = configuration;
            _globalServices = globalServices;
            _context = context;
        }

        public async Task<ServiceResponse<LoginResponce>> Login(LoginModel model)
        {
            try
            {
                var result = await _context.Calusers.Where(x => x.Loginid == model.EmpId && x.Password.Equals(model.Password)).FirstOrDefaultAsync();
                if (result != null)
                {
                    var email = await _context.HrAts.Where(a => a.Emplid == model.EmpId).Select(x => x.EmailAddressA).FirstOrDefaultAsync();

                    var CheckListApprovers = _configuration.GetValue<string>("CheckListApprover:CheckListApprover");
                    LoginResponce response = new()
                    {
                        Email = email,
                        EmpId = model.EmpId,
                        Right = result.Right,
                        EmpName = result.Username,
                        ExpiresIn = 43200000,
                        TokenType = "bearer",
                        CheckListApprover = CheckListApprovers,
                        AccessToken = AccessToken(result.Emplid, result.Right, result.Department, result.Username)
                    };
                    return new(200, "LoginScuess", response);
                }
                return new(400, "please check the credential", null);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Connection or query failed: {ex.Message}", ex);
            }
        }

        private string AccessToken(string EmplId, string Right, string Dept,string Name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtOptions:SecurityKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration.GetValue<string>("JwtOptions:Issuer"),
                Audience = _configuration.GetValue<string>("JwtOptions:Audience"),
                Subject = new ClaimsIdentity(new Claim[]
                {
               new Claim(ClaimTypes.NameIdentifier, EmplId),
               new Claim(ClaimTypes.Role, Right),
               new Claim("Dept", Dept),
               new Claim(ClaimTypes.Name,Name)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<ApiResponse> ForgotPassword(string empId, string emailId)
        {
            try
            {
                var result = await _context.HrAts.Where(x => x.Emplid == empId && x.EmailAddressA == emailId).Select(x => x.EmailAddressA).FirstOrDefaultAsync();

                if (result != null)
                {
                    var pass = await _context.Calusers.Where (x=> x.Emplid == empId).Select(a=> a.Password).FirstOrDefaultAsync();
                    var news = await _globalServices.SendEmailAsync(null, result, true, pass);
                    return new ApiResponse(200, $"Password sent to your email successfully: {result}, {news}");
                }
                else
                {
                    return new ApiResponse(400, "Invalid employee ID or email address.");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Connection or query failed: {ex.Message}");
            }
        }

    }
}
