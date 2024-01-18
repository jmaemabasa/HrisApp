using HrisApp.Shared.Models.MasterData;
using HrisApp.Shared.Models.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.DummyModel
{
    public class PayrollDummy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        public decimal Rate { get; set; } = 0M;
        public string BiometricID { get; set; } = string.Empty;


    }
}
