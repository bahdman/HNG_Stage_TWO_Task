namespace FMAdminServices.Dtos.Response
{
    public class ApiResponse<T>
    {
        public string Status{get; set;}
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode{get; set;}

        public ApiResponse(string status, string message, T data, int statusCode)
        {
            Status = status;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResponse()
        {

        }

        public static ApiResponse<T> Fail(string status, string errorMessage, int statusCode)
        {
            return new ApiResponse<T> { Status = status, Message = errorMessage, StatusCode = statusCode};
        }

        public static ApiResponse<T> Success(string status, string successMessage, T data)
        {
            return new ApiResponse<T> { Status = status, Message = successMessage, Data = data };
        }
    }
}
