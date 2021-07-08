using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using System;


namespace Hahn.ApplicatonProcess.February2021.Domain.Entities
{
    public class Asset
    {
        public Asset()
        {
            this.Broken = false;
        }
        public int ID { get; set; }
        public string AssetName { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public bool? Broken { get; set; }
    }
}
