using src.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IAuth{
        Task<object> CreateUser (RegisterViewModel viewModel);
        Task<object> Login(UserViewModel viewModel);
    }
}