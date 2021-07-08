using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Domain.ViewModel
{
    public class Dto
    {
        public record AssetDto(int ID, string AssetName, string EMailAdressOfDepartment, Department Department, string CountryOfDepartment, DateTimeOffset PurchaseDate, bool? Broken);
        public record CreateAssetDto(string AssetName, string EMailAdressOfDepartment, Department Department, string CountryOfDepartment, DateTimeOffset PurchaseDate, bool? Broken);
        public record UpdateAssetDto(string AssetName, string EMailAdressOfDepartment, Department Department, string CountryOfDepartment, DateTimeOffset PurchaseDate, bool? Broken);
    }
}
