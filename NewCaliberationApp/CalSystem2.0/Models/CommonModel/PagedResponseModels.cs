namespace CalSystem2._0.Models.CommonModel
{
    public class PagedResponseModels
    {
        public class ServiceResponses<T>
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public int TotalCount { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }

            public ServiceResponses(int statusCode, string message, T data)
            {
                StatusCode = statusCode;
                Message = message;
                Data = data;
            }
        }

    }
}
