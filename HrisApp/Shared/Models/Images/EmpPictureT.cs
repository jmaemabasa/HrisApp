﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.MasterData;

namespace HrisApp.Shared.Models.Images
{
    public class EmpPictureT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string EmployeeNo { get; set; } = string.Empty;
        public string Img_Filename { get; set; } = string.Empty;
        public string Img_Contenttype { get; set; } = string.Empty;
        public string Img_URL { get; set; } = string.Empty;
        public DivisionT? Division { get; set; }
        public int DivisionId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DepartmentT? Department { get; set; }
        public int DepartmentId { get; set; }
        public byte[]? Img_Data { get; set; }
        public DateTime Img_Date { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
    }
}
