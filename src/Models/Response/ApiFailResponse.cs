namespace src.Response{
    public class ApiFailResponse{
        public string Status{get; set;}
        public string Message{get; set;}
        public int StatusCode{get; set;}

        public ApiFailResponse(string status, string message, int statusCode){
            Status = status;
            Message = message;
            StatusCode = statusCode;
        }

        public ApiFailResponse(){}

        public static ApiFailResponse Response(string status, string message, int statusCode)
        {
            return new ApiFailResponse{ Status = status, Message = message, StatusCode = statusCode};
        }
    }
}