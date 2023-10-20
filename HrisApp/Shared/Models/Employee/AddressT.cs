using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Employee
{
    public class AddressT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;


        //current
        public string CurrentAdd { get; set; } = string.Empty;
        public string CurrentBrgy { get; set; } = string.Empty;
        public string CurrentCity { get; set; } = string.Empty;
        public string CurrentProvince { get; set; } = string.Empty;
        public string CurrentZipCode { get; set; } = string.Empty;
        public string PermanentCountry { get; set; } = string.Empty;


        //permanent
        public string PermanentAdd { get; set; } = string.Empty;
        public string PermanentBrgy { get; set; } = string.Empty;
        public string PermanentCity { get; set; } = string.Empty;
        public string PermanentProvince { get; set; } = string.Empty;
        public string PermanentZipCode { get; set; } = string.Empty;
        public string CurrentCountry { get; set; } = string.Empty;

    }
}
