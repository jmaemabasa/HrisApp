using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrisApp.Shared.Models.MasterData;
using HrisApp.Shared.Models.Employee;

namespace HrisApp.Shared.Models.Assets.Consumables
{
    public class Cons_TransactionT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Transact_Code { get; set; } = string.Empty;

        public string Transact_Type { get; set; } = string.Empty;

        public ConsumablesT? Consumable { get; set; }
        public int ConsumableId { get; set; }
        public string ConsumableCode { get; set; } = string.Empty;

        public EmployeeT? Employee { get; set; }
        public int? EmployeeId { get; set; }

        public DepartmentT? Department { get; set; }
        public int? DepartmentId { get; set; }

        public int Transact_Qty { get; set; }
        public int Total_Qty { get; set; }

        public DateTime? PurchasedDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PurchaseAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PricePerUOM { get; set; }

        public string InvoiceNo { get; set; } = string.Empty;
        public VendorT? Vendor { get; set; }
        public int? VendorId { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public EmployeeT? CreatedBy { get; set; }
        public int CreatedById { get; set; }
    }
}
