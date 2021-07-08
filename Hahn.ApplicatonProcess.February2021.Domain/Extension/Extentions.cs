using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hahn.ApplicatonProcess.February2021.Domain.ViewModel.Dto;

namespace Hahn.ApplicatonProcess.February2021.Domain.Extension
{
    public static class Extentions
    {
        public static AssetDto AsDto(this Asset asset)
        {
            return new AssetDto(asset.ID, asset.AssetName, asset.EMailAdressOfDepartment, asset.Department, asset.CountryOfDepartment, asset.PurchaseDate, asset.Broken);
        }

        public static Asset ToAsset(this CreateAssetDto asset)
        {
            return new Asset()
            {
                ID = 1,
                AssetName = asset.AssetName,
                EMailAdressOfDepartment = asset.EMailAdressOfDepartment,
                Department = asset.Department,
                CountryOfDepartment = asset.CountryOfDepartment,
                PurchaseDate = asset.PurchaseDate,
                Broken = asset.Broken

            };

        }
    }
}
