using FMAdminServices.Dtos.Response;
using src.Interface;
using src.ViewModels;

namespace src.Implementation{
    public class Userrepository : IUser
    {
        public Task<ApiResponse<UserViewModel>> GetUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}