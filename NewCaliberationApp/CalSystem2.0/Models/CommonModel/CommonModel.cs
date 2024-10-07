using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CalSystem2._0.Models.CommonModel
{
    public class CommonModel
    {
        public class LoginModel
        {
            [JsonPropertyName("empId")]
            public string EmpId { get; set; }

            [JsonPropertyName("password")]
            public string Password { get; set; }

        }

        public class LoginResponce
        {
            [JsonProperty("empId")]
            public string EmpId { get; set; }

            [JsonProperty("empName")]
            public string EmpName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("checkListApprover")]
            public string CheckListApprover { get; set; }

            [JsonProperty("right")]
            public string Right { get; set; }

            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }

            [JsonProperty("expiresIn")]
            public int ExpiresIn { get; set; }

            [JsonProperty("tokenType")]
            public string TokenType { get; set; }
        }

        public class DropDownModel
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("data")]
            public string Data { get; set; }
        }

        public class IdModel
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
