using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrisApp.Shared.Models.StaticData;
using HrisApp.Shared.Models.Employee;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetAccessoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string JMCode { get; set; } = string.Empty;
        public string AssetCode { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AssetTypesT? Type { get; set; }
        public int TypeId { get; set; }

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public AssetStatusT? AssetStatus { get; set; }
        public int AssetStatusId { get; set; } = 2;

        public int Quantity { get; set; } = 1;
        public string Barcode { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public DateTime? PurchaseDate { get; set; }
        public string PurchaseAmount { get; set; } = string.Empty;
        public DateTime? InUseStatusDate { get; set; }
        public DateTime? StatusDate { get; set; }

        public string EUF { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;

        public DateTime? LastCheckDate { get; set; } = DateTime.Now;

        public AssetMasterT? MainAsset { get; set; }
        public int? MainAssetId { get; set; }
        public DateTime? MainAssetDateUpdated { get; set; }


        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public EmployeeT? CreatedBy { get; set; }
        public int? CreatedById { get; set; }
    }
}