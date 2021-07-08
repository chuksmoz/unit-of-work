using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using System.Threading.Tasks;



namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}