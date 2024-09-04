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

        //public string PosCode { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;

        public string Emp_VerifyId { get; set; } = string.Empty; //employee
        public string ReportingTo { get; set; } = string.Empty; //Sub POsition Code sa heads
        public string Status { get; set; } = string.Empty;
        public DateTime? ActiveDate { get; set; } //kanus a nagamit
        public DateTime? VacantDate { get; set; } //kanus a na vacant
        public DivisionT? Division { get; set; }
        public int DivisionId { get; set; }
        public DepartmentT? Department { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public AreaT? Area { get; set; }
        public int AreaId { get; set; }

        public DateTime? DateInactive { get; set; } //kanus a na deactive
        public DateTime? DateCreated { get; set; } = DateTime.Now; //when na create ang position

        public PositionT? Position { get; set; }
        public int PositionId { get; set; }
    }
}