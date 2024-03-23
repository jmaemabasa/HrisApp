using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string ReportingTo { get; set; } = string.Empty; //Sub POsition Code sa heads
        public string Status { get; set; } = string.Empty;
        public DateTime? ActiveDate { get; set; } //kanus a nagamit
        public DateTime? InActiveDate { get; set; } //kanus a na inactive
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public int AreaId { get; set; }
    }
}
