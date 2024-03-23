using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrisApp.Shared.Models.StaticData;
using HrisApp.Shared.Models.Employee;
using HrisApp.Shared.Models.MasterData;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetMasterT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string JMCode { get; set; } = string.Empty;
        public string AssetCode { get; set; } = string.Empty;
        public string WorksationName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AssetTypesT? Type { get; set; }
        public int TypeId { get; set; }

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public AreaT? Area { get; set; }
        public int AreaId { get; set; }

        public int Quantity { get; set; } = 1;
        public string Barcode { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public string DeviceID { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public string Processor { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string StorageType { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public DateTime? PurchaseDate { get; set; }
        public string PurchaseAmount { get; set; } = string.Empty;
        public string EUF { get; set; } = string.Empty;

        public EmployeeT? Employee { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? AssignedDateReleased { get; set; } = DateTime.Now;
        public DateTime? AssignedDateToReturn { get; set; }

        public AssetStatusT? AssetStatus { get; set; }
        public int AssetStatusId { get; set; }

        public DateTime? InUseStatusDate { get; set; }
        public DateTime? StatusDate { get; set; }

        public string AssetNo { get; set; } = string.Empty;
        public string Asset { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string UsernameAdmin { get; set; } = string.Empty;
        public string PasswordAdmin { get; set; } = string.Empty;
        public string ClientIP { get; set; } = string.Empty;
        public DateTime? LastCheckDate { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public EmployeeT? CreatedBy { get; set; }
        public int? CreatedById { get; set; }
    }
}