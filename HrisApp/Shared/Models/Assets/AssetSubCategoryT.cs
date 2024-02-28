using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetSubCategoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ASubCat_Code { get; set; } = string.Empty;
        public string ASubCat_Name { get; set; } = string.Empty;
        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
