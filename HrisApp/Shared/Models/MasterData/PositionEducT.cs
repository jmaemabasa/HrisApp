using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.MasterData
{
    public class PositionEducT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string PosCode { get; set; } = string.Empty;
        public string EducName { get; set; } = string.Empty;
        public string VerifyId { get; set; } = string.Empty;
    }
}
