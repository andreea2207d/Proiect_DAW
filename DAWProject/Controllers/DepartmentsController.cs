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
    public class DepartmentsController : ControllerBase
    {
        private readonly IEngagementService _engagementService;

        public DepartmentsController(IEngagementService engagementService)
        {
            _engagementService = engagementService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_engagementService.FindAlLDepartments().ToList());
        }
        
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _engagementService.CreateDepartment(department);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditDepartment(Department department)
        {
            _engagementService.EditDepartment(department);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            _engagementService.DeleteDepartment(departmentId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignUserToDepartment(DepartmentAssignmentDto departmentAssignmentDto)
        {
            _engagementService.AssignUserToDepartment(departmentAssignmentDto.UserId, departmentAssignmentDto.DepartmentId);
            return Ok();
        }
    }
}