using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(DawAppContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<User> GetAllAsQuerable()
        {
            return _table.AsNoTracking()
                .Include(user => user.Contract)
                .Include(user => user.Role)
                .Include(user => user.Department)
                .Include(user => user.Team)
                .Include(user => user.Projects)
                    .ThenInclude(up => up.Project);
        }

        public User FindByCredentials(string modelUsername, string modelPassword)
        {
            return _table.SingleOrDefault(user => user.Username == modelUsername
                                                  && user.Password == modelPassword);
        }
    }
}