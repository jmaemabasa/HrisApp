using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Notification
{
    public class NotificationT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_id { get; set; } = string.Empty;
        public string Table { get; set; } = string.Empty;
        public DateTime? InsertedDate { get; set; }
    }
}
