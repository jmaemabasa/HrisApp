using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetAccessHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public AssetAccessoryT? AssetAccessory { get; set; }
        public int AssetAccessoryId { get; set; }

        public AssetMasterT? MainAsset { get; set; }
        public int MainAssetId { get; set; }

        public DateTime? AssignedDateMainAss { get; set; }
        public DateTime? UnassignedDateMainAss { get; set; }
    }
}