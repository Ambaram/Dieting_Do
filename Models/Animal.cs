using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Animal
    {
        [Key]
        public int AminalID { get; set; }
        public string AnimalName { get; set; }
        
        public int AnimalWeight { get; set; }
        public int AnimalHeight { get; set; }
        [ForeignKey("Breed")]
        public int BreedID { get; set; }
        public virtual Breed Breed { get; set; }
    }
    public class AnimalDto
    {
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public int AnimalHeight { get; set; }
        public int AnimalWeight { get; set; }
        public string AnimalBreed { get; set; }
    }
}