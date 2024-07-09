using Microsoft.AspNetCore.Mvc;
using src.Interface;
using src.ViewModels;

namespace src.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase{

        private readonly IOrganisation _service;

        public OrganisationController(IOrganisation service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res =  await _service.GetAllOrganizations();
            return Ok(res);
        }

        [HttpGet("{orgId}")]
        public async Task<IActionResult> GetOrgByID(string orgId)
        {
            var res = await _service.GetOrgByID(orgId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreatOrganisation(CreateOrgViewModel viewModel)
        {
            var res = await _service.CreateOrg(viewModel);
            return Ok(res);
        }

        [HttpPost("{orgId}/users")]
        public async Task<IActionResult> AddUserToOrg(string orgId, AddUserToOrgViewModel viewModel)
        {
            return Ok(await _service.AddUserToOrg(viewModel, orgId));
        }
    }
}