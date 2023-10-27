using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.MasterData;
using System.ComponentModel;

namespace HrisApp.Shared.Models.Employee
{
    public class EmployeeT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        //PERSONAL DETAILS
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public GenderT? Gender { get; set; }
        public int GenderId { get; set; } //FK
        public CivilStatusT? CivilStatus { get; set; }
        public int CivilStatusId { get; set; } //FK
        public ReligionT? Religion { get; set; }
        public int ReligionId { get; set; } //FK

        //CONTACT INFO
        //[Phone]
        //[Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = string.Empty;
        //[EmailAddress]
        public string Email { get; set; } = string.Empty;

        //EMERGENCY CONTACT
        //[Required]
        //[Display(Name = "Full Name")]
        public string EmerName {  get; set; } = string.Empty;
        public EmerRelationshipT? EmerRelationship { get; set; }
        public int EmerRelationshipId {  get; set; } //FK
        //[Required]
        //[Display(Name = "Address")]
        public string EmerAddress {  get; set; } = string.Empty;
        //[Required]
        //[Phone]
        //[Display(Name = "Mobile Number")]
        public string EmerMobNum {  get; set; } = string.Empty;

        //JOB DETAILS & MASTER DATA
        //[Required]
        public string EmployeeNo { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }

        public EmploymentStatusT? EmploymentStatus { get; set; }
        public int EmploymentStatusId { get; set; } //FK

        public AreaT? Area { get; set; }
        public int AreaId { get; set; } //FK

        public DivisionT? Division { get; set; }
        public int DivisionId { get; set; } //FK

        public DepartmentT? Department { get; set; }
        public int DepartmentId { get; set; } //FK

        public SectionT? Section { get; set; }
        public int SectionId { get; set; } //FK

        public PositionT? Position { get; set; }
        public int PositionId { get; set; } //FK

        public StatusT? Status { get; set; }
        public int StatusId { get; set; } //FK

        public InactiveStatusT? InactiveStatus { get; set; }
        public int InactiveStatusId { get; set; } //FK



    }
}
