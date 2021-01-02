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
    public class DepartmentsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public DepartmentsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_organizationService.FindAlLDepartments().ToList());
        }
        
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _organizationService.CreateDepartment(department);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditDepartment(Department department)
        {
            _organizationService.EditDepartment(department);
            return Ok();
        }
        
        [HttpDelete("{departmentId}")]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            _organizationService.DeleteDepartment(departmentId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignUserToDepartment(DepartmentAssignmentDto departmentAssignmentDto)
        {
            _organizationService.AssignUserToDepartment(departmentAssignmentDto.UserId, departmentAssignmentDto.DepartmentId);
            return Ok();
        }
    }
}