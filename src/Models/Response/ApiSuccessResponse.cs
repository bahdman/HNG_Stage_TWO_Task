namespace src.Response{
    public class ApiSuccessResponse<T>{
        public string Status{get; set;}
        public string Message{get; set;}
        public T Data{get; set;}

        public ApiSuccessResponse(string status, string message, T data){
            Status = status;
            Message = message;
            Data = data;            
        }

        public ApiSuccessResponse(){}

        public static ApiSuccessResponse<T> Response(string status, string message, T data)
        {
            return new ApiSuccessResponse<T>{ Status = status, Message = message, Data = data};
        }
    }
}