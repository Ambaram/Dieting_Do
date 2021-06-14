using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class bodymassindex
    {
        [Key]
        public int ID { get; set; }
        public int BMI { get; set; }

        [ForeignKey("Animal")]
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
    }

}