﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Application.App_Family
{
    public class App_SiblingT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string App_VerifyId { get; set; } = string.Empty;
        public string App_SiblingName { get; set; } = string.Empty;
        public string App_SiblingOccupation { get; set; } = string.Empty;
    }
}
