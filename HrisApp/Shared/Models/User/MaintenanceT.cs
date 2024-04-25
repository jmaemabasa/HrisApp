using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.User
{
    public class MaintenanceT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public bool IsMaintain { get; set; }
        public string Desc { get; set; } = string.Empty;
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
