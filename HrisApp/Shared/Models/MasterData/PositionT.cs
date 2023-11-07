using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.MasterData
{
    public class PositionT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string PosCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DivisionId { get; set; } //FK
        public int DepartmentId { get; set; } //FK
        public int SectionId { get; set; } //FK
    }
}
