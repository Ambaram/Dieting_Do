using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Dieting_Do.Models;

namespace Dieting_Do.Controllers
{
    public class AnimalDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Animals//AnimalsList
        [HttpGet]
        public IEnumerable<AnimalDto> AnimalsList()
        {
            List<Animal> Animals = db.Animals.ToList();
            List<AnimalDto> AnimalDtos = new List<AnimalDto>();
            Animals.ForEach(i => AnimalDtos.Add(new AnimalDto()
            {
                AnimalID = i.AminalID,
                AnimalName=i.AnimalName,
                AnimalHeight=i.AnimalHeight,
                AnimalWeight=i.AnimalWeight,
                AnimalBreed=i.Breed.AnimalBreed
            }));
            return AnimalDtos;
        }

        // GET: api/Animals/AnimalDetail/5
        [HttpGet]
        [ResponseType(typeof(Animal))]
        public  IHttpActionResult AnimalDetail(int id)
        {
            Animal Animal = db.Animals.Find(id);
            AnimalDto AnimalDto = new AnimalDto()
            {
                AnimalID = Animal.AnimalID,
                AnimalWeight = Animal.AnimalWeight,
                AnimalName=Animal.AnimalName,
                AnimalHeight=Animal.AnimalHeight

            }
            if (Animal == null)
            {
                return NotFound();
            }

            return Ok(AnimalDto);
        }

        // PUT: api/Animals/UpdateWeight/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateWeight(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.AminalID)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Animals/AddAnimal
        [ResponseType(typeof(Animal))]
        [HttpPost]
        public async Task<IHttpActionResult> PostAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animals.Add(animal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = animal.AminalID }, animal);
        }

        // DELETE: api/Animals/DeleteAnimal/5
        [ResponseType(typeof(Animal))]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteAnimal(int id)
        {
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animal);
            await db.SaveChangesAsync();

            return Ok(animal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animals.Count(e => e.AminalID == id) > 0;
        }
    }
}