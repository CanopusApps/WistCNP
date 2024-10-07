using System.Text.Json.Serialization;

namespace CalSystem2._0.Models.BaseModel
{
    public class CalChecklistModels
    {
        public class CalChecklistModel
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = null;

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("approver")]
            public string Approver { get; set; }

            [JsonPropertyName("cycle")]
            public string Cycle { get; set; }

            [JsonPropertyName("pubDate")]
            public string PubDate { get; set; }

            [JsonPropertyName("criteria")]
            public string Criteria { get; set; }

            [JsonPropertyName("status")]
            public int Status { get; set; }

            [JsonPropertyName("remarks")]
            public string Remarks { get; set; }
        }

        public class GetCalChecklistModel : CalChecklistModel
        {
            [JsonPropertyName("serialNo")]
            public string SerialNo { get; set; }

            [JsonPropertyName("comments")]
            public string Comments { get; set; }
        }

        public class CalChecklistRequest
        {
            public List<GetCalChecklistModel> Data { get; set; }
        }

        public class CheckListFilter
        {
            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; } = 1; 

            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; } = 10; 

            [JsonPropertyName("searchName")]
            public string SearchName { get; set; } = string.Empty;  

            [JsonPropertyName("calCycle")]
            public string CalCycle { get; set; } = string.Empty;  

            [JsonPropertyName("criteria")]
            public string Criteria { get; set; } = string.Empty; 

            [JsonPropertyName("status")]
            public string Status { get; set; } 

            [JsonPropertyName("pubDate")]
            public string PubDate { get; set; }
        }

        public class ApproveModel
        {
            [JsonPropertyName("id")]
            public List<string> Id { get; set; }
            
            [JsonPropertyName("isApprove")]
            public  bool IsApprove { get; set; }

            [JsonPropertyName("comment")]
            public string Comment { get; set; }
        }
    }
}
