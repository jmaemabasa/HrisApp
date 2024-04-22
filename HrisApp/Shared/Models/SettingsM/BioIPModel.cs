using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.SettingsM
{
    public class BioIPModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string IP_Address { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Device_Info { get; set; } = string.Empty;
        public int Machine { get; set; }
        public DateTime Machine_Reg { get; set; }
        public bool Is_AM { get; set; }
        public bool Is_PM { get; set; }
        public string Status { get; set; } = string.Empty;

        public string Res_Status { get; set; } = string.Empty; //Open, Close, Error

    }
}
