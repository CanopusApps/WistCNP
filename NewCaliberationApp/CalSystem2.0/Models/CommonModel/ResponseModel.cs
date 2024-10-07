using Newtonsoft.Json;

namespace CalSystem2._0.Models.CommonModel
{
    public class ResponseModels
    {
        public class ApiResponse
        {
            public ApiResponse()
            {

            }
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("statusCode")]
            public long StatusCode { get; set; }

            public ApiResponse(int statusCode, string message)
            {
                Message = message;
                StatusCode = statusCode;
            }
        }

        public class ServiceResponse<T> : ApiResponse
        {
            public ServiceResponse()
            {

            }


            [JsonProperty("data")]
            public T Data { get; set; }

            public ServiceResponse(int StatusCode, string Message, T Data)
            {
                this.Message = Message;
                this.Data = Data;
                this.StatusCode = StatusCode;
            }
        }
    }
}
