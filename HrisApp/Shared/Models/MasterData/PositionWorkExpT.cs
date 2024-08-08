using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.MasterData
{
    public class PositionWorkExpT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string PosCode { get; set; } = string.Empty;
        public string ExpName { get; set; } = string.Empty;
        public string VerifyId { get; set; } = string.Empty;
    }
}
