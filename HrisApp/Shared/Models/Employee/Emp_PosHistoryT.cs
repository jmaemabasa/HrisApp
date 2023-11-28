using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_PosHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int NewAreaId {  get; set; }
        public int NewDivisionId {  get; set; }
        public int NewDepartmentId {  get; set; }
        public int NewSectionId {  get; set; }
        public int NewPositionId {  get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public DateTime? DateModified { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
    }
}
