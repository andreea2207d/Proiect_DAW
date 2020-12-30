using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.RoleRepository
{
    public class RoleRepository: GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}