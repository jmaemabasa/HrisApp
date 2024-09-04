using HrisApp.Shared.Models.MasterData;
using HrisApp.Shared.Models.StaticData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_PosHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int NewAreaId { get; set; }
        public int NewDivisionId { get; set; }
        public int NewDepartmentId { get; set; }
        public int NewSectionId { get; set; }
        public int NewPositionId { get; set; }
        public string newPositionCode { get; set; } = string.Empty;

        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public DateTime? DateModified { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        public EmploymentStatusT? EmploymentStatus { get; set; }
        public int? EmploymentStatusId { get; set; }

        //public SubPositionT? SubPosition { get; set; }
        //public int? SubPositionId { get;set; }



        //public int NewSubPositionId { get; set}
        //public string NewSubPositionCode { get; set; } = string.Empty;
    }
}
