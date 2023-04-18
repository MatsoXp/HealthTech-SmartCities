using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repositories;
using HealthTech_SmartCities.Repository;
using HealthTech_SmartCities.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthTech_SmartCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaRepository receitaRepository;

        public ReceitaController(DataBaseContext context)
        {
            receitaRepository = new ReceitaRepository(context);
        }


        // GET: api/<ReceitaController>
        [HttpGet]
        public ActionResult<List<ReceitaModel>> Get()
        {
            var lista = receitaRepository.FindAll();
            return Ok(lista);
        }




        // GET api/<ReceitaController>/5
        [HttpGet("{id:int}")]
        public ActionResult<ReceitaModel> Get([FromRoute] int id)
        {
            try
            {
                var receitaModel = receitaRepository.FindById(id);
                if (receitaModel != null)
                {
                    return Ok(receitaModel);
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

        // POST api/<ReceitaController>
        [HttpPost]
        public IActionResult Insert([FromBody] ReceitaModel receita)
        {
            var newReceita = new ReceitaModel
            {
                DataEmissao = receita.DataEmissao,
                Prescricao = receita.Prescricao,
                ConsultaId = receita.ConsultaId,
            };
            receitaRepository.Insert(newReceita);
            return Ok(newReceita);

        }

        // PUT api/<ReceitaController>/5
        [HttpPut("{id:int}")]
        public ActionResult<ReceitaModel> Put([FromRoute] int id, [FromBody] ReceitaModel receitaModel)
        {
            if (receitaModel.ReceitaId != id)
            {
                return NotFound();
            }
            else
            {
                receitaRepository.Update(receitaModel);
                return NoContent();
            }


        }

        // DELETE api/<ReceitaController>/5
        [HttpDelete("{id:int}")]
        public ActionResult<ReceitaModel> Delete([FromRoute] int id)
        {

            var receitaModel = receitaRepository.FindById(id);
            receitaRepository.Delete(id);
            return NoContent();

        }
    }
}
