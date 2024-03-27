using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.MasterData
{
    public class UOMT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime? CreatedOn { get; set; } = DateTime.Now;
    }
}
