using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Helpers;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.EngagementService;
using DAWProject.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEngagementService _engagementService;

        public UsersController(IUserService userService, IEngagementService engagementService)
        {
            _userService = userService;
            _engagementService = engagementService;
        }

        [HttpPost("authentificate")]
        public IActionResult Authentificate(UserRequestDTO user)
        {
            var result = _userService.Authentificate(user);

            if(result == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers().ToList();
            var result = new List<UserDto>();
            foreach (var user in users)
            {
                var isTeamLeader = _engagementService.FindByTeamLeadId(user.Id) != null;
                result.Add(new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Role = user.Role?.Designation,
                    Team = user.Team?.Name,
                    Department = user.Department?.Name,
                    IsTeamLeader = isTeamLeader,
                    Projects = user.Projects?.Select(up => up.Project.Name).ToList()
                });
            }
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateUser(UserCreationDto userCreationDto)
        {
            _userService.CreateUser(userCreationDto);
            return Ok();
        }

    }

    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Contract Contract { get; set; }
        public string Role { get; set; }
        public string Team { get; set; }
        public bool IsTeamLeader { get; set; }
        public string Department { get; set; }
        public List<string> Projects { get; set; }
    }
}
