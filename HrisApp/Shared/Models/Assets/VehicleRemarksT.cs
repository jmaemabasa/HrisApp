using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Assets
{
    public class VehicleRemarksT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string VhcAssetCode { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public string VerifyId { get; set; } = string.Empty;
    }
}
