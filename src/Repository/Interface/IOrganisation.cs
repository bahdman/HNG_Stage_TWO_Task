using FMAdminServices.Dtos.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IOrganisation{
        Task<ApiResponse<OrgViewModel>> GetAllOrganizations();
        Task<ApiResponse<OrgViewModel>> GetOrgByID(string id);
        Task<ApiResponse<OrgViewModel>> CreateOrg(CreateOrgViewModel viewModel);
        Task<SuccessViewModel> AddUserToOrg(AddUserToOrgViewModel viewModel);
    }
}