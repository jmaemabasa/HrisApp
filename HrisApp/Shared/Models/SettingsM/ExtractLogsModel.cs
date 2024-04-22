using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.SettingsM
{
    public class ExtractLogsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int EmployeeUserId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Is_Start { get; set; }
        public DateTime Date_Start { get; set; }
        public DateTime Date_Stop { get; set; }
        public DateTime Date_Create { get; set; }
        public string Status { get; set; } = string.Empty;

        public DateTime Date_Extract { get; set; }

        public bool Is_Active { get; set; }
    }
}
