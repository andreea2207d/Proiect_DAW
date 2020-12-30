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
        void CreateTeam(TeamDto teamCreationDto);
        void EditTeam(TeamDto teamCreationDto);
        void DeleteTeam(Guid teamId);
        void AssignUserToTeam(Guid userId, Guid teamId);
        void AssignTeamLeadToTeam(Guid userId, Guid teamId);

        IQueryable<Role> FindAllRoles();
        void CreateRole(RoleDto roleCreationDto);
        void EditRole(RoleDto roleCreationDto);
        void DeleteRole(Guid roleId);
        
        IQueryable<Department> FindAlLDepartments();
        void CreateDepartment(DepartmentDto departmentDto);
        void EditDepartment(DepartmentDto departmentDto);
        void DeleteDepartment(Guid departmentId);
        void AssignUserToDepartment(Guid userId, Guid departmentId);
        
        IQueryable<Project> GetAllProjects();
        void CreateProject(ProjectDto projectDto);
        void EditProject(ProjectDto projectDto);
        void DeleteProject(Guid projectId);
        void AssignUserToProject(Guid userId, Guid projectId);
    }
}