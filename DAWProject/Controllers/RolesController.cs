using System;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.EngagementService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IEngagementService _engagementService;

        public RolesController(IEngagementService engagementService)
        {
            _engagementService = engagementService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_engagementService.FindAllRoles().ToList());
        }
        
        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            _engagementService.CreateRole(role);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditRole(Role role)
        {
            _engagementService.EditRole(role);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid roleId)
        {
            _engagementService.DeleteRole(roleId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignRoleToUser(RoleAssignmentDto roleAssignmentDto)
        {
            _engagementService.AssignRoleToUser(roleAssignmentDto.UserId,
                roleAssignmentDto.RoleId);
            return Ok();
        }
    }
}