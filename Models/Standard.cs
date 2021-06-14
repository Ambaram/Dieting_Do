using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dieting_Do.Models
{
    public class Standard
    {
        [Key]
        public int ID { get; set; }
        public string AnimalBreed { get; set; }
        public int Protein { get; set; } 
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Fibre { get; set; }
        public int St_BMI { get; set; }
        // Stabdard meal time difference in hours
        public int St_Meal_Time_Diff { get; set; }
        //Standard total calorie requirement
        public int Total_Cal { get; set; }
    }
}