using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chubb_Api_Test.Models;
using DBServices.Context;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chubb_Api_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        /** Inyección de Dependecnia **/
        private IConfiguration _config;
        private readonly IEmpService _empService;
        public EmpleadosController(IEmpService empService, IConfiguration config)
        {
            _empService = empService;
            _config = config;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            string strDBConn = _config.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
            return _empService.GetEmpleados(strDBConn).ToArray();
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string strDBConn = _config.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
            //ViewResult view = new ViewResult();

            return _empService.ObtEmpleadoPorId(strDBConn, id).ToString();

        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public bool Post([FromBody] Empleado empleado)
        {
            string strDBConn = _config.GetSection("ConnectionStrings").GetSection("DBConnection").Value;

            return true;
            /*
            return _empService.InsEmpleado(model.Fotografia, model.Nombre, model.Apellido, model.PuestoId, model.FechaNacimiento, model.FechaContratacion,
                model.Direccion, model.Telefono, model.CorreoElectronico, model.EstadoId, strDBConn);*/
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
