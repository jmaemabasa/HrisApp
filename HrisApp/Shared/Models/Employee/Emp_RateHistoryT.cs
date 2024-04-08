using HrisApp.Shared.Models.MasterData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_RateHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public EmployeeT? Employee { get; set; }
        public int EmployeeId { get; set; }

        public string Rate { get; set; } = string.Empty;

        public DateTime? DateStarted { get; set; } = DateTime.Now;
        public DateTime? DateEnded { get; set; }
        public DateTime? DateModified { get; set; }

        public DateTime? EffectivityDate { get; set; }
        public DateTime? EffEndDate { get; set; }


        public SubPositionT? Position { get; set; }
        public int PositionId { get; set; }

    }
}
