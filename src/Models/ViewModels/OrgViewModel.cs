namespace src.ViewModels{
    public class OrgViewModel{
        public string orgId{get; set;}
        public string name{get; set;}
        public string description{get; set;}
    }

    public class OrgSuccessResponse{
        public IList<OrgViewModel> organisations{get; set;}
    }
}