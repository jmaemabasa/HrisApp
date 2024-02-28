using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetCategoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ACat_Code { get; set; } = string.Empty;
        public string ACat_Name { get; set; } = string.Empty;
    }
}
