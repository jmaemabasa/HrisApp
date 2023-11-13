using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_AddressT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;


        //current
        [Required]
        [Display(Name = "Address")]
        public string CurrentAdd { get; set; } = string.Empty;
        //[Required]
        //[Display(Name = "Brgy")]
        public string CurrentBrgy { get; set; } = string.Empty;
        [Required]
        [Display(Name = "City")]
        public string CurrentCity { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Province")]
        public string CurrentProvince { get; set; } = string.Empty;
        [Required]
        [Display(Name = "ZipCode")]
        public string CurrentZipCode { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Country")]
        public string PermanentCountry { get; set; } = string.Empty;


        //permanent
        [Required]
        [Display(Name = "Address")]
        public string PermanentAdd { get; set; } = string.Empty;
        //[Required]
        //[Display(Name = "Brgy")]
        public string PermanentBrgy { get; set; } = string.Empty;
        [Required]
        [Display(Name = "City")]
        public string PermanentCity { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Province")]
        public string PermanentProvince { get; set; } = string.Empty;
        [Required]
        [Display(Name = "ZipCode")]
        public string PermanentZipCode { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Country")]
        public string CurrentCountry { get; set; } = string.Empty;

    }
}
