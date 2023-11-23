using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Application.App_ProfBackground
{
    public class App_ProfBackgroundT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string App_VerifyId { get; set; } = string.Empty;
        public DateTime? App_DateFrom { get; set; }
        public DateTime? App_DateTo { get; set; }
        public string App_CompanyName { get; set; } = string.Empty;
        public string App_Position { get; set; } = string.Empty;
        public string App_BasicSalary { get; set; } = string.Empty;
        public string App_RSLeaving { get; set; } = string.Empty;
    }
}
