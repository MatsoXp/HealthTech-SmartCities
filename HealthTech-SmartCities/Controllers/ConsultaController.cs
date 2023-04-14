using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repositories;
using HealthTech_SmartCities.Repository;
using HealthTech_SmartCities.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthTech_SmartCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private readonly ConsultaRepository consultaRepository;

        public ConsultaController(DataBaseContext context)
        {
            consultaRepository = new ConsultaRepository(context);
        }

        // GET: api/<ConsultaController>
        [HttpGet]
        public ActionResult<List<ConsultaModel>> Get()
        {
            var lista = consultaRepository.FindAll();
            return Ok(lista);
        }

        // GET api/<ConsultaController>/5
        [HttpGet("{id:int}")]
        public ActionResult<ConsultaModel> Get([FromRoute] int id)
        {
            try
            {
                var consultaModel = consultaRepository.FindById(id);
                if (consultaModel != null)
                {
                    return Ok(consultaModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ConsultaController>
        [HttpPost]
        public IActionResult Insert([FromBody] ConsultaModel consulta)
        {
            var newConsulta = new ConsultaModel
            {
                DataHora = consulta.DataHora,
                Descricao = consulta.Descricao,
                MedicoId = consulta.MedicoId,
                UsuarioId = consulta.UsuarioId,
            };
            consultaRepository.Insert(newConsulta);
            return Ok(newConsulta);

        }



        // PUT api/<ConsultaController>/5
        [HttpPut("{id:int}")]
        public ActionResult<ConsultaModel> Put([FromRoute] int id, [FromBody] ConsultaModel consultaModel)
        {
            if (consultaModel.ConsultaId != id)
            {
                return NotFound();
            }
            else
            {
                consultaRepository.Update(consultaModel);
                return NoContent();
            }


        }

        // DELETE api/<ConsultaController>/5
        [HttpDelete("{id:int}")]
        public ActionResult<ConsultaModel> Delete([FromRoute] int id)
        {

            var consultaModel = consultaRepository.FindById(id);
            consultaRepository.Delete(id);
            return NoContent();

        }


    }
}

