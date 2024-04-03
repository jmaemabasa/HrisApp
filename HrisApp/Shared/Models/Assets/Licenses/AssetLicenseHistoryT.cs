using HrisApp.Shared.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Assets.Licenses
{
    public class AssetLicenseHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public AssetLicenseT? AssetLicense { get; set; }
        public int AssetLicenseId { get; set; }

        public AssetMasterT? MainAsset { get; set; }
        public int MainAssetId { get; set; }

        public EmployeeT? Employee { get; set; }
        public int? EmployeeId { get; set; }

        public DateTime? AssignedDateMainAss { get; set; }
        public DateTime? UnassignedDateMainAss { get; set; }
    }
}
