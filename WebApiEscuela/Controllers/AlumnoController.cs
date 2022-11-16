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
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }

        public AlumnoController(DBEscuelaAPIContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public List<Alumno> Get()
        {
            //EF
            List<Alumno> alumnos = Context.Alumnos.ToList(); //trae a los profesores a la list profesores

            return alumnos; // retornamos la lista 
        }




        [HttpGet("{id}")]

        public Alumno Get(int id)
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);

            return alumno;
        }

        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            //USANDO EF-- memoria
            Context.Alumnos.Add(alumno);

            //EF- Guardamos en la base
            Context.SaveChanges();

            return Ok(); // OK ES EL 200
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            //EF para modificar

            Context.Entry(alumno).State= EntityState.Modified;
            Context.SaveChanges();

            return NoContent(); //NOCONTEXT ES EL 204
        }

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            //EF
            var alumno = Context.Alumnos.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            //EF
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return alumno;
        }


    }
}
