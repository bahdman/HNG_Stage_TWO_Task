using src.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IOrganisation{
        Task<object> GetAllOrganizations();
        Task<object> GetOrgByID(string id);
        Task<object> CreateOrg(CreateOrgViewModel viewModel);
        Task<object> AddUserToOrg(AddUserToOrgViewModel viewModel, string orgId);
    }
}