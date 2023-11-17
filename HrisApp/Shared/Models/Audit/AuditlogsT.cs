using HrisApp.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Audit
{
    public class AuditlogsT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public UserMasterT? User { get; set; } //FK
        public int UserId { get; set; } 
        public string Action { get; set; } = string.Empty; 
        public string Type { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
    }
}
