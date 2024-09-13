using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Controladores_2.Models;


namespace Web_API_Controladores_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // Representa La DB:
        private readonly DBContext _DBContext;

        // Constructor:
        public EmpleadoController(DBContext dbContext)
        {
            _DBContext = dbContext;
        }



        // **************** ENDPOINTS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<List<Empleado>> Get()
        {
            List<Empleado> Lista_Empleados = await _DBContext.Empleados.ToListAsync();

            return Lista_Empleados;
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<Empleado> Get(int id)
        {
            Empleado Objeto_Obtenido = await _DBContext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

            return Objeto_Obtenido;
        }




        // *******  ENPOINTS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {
            _DBContext.Add(empleado);
            await _DBContext.SaveChangesAsync();

            return Ok("Guardado Correctamente");
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleado empleado)
        {
            Empleado? Objeto_Obtenido = await _DBContext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

            if (Objeto_Obtenido != null)
            {
                Objeto_Obtenido.Nombre = empleado.Nombre;
                Objeto_Obtenido.Salaraio = empleado.Salaraio;
                Objeto_Obtenido.FechaNacimiento = empleado.FechaNacimiento;
                Objeto_Obtenido.Email = empleado.Email;

                // Actualizamos:
                _DBContext.Update(Objeto_Obtenido);
                await _DBContext.SaveChangesAsync();

                return Ok("Modificado Exitosamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Empleado? Objeto_Obtenido = await _DBContext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

            if (Objeto_Obtenido != null)
            {
                _DBContext.Remove(Objeto_Obtenido);
                await _DBContext.SaveChangesAsync();

                return Ok("Eliminado Correctamente.");
            }
            else
            {
                return NotFound("No Se Encontro El Registro.");
            }

        }


    }
}
