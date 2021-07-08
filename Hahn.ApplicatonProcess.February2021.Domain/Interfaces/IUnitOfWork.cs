using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Domain.interfaces
{
    public interface IUnitOfWork
    {
        IAssetRepository Assets { get; }

        Task SaveAsync();
    }
}
