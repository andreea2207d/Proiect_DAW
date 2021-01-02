using System;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;

namespace DAWProject.Services.EngagementService
{
    public interface IEngagementService
    {
        IQueryable<Team> FindAllTeams();
        Team FindTeamById(Guid teamId);
        void CreateTeam(Team team);
        void EditTeam(Team team);
        void DeleteTeam(Guid teamId);
        void AssignUserToTeam(Guid userId, Guid teamId);
        void AssignTeamLeadToTeam(Guid userId, Guid teamId);
        
        IQueryable<Project> FindAllProjects();
        void CreateProject(Project project);
        void EditProject(Project project);
        void DeleteProject(Guid projectId);
        void AssignUserToProject(Guid userId, Guid projectId);
        Team FindByTeamLeadId(Guid userId);
    }
}