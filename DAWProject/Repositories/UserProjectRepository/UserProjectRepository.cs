using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;
using DAWProject.Services.GenericService;

namespace DAWProject.Repositories.UserProjectRepository
{
    public class UserProjectRepository: GenericService<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(IGenericRepository<UserProject> repository) : base(repository)
        {
        }
    }
}