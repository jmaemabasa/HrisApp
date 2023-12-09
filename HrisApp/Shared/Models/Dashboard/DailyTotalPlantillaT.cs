using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Dashboard
{
    public class DailyTotalPlantillaT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int TotalPlantilla { get; set; }
        public DateTime Date { get; set; }
    }
}
