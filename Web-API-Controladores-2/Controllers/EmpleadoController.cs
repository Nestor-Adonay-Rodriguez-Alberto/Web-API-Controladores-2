using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Controladores_2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API_Controladores_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // REPRESENTA DB:
        private readonly DBContext _DBContext;

        // CONTRUCTOR:
        public EmpleadoController(DBContext dbContext)
        {
            _DBContext = dbContext;
        }

        // GET: api/<EmpleadoController>
        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<List<Empleado>> Get()
        {
            List<Empleado> Lista_Empleados = await _DBContext.Empleados.ToListAsync();

            return Lista_Empleados;
        }


        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpleadoController>
        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {
            _DBContext.Add(empleado);
            await _DBContext.SaveChangesAsync();

            return Ok("Guardado Correctamente");
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
