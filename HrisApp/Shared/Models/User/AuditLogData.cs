using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.User
{
    public class AuditLogData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public UserMasterT? User { get; set; } //FK
        public int UserId { get; set; } //id sa user pra sa log
        public string Action { get; set; } = string.Empty; //action like create update delete
        public string FullName { get; set; } = string.Empty; //action like create update delete
        public string TableName { get; set; } = string.Empty; //name sa table
        public string BeforeUpdate { get; set; } = string.Empty; //id sa row
        public string AddInfo { get; set; } = string.Empty; //comments/information
        public DateTime? Date { get; set; }
    }
}
