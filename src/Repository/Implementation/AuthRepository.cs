using FMAdminServices.Dtos.Response;
using src.Interface;
using src.ViewModels;

namespace src.Implementation{
    public class AuthRepository : IAuth{
        public Task<ApiResponse<SuccessResponse>> CreateUser(UserViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SuccessResponse>> Login(UserViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}