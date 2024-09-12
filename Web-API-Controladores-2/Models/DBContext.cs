using Microsoft.EntityFrameworkCore;

namespace Web_API_Controladores_2.Models
{
    public class DBContext : DbContext 
    {
        // CONSTRUCTOR:
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }


        // Tablas a Mapear en DB:
        public DbSet<Empleado> Empleados { get; set; }
    }
}
