using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(DawAppContext dbContext) : base(dbContext)
        {
        }

        public User FindByCredentials(string modelUsername, string modelPassword)
        {
            return _table.SingleOrDefault(user => user.Username == modelUsername
                                                  && user.Password == modelPassword);
        }
    }
}