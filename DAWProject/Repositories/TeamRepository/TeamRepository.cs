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
    }
}