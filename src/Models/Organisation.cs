namespace src.Models{
    public class Organisation{
        public string ID{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public ICollection<User> Users{get; set;}

        public Organisation()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}