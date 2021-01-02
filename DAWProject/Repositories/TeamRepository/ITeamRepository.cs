using System;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.TeamRepository
{
    public interface ITeamRepository: IGenericRepository<Team>
    {
        Team FindByTeamLead(Guid userId);
    }
}