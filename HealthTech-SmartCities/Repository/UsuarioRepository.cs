using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repository.Context;

namespace HealthTech_SmartCities.Repository
{
    public class UsuarioRepository
    {
        private readonly DataBaseContext dataBaseContext;


        public UsuarioRepository(DataBaseContext dbContext) 
        {
            dataBaseContext = dbContext;
        }


        //lista todos os objetos Usuario
        public IList<UsuarioModel> FindAll()
        { 
            var lista = new List<UsuarioModel>();
            lista = dataBaseContext.Usuario.ToList<UsuarioModel>();
            return lista;
        }


        //lista objeto Usuario por ID
        public UsuarioModel FindByID(int id) 
        {
            var usuario = dataBaseContext.Usuario.Find(id);

            return usuario;
        }

        //cadastra objeto Usuario
        public void Insert(UsuarioModel usuario) 
        {
            dataBaseContext.Usuario.Add(usuario);
            dataBaseContext.SaveChanges();
        }

        //altera Usuario
        public void Update(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Update(usuario);
            dataBaseContext.SaveChanges();
        }

        //exclui usuario por ID
        public void Delete(int id)
        {

            var usuario = dataBaseContext.Usuario.Find(id);

            dataBaseContext.Usuario.Remove(usuario);

            dataBaseContext.SaveChanges();
        }


    }
}


