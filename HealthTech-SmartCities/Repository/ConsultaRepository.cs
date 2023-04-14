using HealthTech_SmartCities.Models;
using HealthTech_SmartCities.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthTech_SmartCities.Repositories
{
    public class ConsultaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ConsultaRepository(DataBaseContext dbContext)
        {
            dataBaseContext = dbContext;
        }

        public IList<ConsultaModel> FindAll()
        {
            var lista = new List<ConsultaModel>();
            lista = dataBaseContext.Consulta.ToList();
            return lista;
        }

        public ConsultaModel FindById(int id)
        {
            var consulta = dataBaseContext.Consulta.Find(id);
            return consulta;
        }


        public void Insert(ConsultaModel consulta)
        {
            dataBaseContext.Consulta.Add(consulta);
            dataBaseContext.SaveChanges();
        }


        public void Update(ConsultaModel consulta)
        {
            dataBaseContext.Consulta.Update(consulta);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var consulta = dataBaseContext.Consulta.Find(id);
            dataBaseContext.Consulta.Remove(consulta);
            dataBaseContext.SaveChanges();
        }



    }
}