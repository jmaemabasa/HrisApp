using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Application
{
    public class App_SelfDeclarationT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string App_VerifyId { get; set; } = string.Empty;

        public string Q1Ans { get; set; } = string.Empty;
        public string Q1Dtls { get; set; } = string.Empty;

        public string Q2Ans { get; set; } = string.Empty;
        public string Q2Dtls { get; set; } = string.Empty;

        public string Q3Ans { get; set;} = string.Empty;
        public string Q3Dtls { get; set ; } = string.Empty;

        public string Q4Ans { get;set; } = string.Empty;
        public string Q4Dtls { get;set; } = string.Empty;

        public string Q5Ans { get; set; } = string.Empty;
        public string Q5Dtls { get; set;} = string.Empty;

        public string Q6Ans { get; set; } = string.Empty;
        public string Q6Dtls { get; set; } = string.Empty;

        public string Q7Ans { get; set; } = string.Empty;
        public string Q7Dtls { get;set;} = string.Empty;

        public string Q8Ans { get;set ;} = string.Empty;
        public string Q8Dtls { get; set; } = string.Empty;
    }
}
