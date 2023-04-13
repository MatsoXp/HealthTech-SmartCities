using HealthTech_SmartCities.Repository.Context;
using HealthTech_SmartCities.Repository;
using Microsoft.AspNetCore.Mvc;
using HealthTech_SmartCities.Models;
using Microsoft.AspNetCore.Http.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthTech_SmartCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private readonly MedicoRepository medicoRepository;

        //instancia do db context
        public MedicoController(DataBaseContext context)
        {
            medicoRepository = new MedicoRepository(context);
        }



        // GET: api/<MedicoController>
        [HttpGet]
        public ActionResult<List<MedicoModel>> Get()
        {
            var lista = medicoRepository.FindAll();
            return Ok(lista);
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id:int}")]
        public ActionResult<MedicoModel> Get([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.FindByID(id);
                if (medicoModel != null)
                {
                    return Ok(medicoModel);
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

        // POST api/<MedicoController>
        [HttpPost]
        public ActionResult<MedicoModel> Post([FromBody] MedicoModel medicoModel)
        {
            medicoRepository.Insert(medicoModel);
            var location = new Uri(Request.GetEncodedUrl() + "/" + medicoModel.MedicoId);
            return Created(location, medicoModel);
        }

        // PUT api/<MedicoController>/5
        [HttpPut("{id:int}")]
        public ActionResult<MedicoModel> Put([FromRoute] int id, [FromBody] MedicoModel medicoModel)
        {
            if (medicoModel.MedicoId != id)
            {
                return NotFound();
            }
            else
            {
                medicoRepository.Update(medicoModel);
                return NoContent();
            }


        }

        [HttpDelete("{id:int}")]
        public ActionResult<MedicoModel> Delete([FromRoute] int id)
        {

            var medicoModel = medicoRepository.FindByID(id);
            medicoRepository.Delete(id);
            return NoContent();

        }




    }
}
