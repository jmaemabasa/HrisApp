using HrisApp.Shared.Models.Assets.Licenses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Assets
{
    public class MainAssetLicensesT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public AssetMasterT? AssetMaster { get; set; }
        public int AssetMasterId { get; set; }

        public string AssetMasterCode { get; set; } = string.Empty;

        public AssetLicenseT? AssetLicense { get; set; }
        public int AssetLicenseId { get; set; }

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public DateTime? DateUsed { get; set; }
        public DateTime? DateStatusChanged { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
    }
}
