using Microsoft.EntityFrameworkCore; //AGREGAR USING
using WebApiEscuela.Models;

namespace WebApiEscuela.Data
{
    public class DBEscuelaAPIContext: DbContext
    {
        //CORE siempre declarar el constructor de esta forma

        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options ):base (options) { }

        //DBSET con cada clase

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Especialidad> Especialidades { get; set; } 
        public DbSet<Profesor> Profesores { get; set; } 


    }
}
