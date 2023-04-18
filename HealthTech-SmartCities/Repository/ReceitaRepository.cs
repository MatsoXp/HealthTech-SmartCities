using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repository.Context;
namespace HealthTech_SmartCities.Repository
{
    public class ReceitaRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public ReceitaRepository(DataBaseContext dbContext)
        {
            dataBaseContext = dbContext;
        }

        public IList<ReceitaModel> FindAll()
        { 
            var lista = new List<ReceitaModel>();
            lista = dataBaseContext.Receita.ToList();
            return lista;
        }

        public ReceitaModel FindById(int id) 
        {
            var receita = dataBaseContext.Receita.Find(id);
            return receita;
        }

        public void Insert(ReceitaModel receita)
        {
            dataBaseContext.Receita.Add(receita);
            dataBaseContext.SaveChanges();
        }

        public void Update(ReceitaModel receita)
        {
            dataBaseContext.Receita.Update(receita);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var receita = dataBaseContext.Receita.Find(id);
            dataBaseContext.Receita.Remove(receita);
            dataBaseContext.SaveChanges();
        }












    }
}
