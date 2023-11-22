using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Shared.Models.Application
{
    public class ApplicantT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string App_VerifyId { get; set; } = string.Empty;
        public string App_PosApplied1 { get; set; } = string.Empty;
        public string App_PosApplied2 { get; set; } = string.Empty;
        public string App_PresSalary { get; set; } = string.Empty;
        public string App_ExpSalary { get; set; } = string.Empty;
        public string App_SourceApp { get; set; } = string.Empty;


        //PERSONAL BACKGROUND
        [Required]
        [Display(Name = "Last Name")]
        public string App_LastName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "First Name")]
        public string App_FirstName { get; set; } = string.Empty;
        public string App_MiddleName { get; set; } = string.Empty;
        public string App_Suffix { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Contact No.")]
        public string App_ContactNo {  get; set; } = string.Empty;
        [Required]
        [Display(Name = "Email")]
        public string App_Email {  get; set; } = string.Empty;
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? App_DOB { get; set; }
        [GreaterThanZero(ErrorMessage = "App_GenderId must be greater than 0.")]
        public int App_Age { get; set; }
        public GenderT? App_Gender { get; set; }
        [GreaterThanZero(ErrorMessage = "App_GenderId must be greater than 0.")]
        public int App_GenderId { get; set; } //FK
        public string App_Citizenship { get; set; } = string.Empty;
        public CivilStatusT? App_CivilStatus { get; set; }
        public int App_CivilStatusId { get; set; } //FK
        public ReligionT? App_Religion { get; set; }
        public int App_ReligionId { get; set; } //FK
        public int? App_Height { get; set; }
        public int? App_Weight { get; set; }
        public string App_TIN { get; set; } = string.Empty;
        public string App_SSS { get; set; } = string.Empty;
        public string App_PagIbig { get; set; } = string.Empty;
        public string App_Philhealth { get; set; } = string.Empty;

        //EMERGENCY CONTACT
        public string App_EmerName { get; set; } = string.Empty;
        public EmerRelationshipT? App_EmerRelationship { get; set; }
        public int App_EmerRelationshipId { get; set; } //FK
        public string App_EmerAddress { get; set; } = string.Empty;
        public string App_EmerMobNum { get; set; } = string.Empty;

        //FAMILY INFORMATION
        public string App_SpouseName { get; set; } = string.Empty;
        public string App_SpouseOccupation { get; set; } = string.Empty;
        public string App_FatherName { get; set; } = string.Empty;
        public string App_FatherOccupation { get; set; } = string.Empty;
        public string App_MotherName { get; set; } = string.Empty;
        public string App_MotherOccupation { get; set; } = string.Empty;

        public class GreaterThanZeroAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is int intValue && intValue > 0)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("The field must be greater than 0.");
            }
        }
    }
}
