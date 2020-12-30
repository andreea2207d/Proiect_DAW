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

        IQueryable<Role> FindAllRoles();
        void CreateRole(Role role);
        void EditRole(Role role);
        void DeleteRole(Guid roleId);
        void AssignRoleToUser(Guid userId, Guid roleId);
        
        IQueryable<Department> FindAlLDepartments();
        void CreateDepartment(Department department);
        void EditDepartment(Department department);
        void DeleteDepartment(Guid departmentId);
        void AssignUserToDepartment(Guid userId, Guid departmentId);
        
        IQueryable<Project> FindAllProjects();
        void CreateProject(Project project);
        void EditProject(Project project);
        void DeleteProject(Guid projectId);
        void AssignUserToProject(Guid userId, Guid projectId);
    }
}