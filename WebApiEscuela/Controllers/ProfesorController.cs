using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;
namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }    

        public ProfesorController(DBEscuelaAPIContext context)
        {
            this.Context = context;    
        }


        [HttpGet]
        public List<Profesor> Get()
        {
            //EF
            List<Profesor> profesores = Context.Profesores.ToList(); //trae a los profesores a la list profesores

            return profesores; // retornamos la lista 
        }


        [HttpGet("{id}")]

        public Profesor Get(int id)
        {
            //EF
            Profesor profesor = Context.Profesores.Find(id);

            return profesor;
        }



        [HttpPost]
        public ActionResult Post(Profesor profesor)
        {
            //USANDO EF-- memoria
            Context.Profesores.Add(profesor);

            //EF- Guardamos en la base
            Context.SaveChanges();

            return Ok(); // OK ES EL 200
        }


        [HttpPut("{id}")]
        public ActionResult Put (int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            //EF para modificar

            Context.Entry(profesor).State= EntityState.Modified;
            Context.SaveChanges();

            return NoContent(); //NOCONTEXT ES EL 204
        }

        [HttpDelete("{id}")]
        public ActionResult<Profesor> Delete (int id)
        {
            //EF
            var profesor = Context.Profesores.Find(id); 

            if (profesor == null)
            {
                return NotFound();
            }

            //EF
            Context.Profesores.Remove(profesor);
            Context.SaveChanges();

            return profesor;
        }

    }
}
