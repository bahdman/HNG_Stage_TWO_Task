using FMAdminServices.Dtos.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IUser{
        Task<ApiResponse<UserViewModel>> GetUser(string id);
    }
}