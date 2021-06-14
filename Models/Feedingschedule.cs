using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dieting_Do.Models
{
    public class Feedingschedule
    {
        [Key]
        public int ID { get; set; }
        //Meal time difference in hours.
        public int Meal_Time_Diff { get; set; }
        [ForeignKey("Animal")]
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
    }
}