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

        public void CreateTeam(Team team)
        {
            _teamRepository.Create(team);
            _teamRepository.Save();
        }

        public void EditTeam(Team team)
        {
            _teamRepository.Update(team);
            _teamRepository.Save();
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

        public void CreateRole(Role role)
        {
            _roleRepository.Create(role);
            _roleRepository.Save();
        }

        public void EditRole(Role role)
        {
            _roleRepository.Update(role);
            _roleRepository.Save();
        }

        public void DeleteRole(Guid roleId)
        {
            var role = _roleRepository.FindById(roleId);
            _roleRepository.Delete(role);
            _roleRepository.Save();
        }
        
        public void AssignRoleToUser(Guid userId, Guid roleId)
        {
            var user = _userRepository.FindById(userId);
            user.RoleId = roleId;
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public IQueryable<Department> FindAlLDepartments()
        {
            return _departmentRepository.GetAllAsQuerable();
        }

        public void CreateDepartment(Department department)
        {
            _departmentRepository.Create(department);
            _departmentRepository.Save();
        }

        public void EditDepartment(Department department)
        {
            _departmentRepository.Update(department);
            _departmentRepository.Save();
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

        public IQueryable<Project> FindAllProjects()
        {
            return _projectRepository.GetAllAsQuerable();
        }

        public void CreateProject(Project project)
        {
            _projectRepository.Create(project);
            _projectRepository.Save();
        }

        public void EditProject(Project project)
        {
            _projectRepository.Update(project);
            _projectRepository.Save();
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