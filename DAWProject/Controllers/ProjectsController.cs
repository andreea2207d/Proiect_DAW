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
    public class ProjectsController : ControllerBase
    {
        private readonly IEngagementService _engagementService;

        public ProjectsController(IEngagementService engagementService)
        {
            _engagementService = engagementService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_engagementService.FindAllProjects().ToList());
        }
        
        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            _engagementService.CreateProject(project);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditProject(Project project)
        {
            _engagementService.EditProject(project);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid projectId)
        {
            _engagementService.DeleteProject(projectId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignUserToProject(ProjectAssignmentDto projectAssignmentDto)
        {
            _engagementService.AssignUserToProject(projectAssignmentDto.UserId, projectAssignmentDto.ProjectId);
            return Ok();
        }
    }
}