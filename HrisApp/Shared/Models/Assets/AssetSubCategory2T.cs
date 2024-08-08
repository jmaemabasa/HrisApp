using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetSubCategory2T
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ASubCat2_Code { get; set; } = string.Empty;
        public string ASubCat2_Name { get; set; } = string.Empty;
        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }
        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }
    }
}
