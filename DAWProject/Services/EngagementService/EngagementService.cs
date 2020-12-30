using System;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Repositories.DepartmentRepository;
using DAWProject.Repositories.ProjectRepository;
using DAWProject.Repositories.RoleRepository;
using DAWProject.Repositories.TeamRepository;
using DAWProject.Repositories.UserProjectRepository;
using DAWProject.Repositories.UserRepository;

namespace DAWProject.Services.EngagementService
{
    public class EngagementService: IEngagementService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;

        public EngagementService(ITeamRepository teamRepository, IRoleRepository roleRepository, IDepartmentRepository departmentRepository, IProjectRepository projectRepository, IUserRepository userRepository, IUserProjectRepository userProjectRepository)
        {
            _teamRepository = teamRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _userProjectRepository = userProjectRepository;
        }

        public IQueryable<Team> FindAllTeams()
        {
            return _teamRepository.GetAllAsQuerable();
        }

        public Team FindTeamById(Guid teamId)
        {
            return _teamRepository.FindById(teamId);
        }

        public void CreateTeam(TeamDto teamCreationDto)
        {
            throw new NotImplementedException();
        }

        public void EditTeam(TeamDto teamCreationDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Guid teamId)
        {
            var team = _teamRepository.FindById(teamId);
            _teamRepository.Delete(team);
            _teamRepository.Save();
        }

        public void AssignUserToTeam(Guid userId, Guid teamId)
        {
            var user = _userRepository.FindById(userId);
            user.TeamId = teamId;
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void AssignTeamLeadToTeam(Guid userId, Guid teamId)
        {
            AssignUserToTeam(userId, teamId);
            var team = _teamRepository.FindById(teamId);
            team.TeamLeaderId = userId;
            _teamRepository.Update(team);
            _teamRepository.Save();
        }

        public IQueryable<Role> FindAllRoles()
        {
            return _roleRepository.GetAllAsQuerable();
        }

        public void CreateRole(RoleDto roleCreationDto)
        {
            throw new NotImplementedException();
        }

        public void EditRole(RoleDto roleCreationDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(Guid roleId)
        {
            var role = _roleRepository.FindById(roleId);
            _roleRepository.Delete(role);
            _roleRepository.Save();
        }

        public IQueryable<Department> FindAlLDepartments()
        {
            return _departmentRepository.GetAllAsQuerable();
        }

        public void CreateDepartment(DepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }

        public void EditDepartment(DepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Guid departmentId)
        {
            var department = _departmentRepository.FindById(departmentId);
            _departmentRepository.Delete(department);
            _departmentRepository.Save();
        }

        public void AssignUserToDepartment(Guid userId, Guid departmentId)
        {
            var user = _userRepository.FindById(userId);
            user.DepartmentId = departmentId;
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public IQueryable<Project> GetAllProjects()
        {
            return _projectRepository.GetAllAsQuerable();
        }

        public void CreateProject(ProjectDto projectDto)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectDto projectDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(Guid projectId)
        {
            var project = _projectRepository.FindById(projectId);
            _projectRepository.Delete(project);
            _projectRepository.Save();
        }

        public void AssignUserToProject(Guid userId, Guid projectId)
        {
            var user = _userRepository.FindById(userId);
            var project = _projectRepository.FindById(projectId);
            
            var userProject = new UserProject
            {
                UserId = userId,
                ProjectId = projectId
            };

            _userProjectRepository.Create(userProject);
            _userProjectRepository.Save();
            
            user.Projects.Add(userProject);
            _userRepository.Update(user);
            _userRepository.Save();
            
            project.Users.Add(userProject);
            _projectRepository.Update(project);
            _projectRepository.Save();
        }
    }
}