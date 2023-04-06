using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repository;
using HealthTech_SmartCities.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthTech_SmartCities.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioRepository usuarioRepository;

        //instancia do db context
        public UsuarioController(DataBaseContext context)
        {
            usuarioRepository = new UsuarioRepository(context);
        }

        //retorna a lista de todos os usuarios
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<UsuarioModel>> Get()
        {
            var lista = usuarioRepository.FindAll();
            return Ok(lista);
        }

        //retorna um objeto usuarioModel buscando por id
        // GET api/<UsuarioController>/5
        [HttpGet("{id:int}")]
        public ActionResult<UsuarioModel> Get([FromRoute] int id)
        {
            try
            {
                var usuarioModel = usuarioRepository.FindByID(id);
                if (usuarioModel != null)
                {
                    return Ok(usuarioModel);
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

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            usuarioRepository.Insert(usuarioModel);
            var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioModel.UsuarioId);
            return Created(location, usuarioModel);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id:int}")]
        public ActionResult<UsuarioModel> Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel.UsuarioId != id)
            {
                return NotFound();
            }
            else
            {
                usuarioRepository.Update(usuarioModel);
                return NoContent();
            }


        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioModel> Delete([FromRoute] int id)
        {

            var usuarioModel = usuarioRepository.FindByID(id);
            usuarioRepository.Delete(id);
            return NoContent();

        }

    }
}
