using CalSystem2._0.Concrete.IServices.ICommonServices;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;
using System.Globalization;
using System.IO;
using static CalSystem2._0.Models.CommonModel.CommonModel;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using System.Text;
using System;

namespace CalSystem2._0.Controllers.CommonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public CommonController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<LoginResponce>> Login(LoginModel model)
        {
            return await _userServices.Login(model);

        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> ForgotPassword(string empId, String email)
        {
            return await _userServices.ForgotPassword(empId, email);
        }

        

    }
}
