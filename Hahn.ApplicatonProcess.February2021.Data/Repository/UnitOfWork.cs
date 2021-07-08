using Hahn.ApplicatonProcess.February2021.Domain.interfaces;
using System;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IAssetRepository Assets { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context
        )
        {
            _context = context;

            Assets = new AssetRepository(_context);
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
