using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Domain.interfaces
{
    public interface ICountryValidatorService
    {
        Task<bool> ValidateCountryByName(string name);
    }
}
