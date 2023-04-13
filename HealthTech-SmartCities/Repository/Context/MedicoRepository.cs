using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repository.Context;

namespace HealthTech_SmartCities.Repository.Context
{
    public class MedicoRepository
    {

        private readonly DataBaseContext dataBaseContext;


        public MedicoRepository(DataBaseContext dbContext)
        {
            dataBaseContext = dbContext;
        }


        //lista todos os objetos Medico
        public IList<MedicoModel> FindAll()
        {
            var lista = new List<MedicoModel>();
            lista = dataBaseContext.Medico.ToList<MedicoModel>();
            return lista;
        }


        //lista objeto Medico por ID
        public MedicoModel FindByID(int id)
        {
            var medico = dataBaseContext.Medico.Find(id);

            return medico;
        }

        //cadastra objeto Medico
        public void Insert(MedicoModel medico)
        {
            dataBaseContext.Medico.Add(medico);
            dataBaseContext.SaveChanges();
        }

        //altera Medico
        public void Update(MedicoModel medico)
        {
            dataBaseContext.Medico.Update(medico);
            dataBaseContext.SaveChanges();
        }

        //exclui Medico por ID
        public void Delete(int id)
        {

            var medico = dataBaseContext.Medico.Find(id);

            dataBaseContext.Medico.Remove(medico);

            dataBaseContext.SaveChanges();
        }



















    }
}
