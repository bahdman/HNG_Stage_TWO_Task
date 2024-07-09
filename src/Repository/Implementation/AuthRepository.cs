using src.Interface;
using src.Models;
using src.Response;
using src.ViewModels;

namespace src.Implementation{
    public class AuthRepository : IAuth{

        private readonly Data.AppContext _context;

        public AuthRepository(Data.AppContext context){
            _context = context;
        }

        public async Task<object> CreateUser(RegisterViewModel viewModel)
        {
            try{

                var validationErrorResponseList = new List<ErrorViewModel>();

                if(viewModel == null)
                {
                    var validationErrorResponse = new ErrorViewModel(){
                        field = "null",
                        message = "cannot be null"
                    };

                    validationErrorResponseList.Add(validationErrorResponse);
                    return ApiErrorResponse<List<ErrorViewModel>>.Resposne(validationErrorResponseList);
                }

                Organisation org = new(){
                    Name = $"{viewModel.firstName}'s Organisation",
                    Description = $"{viewModel.firstName} organisation"
                };

                await _context.Organisations.AddAsync(org);
                // await _context.SaveChangesAsync();                

                User user = new User(){
                    FirstName = viewModel.firstName,
                    LastName = viewModel.lastName,
                    Email = viewModel.email,
                    Password = viewModel.password,
                    Phone = viewModel.phone,
                    OrganisationID = org.ID                    
                };

                await _context.Users.AddAsync(user);
                // await _context.SaveChangesAsync();

                var userViewModel = new UserViewModel(){
                    userId = user.ID,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    phone = user.Phone
                };

                var response = new SuccessResponse(){
                    accessToken = "",
                    user = userViewModel
                };


                return ApiSuccessResponse<SuccessResponse>.Response("success", "Registration successful", response);




            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return ApiFailResponse.Response("failed", "Error occurred", 500);
            }
        }

        public Task<object> Login(UserViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}