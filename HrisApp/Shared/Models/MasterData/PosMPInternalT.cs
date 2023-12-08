using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.MasterData
{
    public class PosMPInternalT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Internal_Name { get; set; } = string.Empty;
        public string Internal_VerifyId { get; set; } = string.Empty;
    }
}
