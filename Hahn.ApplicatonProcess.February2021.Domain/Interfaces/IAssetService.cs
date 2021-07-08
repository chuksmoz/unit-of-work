using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicatonProcess.February2021.Domain.interfaces
{
    public interface IAssetService
    {
        Task<Tuple<ErrorResponse, Asset>> CreateAsset(CreateAssetDto asset);
        Task<IEnumerable<Asset>> GetAllAsset();
        Task<Asset> GetAssetById(int id);
        Task<Tuple<ErrorResponse, Asset>> UpdateAsset(int id, UpdateAssetDto asset);
        Task DeleteAsset(int id);
    }
}
