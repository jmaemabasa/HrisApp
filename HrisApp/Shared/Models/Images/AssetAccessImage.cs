using HrisApp.Shared.Models.Assets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Images
{
    public class AssetAccessImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string AssetCode { get; set; } = string.Empty;
        public string Img_Filename { get; set; } = string.Empty;
        public string Img_Contenttype { get; set; } = string.Empty;
        public string Img_URL { get; set; } = string.Empty;

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public byte[]? Img_Data { get; set; }
        public DateTime Img_Date { get; set; }
        public string JM_Code { get; set; } = string.Empty;
    }
}