using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrisApp.Shared.Models.Employee;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetMasterHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public AssetMasterT? MainAsset { get; set; }
        public int MainAssetId { get; set; }
        public string MainAssetCode { get; set; } = string.Empty;

        public EmployeeT? Employee { get; set; }
        public int EmployeeId { get; set; }

        public DateTime? AssignedDateReleased { get; set; }
        public DateTime? AssignedDateToReturn { get; set; }
        public DateTime? EndDate { get; set; }
    }
}