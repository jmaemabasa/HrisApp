using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.MasterData
{
    public class SubPositionT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string SubPosCode { get; set; } = string.Empty;
        public string PosCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Emp_VerifyId { get; set; } = string.Empty; //employee
        public string Status { get; set; } = string.Empty;
        public DateTime? ActiveDate { get; set; } //kanus a nagamit
        public DateTime? InActiveDate { get; set; } //kanus a na inactive
    }
}
