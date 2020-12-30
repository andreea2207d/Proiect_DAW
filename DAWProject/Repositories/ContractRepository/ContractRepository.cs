using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.ContractRepository
{
    public class ContractRepository: GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}