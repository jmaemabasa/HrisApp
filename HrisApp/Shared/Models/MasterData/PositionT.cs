﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.MasterData
{
    public class PositionT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string PosCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DivisionId { get; set; } //FK
        public int DepartmentId { get; set; } //FK
        public int SectionId { get; set; } //FK
        public int AreaId {  get; set; } // FK
        public string JobSummary { get; set; } = string.Empty;
        public string PosEducation { get; set; } = string.Empty;
        public string WorkExperience { get; set; } = string.Empty;
        public string OtherCompetencies { get; set; } = string.Empty;
        public string Restrictions { get; set; } = string.Empty;
        public int Plantilla { get; set; } //FK
        public string PositionType { get; set; } = string.Empty;
        public string TemporaryDuration { get; set; } = string.Empty;
        //public ManpowerInternalT? ManpowerInternal {  get; set; }
        //public int ManpowerInternalId { get; set; }
        //public ManpowerExternalT? ManpowerExternal { get; set; }
        //public int ManpowerExternalId { get; set; }
        public string VerifyId { get; set; } = string.Empty;
    }
}
