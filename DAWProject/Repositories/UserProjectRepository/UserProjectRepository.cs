using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserProjectRepository
{
    public class UserProjectRepository : GenericRepository<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}