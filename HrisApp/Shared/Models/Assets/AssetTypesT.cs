using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetTypesT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string AType_Code { get; set; } = string.Empty;
        public string AType_Name { get; set; } = string.Empty;
    }
}
