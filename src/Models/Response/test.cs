using src.ViewModels;

namespace src.Response{
    public class SuccessResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }   

    public class ErrorResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public class RegData{
        public string accessToken{get; set;}
        public UserViewModel user{get; set;}
    }

    public class ResponseGenerator<T>
    {
        public SuccessResponse<T> GenerateSuccessResponse<T>(string status, string message, T data)
        {
            return new SuccessResponse<T>
            {
                Status = status,
                Message = message,
                Data = data
            };
        }

        public ErrorResponse GenerateErrorResponse(string status, string message, int statusCode)
        {
            return new ErrorResponse
            {
                Status = status,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}