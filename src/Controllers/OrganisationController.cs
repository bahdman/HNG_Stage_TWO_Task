using Microsoft.AspNetCore.Mvc;
using src.ViewModels;

namespace src.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase{
        [HttpGet]
        public IActionResult GetAll(){
            return Ok();
        }

        [HttpGet("{orgId}")]
        public IActionResult GetOrgByID(string orgId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatOrganisation(CreateOrgViewModel viewModel)
        {
            return Ok();
        }

        [HttpPost("{orgId}/users")]
        public IActionResult AddUserToOrg(AddUserToOrgViewModel viewModel)
        {
            return Ok();
        }
    }
}