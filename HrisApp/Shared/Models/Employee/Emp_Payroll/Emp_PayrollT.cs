using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.StaticData;
using HrisApp.Shared.Models.MasterData;

namespace HrisApp.Shared.Models.Emp_Payroll
{
    public class Emp_PayrollT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        [RegularExpression("^[0-9]{1,12}$", ErrorMessage = "Value must be digits only")]
        public string Rate { get; set; } = string.Empty;
        public RateTypeT? RateType { get; set; }
        public int RateTypeId { get; set; }
        public string Salary { get; set; } = string.Empty; //   

        public CashBondT? Cashbond { get; set; }
        public int CashbondId { get; set; }

        public string MealAllowance { get; set; } = string.Empty;
        public string BiometricID { get; set; } = string.Empty;

        [RegularExpression("^[0-9]+$", ErrorMessage = "Value must be digits only")]
        public string BankAcc { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Value must be exactly 12 digits")]
        public string TINNum { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Value must be exactly 12 digits")]
        public string SSSNum { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Value must be exactly 12 digits")]
        public string PhilHealthNum { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Value must be exactly 12 digits")]
        public string HDMFNum { get; set; } = string.Empty;

        public RestDayT? RestDay { get; set; }
        public int RestDayId { get; set; }

        public ScheduleTypeT? ScheduleType { get; set; }
        public int ScheduleTypeId { get; set; } 

        public string Paytype { get; set; } = string.Empty;
    }
}
