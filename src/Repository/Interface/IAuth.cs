using FMAdminServices.Dtos.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IAuth{
        Task<ApiResponse<SuccessResponse>> CreateUser(UserViewModel viewModel);
        Task<ApiResponse<SuccessResponse>> Login(UserViewModel viewModel);
    }
}