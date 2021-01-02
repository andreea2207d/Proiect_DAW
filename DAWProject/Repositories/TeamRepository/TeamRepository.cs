using System;
using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.TeamRepository
{
    public class TeamRepository: GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(DawAppContext dbContext) : base(dbContext)
        {
        }

        public Team FindByTeamLead(Guid userId)
        {
            return _table.SingleOrDefault(team => team.TeamLeaderId.Equals(userId));
        }
    }
}