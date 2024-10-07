using CalSystem2._0.Concrete.IServices.ICommonServices;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CalSystem2._0.Concrete.Services.CommonServices
{
    public class CurrentUserServices : ICurrentUserServices
    {
        private readonly IHttpContextAccessor _httpContext;

        public CurrentUserServices(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }


        // public string EmpID => Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public string EmpID => _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public string Email => _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

        public string Name => _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;

        public string RoleType => _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        public string Dept => _httpContext.HttpContext.User.FindFirst("Dept").Value;
        //  public List<int> RoleIds => JsonConvert.DeserializeObject<List<int>>(_httpContext.HttpContext.User.FindFirst("roleids").Value);

    }

}
