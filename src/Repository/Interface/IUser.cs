using src.Response;
using src.ViewModels;

namespace src.Interface{
    public interface IUser{
        Task<object> GetUser(string id);
    }
}