using FMAdminServices.Dtos.Response;
using src.Interface;
using src.ViewModels;

namespace src.Implementation{
    public class OrganisationRepository : IOrganisation
    {
        public Task<SuccessViewModel> AddUserToOrg(AddUserToOrgViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<OrgViewModel>> CreateOrg(CreateOrgViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<OrgViewModel>> GetAllOrganizations()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<OrgViewModel>> GetOrgByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}