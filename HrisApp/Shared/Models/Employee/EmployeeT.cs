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
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string MiddleName { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public int? Height { get; set; }
        public int? Weight { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public GenderT? Gender { get; set; }
        [Required]
        public int GenderId { get; set; } //FK
        public CivilStatusT? CivilStatus { get; set; }
        [Required]
        public int CivilStatusId { get; set; } //FK
        public ReligionT? Religion { get; set; }
        public int ReligionId { get; set; } //FK

        //CONTACT INFO
        public string MobileNumber { get; set; } = string.Empty;
        //[EmailAddress]
        public string Email { get; set; } = string.Empty;

        //EMERGENCY CONTACT
        public string EmerName {  get; set; } = string.Empty;
        public EmerRelationshipT? EmerRelationship { get; set; }
        public int EmerRelationshipId {  get; set; } //FK
        public string EmerAddress {  get; set; } = string.Empty;
        public string EmerMobNum {  get; set; } = string.Empty;

        //JOB DETAILS & MASTER DATA
        [Required]
        public string EmployeeNo { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }

        public EmploymentStatusT? EmploymentStatus { get; set; }
        [Required]
        public int EmploymentStatusId { get; set; } //FK

        public AreaT? Area { get; set; }
        [Required]
        public int AreaId { get; set; } //FK

        public DivisionT? Division { get; set; }
        [Required]
        public int DivisionId { get; set; } //FK

        public DepartmentT? Department { get; set; }
        [Required]
        public int DepartmentId { get; set; } //FK

        public SectionT? Section { get; set; }
        [Required]
        public int SectionId { get; set; } //FK

        public PositionT? Position { get; set; }
        [Required]
        public int PositionId { get; set; } //FK

        public StatusT? Status { get; set; }
        [Required]
        public int StatusId { get; set; } //FK

        public InactiveStatusT? InactiveStatus { get; set; }
        [Required]
        public int InactiveStatusId { get; set; } //FK



    }
}
