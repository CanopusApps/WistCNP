using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static CalSystem2._0.Models.BaseModel.CalChecklistModels;

namespace CalSystem2._0.Models.BaseModel
{
    public class CalMDataModel
    {

        public class AddCalModel
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("modelName")]
            public string ModelName { get; set; }

            [JsonPropertyName("brand")]
            public string Brand { get; set; }

            [JsonPropertyName("attribute")]
            public string Attribute { get; set; }

            [JsonPropertyName("department")]
            public string Department { get; set; }

            [JsonPropertyName("cycle")]
            public string Cycle { get; set; }
        }

        public class GetCalmodel : AddCalModel 
        {
            [JsonPropertyName("logDate")]
            public string LogDate { get; set; }

            [JsonPropertyName("userID")]
            public string UserID { get; set; }
        }
        public class CalModelFilter
        {

            [JsonPropertyName("filterId")]
            public int FilterId { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }
        }

        public class CalModellistRequest 
        {
            public List<GetCalmodel> Data { get; set; }
        }
    }
}
