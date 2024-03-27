using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrisApp.Shared.Models.MasterData;
using HrisApp.Shared.Models.Employee;

namespace HrisApp.Shared.Models.Assets.Consumables
{
    public class ConsumablesT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string JMCode { get; set; } = string.Empty;
        public string AssetCode { get; set; } = string.Empty;
        public AssetTypesT? Type { get; set; }
        public int TypeId { get; set; }

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public AreaT? Area { get; set; }
        public int AreaId { get; set; }

        public string Cons_Name { get; set; } = string.Empty;
        public string Cons_Desc { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;
        public UOMT? UOM { get; set; }
        public int? UOMId { get; set; }

        public DateTime? PurchaseDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PricePerUOM { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPurchaseAmount { get; set; }


        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public EmployeeT? CreatedBy { get; set; }
        public int? CreatedById { get; set; }

    }
}
