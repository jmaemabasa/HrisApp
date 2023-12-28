using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_LeaveCreditT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        public int EL { get; set; }
        public int Left_EL { get; set; }
        public int ML { get; set; }
        public int Left_ML { get; set; }
        public int PL { get; set; }
        public int Left_PL { get; set; }
        public int SL { get; set; }
        public int Left_SL { get; set; }
        public int VL { get; set; }
        public int Left_VL { get; set; }
        public int OL { get; set; }
        public int Left_OL { get; set; }
    }
}
