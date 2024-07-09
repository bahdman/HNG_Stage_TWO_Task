namespace src.Models{
    public class User{
        public string ID{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Email{get; set;}
        public string Phone{get; set;}
        public string Password{get; set;}
        public string OrganisationID{get; set;}
        public Organisation Organisation{get; set;}

        public User()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}