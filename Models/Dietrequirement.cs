using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Dietrequirement
    {
        [Key]
        public int ID { get; set; }
        public int Protein {get; set;}
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Fibre { get; set; }
        [ForeignKey("Animal")]
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
    }
}