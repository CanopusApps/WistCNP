using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CalSystem2._0.Models.BaseModel
{
    public class BaseDataModel
    {

        public class ModeListModel
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("chineseName")]
            public string ChineseName { get; set; }

            [JsonPropertyName("model")]
            public string Model { get; set; }

            [JsonPropertyName("brand")]
            public string Brand { get; set; }

            [JsonPropertyName("attribute")]
            public string Attribute { get; set; }

            [JsonPropertyName("department")]
            public string Department { get; set; }

            [JsonProperty("cycle")]
            public string Cycle { get; set; }
        }

        public class HrAtModel
        {
            [JsonPropertyName("userName")]
            public string UserName { get; set; }

            [JsonPropertyName("department")]
            public string Department { get; set; }

        }

        public class UserListModel
        {
            [JsonPropertyName("userName")]
            public string UserName { get; set; }

            [JsonPropertyName("userID")]
            public string UserID { get; set; }

            [JsonPropertyName("department")]
            public string Department { get; set; }

            [JsonPropertyName("userRole")]
            public string UserRole { get; set; }
        }

        public class EmpIdModelModel
        {
            [JsonPropertyName("emplId")]
            public string EmplId { get; set; }
        }

        public class CalUserModel : UserListModel
        {
            [JsonPropertyName("emplId")]
            public string EmplId { get; set; }

            [JsonPropertyName("password")]
            public string Password { get; set; }
        }
    }
}
