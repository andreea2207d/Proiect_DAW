using System;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.OrganizationService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public RolesController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_organizationService.FindAllRoles().ToList());
        }
        
        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            _organizationService.CreateRole(role);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditRole(Role role)
        {
            _organizationService.EditRole(role);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid roleId)
        {
            _organizationService.DeleteRole(roleId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignRoleToUser(RoleAssignmentDto roleAssignmentDto)
        {
            _organizationService.AssignRoleToUser(roleAssignmentDto.UserId,
                roleAssignmentDto.RoleId);
            return Ok();
        }
    }
}