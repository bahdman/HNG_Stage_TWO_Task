using src.Response;
using src.Interface;
using src.ViewModels;
using Microsoft.EntityFrameworkCore;
using src.Models;
using Microsoft.AspNetCore.Http.Features;

namespace src.Implementation{
    public class OrganisationRepository : IOrganisation
    {
        private readonly Data.AppContext _context;

        public OrganisationRepository(Data.AppContext context)
        {
            _context = context;
        }
        public async Task<object> AddUserToOrg(AddUserToOrgViewModel viewModel, string orgId)
        {
            try{
                 var validationErrorResponseList = new List<ErrorViewModel>();

                if(orgId == string.Empty || viewModel.userId == string.Empty)
                {
                    var validationErrorResponse = new ErrorViewModel(){
                        field = string.IsNullOrEmpty(viewModel.userId)
                                ? (string.IsNullOrEmpty(orgId)
                                    ? "userId and orgId"
                                    : "userId")
                                : (string.IsNullOrEmpty(orgId)
                                    ? "orgId"
                                    : ""),
                        message = "field cannot be empty"
                    };

                    validationErrorResponseList.Add(validationErrorResponse);
                    return ApiErrorResponse<List<ErrorViewModel>>.Resposne(validationErrorResponseList);
                }
                var user = await _context.Users.FindAsync(viewModel.userId);
                var org = await _context.Organisations.FindAsync(orgId);

                var UserExistsInOrg = await _context.Organisations.Include(m => m.Users).ToListAsync();

                if(user == null || org == null)
                {
                    return new MessageViewModel(){
                        status = "failed",
                        message = "user or org does not exist"
                    };
                }

                foreach(var item in UserExistsInOrg)
                {
                    if (item.Users.Where(m => m.ID == user.ID) != null)
                    {
                        return new MessageViewModel(){
                            status = "failed",
                            message = "user already exist in this organisation"
                        };
                    }
                }

                org.Users.Add(user);
                // _context.Update(org);    

                return new MessageViewModel(){status = "success", message = "User added to organisation successfully"};            

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new MessageViewModel(){status = "failed", message = "error occurred"};
            }
        }

        public async Task<object> CreateOrg(CreateOrgViewModel viewModel)
        {
            try{

                var validationErrorResponseList = new List<ErrorViewModel>();

                if(viewModel == null || viewModel.description == string.Empty || viewModel.name == string.Empty)
                {
                    var validationErrorResponse = new ErrorViewModel(){
                        field =  string.IsNullOrEmpty(viewModel.name)
                                ? (string.IsNullOrEmpty(viewModel.description)
                                    ? "name and description"
                                    : "name")
                                : (string.IsNullOrEmpty(viewModel.description)
                                    ? "description"
                                    : ""),

                        message = "cannot be empty"
                    };

                    validationErrorResponseList.Add(validationErrorResponse);
                    return ApiErrorResponse<List<ErrorViewModel>>.Resposne(validationErrorResponseList);
                }
                var org  = new Organisation(){
                    Name = viewModel.name,
                    Description = viewModel.description
                };

                await _context.Organisations.AddAsync(org);
                // await _context.SaveChangesAsync();

                var response = new OrgViewModel(){
                    orgId = org.ID,
                    name = org.Name,
                    description = org.Description
                };

                return ApiSuccessResponse<OrgViewModel>.Response("success", "Organisation created successfully", response);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiFailResponse.Response("failed", "Error occurred", 500);
            }
        }

        public async Task<object> GetAllOrganizations()
        {
            try{
                var OrgList = new List<OrgViewModel>();
                var orgItems = await _context.Organisations.ToListAsync();

                foreach(var item in orgItems)
                {
                    var orgItem = new OrgViewModel(){
                        orgId = item.ID,
                        name = item.Name,
                        description = item.Description
                    };

                    OrgList.Add(orgItem);
                }                
                
                var response = new OrgSuccessResponse(){
                    organisations = OrgList
                };

                return ApiSuccessResponse<OrgSuccessResponse>.Response("success", "Items retrieved", response);

            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return ApiFailResponse.Response("failed", "Error occurred", 500);
            }
            throw new NotImplementedException();
        }

        public async Task<object> GetOrgByID(string id)
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
                var item = await _context.Organisations.FindAsync();

                if(item == null)
                {
                    return ApiFailResponse.Response("failed", "organistion not found", 404);
                }

                var response = new OrgViewModel(){
                    orgId = item.ID,
                    name = item.Name,
                    description = item.Description
                };

                return ApiSuccessResponse<OrgViewModel>.Response("success", "Item retrieved succusfully", response);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiFailResponse.Response("Failed", "Error Ocurred", 500);
            }
        }
    }
}