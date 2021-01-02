using System;
using System.Collections.Generic;
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
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;

        public EngagementService(ITeamRepository teamRepository, IProjectRepository projectRepository, IUserRepository userRepository, IUserProjectRepository userProjectRepository)
        {
            _teamRepository = teamRepository;
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
            team.TeamLeader = _userRepository.FindById(userId);
            team.TeamLeaderId = userId;
            _teamRepository.Update(team);
            _teamRepository.Save();
        }

        public Team FindByTeamLeadId(Guid userId)
        {
            return _teamRepository.FindByTeamLead(userId);
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
            var project = _projectRepository.FindById(projectId);
            var userProject = new UserProject
            {
                UserId = userId,
                ProjectId = projectId
            };

            project.Users = new List<UserProject> {userProject};
            _projectRepository.Update(project);
            _projectRepository.Save();
        }
    }
}