using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Assets
{
    public class MainRemarksT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string MainAssetCode { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public string VerifyId { get; set; } = string.Empty;
    }
}
