namespace src.Response{
    public class ApiErrorResponse<T>{
        public T Errors{get; set;}

        public ApiErrorResponse(T errors){
            Errors = errors;
        }

        public ApiErrorResponse(){}

        public static ApiErrorResponse<T> Resposne(T errors)
        {
            return new ApiErrorResponse<T>{Errors = errors};
        }
    }
}