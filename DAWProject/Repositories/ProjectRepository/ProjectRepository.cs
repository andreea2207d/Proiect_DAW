using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.ProjectRepository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}