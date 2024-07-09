using src.Response;
using src.Interface;
using src.ViewModels;

namespace src.Implementation{
    public class UserRepository : IUser
    {
        private readonly Data.AppContext _context;

        public UserRepository(Data.AppContext context)
        {
            _context = context;
        }
        public async Task<object> GetUser(string id)
        {
            try{

                var validationErrorResponseList = new List<ErrorViewModel>();

                if(id == string.Empty)
                {
                    var validationErrorResponse = new ErrorViewModel(){
                        field = "id",
                        message = "id cannot be empty"
                    };

                    validationErrorResponseList.Add(validationErrorResponse);
                    return ApiErrorResponse<List<ErrorViewModel>>.Resposne(validationErrorResponseList);
                }

                var userExists = await _context.Users.FindAsync(id);

                if(userExists == null)
                {
                    return ApiFailResponse.Response("failed", "User record not found", 404);
                }

                var response = new UserViewModel(){
                    userId = userExists.ID,
                    firstName = userExists.FirstName,
                    lastName = userExists.LastName,
                    email = userExists.Email,
                    phone = userExists.Phone
                };

                return ApiSuccessResponse<UserViewModel>.Response("success", "Data retrireved successfully", response);

            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return ApiFailResponse.Response("failed", "Error Occurred", 500);
            }
        }
    }
}