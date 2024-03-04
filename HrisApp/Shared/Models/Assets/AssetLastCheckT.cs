using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetLastCheckT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public AssetMasterT? MainAsset { get; set; }
        public int? MainAssetId { get; set; }

        public DateTime? LastCheckDate { get; set; } = DateTime.Now;

        public string Remarks { get; set; } = string.Empty;
    }
}