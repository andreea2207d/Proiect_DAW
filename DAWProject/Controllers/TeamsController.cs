using System;
using System.Collections.Generic;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.EngagementService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IEngagementService _engagementService;

        public TeamsController(IEngagementService engagementService)
        {
            _engagementService = engagementService;
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            return Ok(_engagementService.FindAllTeams().ToList());
        }
        
        [HttpGet("id")]
        public IActionResult GetTeamById(Guid teamId)
        {
            return Ok(_engagementService.FindTeamById(teamId));
        }
        
        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            _engagementService.CreateTeam(team);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditTeam(Team team)
        {
            _engagementService.EditTeam(team);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(Guid teamId)
        {
            _engagementService.DeleteTeam(teamId);
            return Ok();
        }
        
        [HttpPost("assign/user")]
        public IActionResult AssignUserToTeam(TeamAssignmentDto teamAssignmentDto)
        {
            _engagementService.AssignUserToTeam(teamAssignmentDto.UserId,
                teamAssignmentDto.TeamId);
            return Ok();
        }
        
        [HttpPost("assign/teamleader")]
        public IActionResult AssignTeamLeaderToTeam(TeamAssignmentDto teamAssignmentDto)
        {
            _engagementService.AssignTeamLeadToTeam(teamAssignmentDto.UserId,
                teamAssignmentDto.TeamId);
            return Ok();
        }
    }
}