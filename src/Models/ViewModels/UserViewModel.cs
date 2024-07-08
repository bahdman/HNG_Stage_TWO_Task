namespace src.ViewModels{
    public class UserViewModel{
        public string userId{get; set;}
        public string firstName{get; set;}
        public string lastName{get; set;}
        public string email{get; set;}
        public string phone{get; set;}
    }

    public class SuccessResponse{
        public string accessToken{get; set;}
        public UserViewModel user{get; set;}
    }
}
