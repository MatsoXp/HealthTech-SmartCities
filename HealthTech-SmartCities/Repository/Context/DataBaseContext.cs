using HealthTech_SmartCities.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthTech_SmartCities.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        //construtor padrao
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        //construtor padrao
        protected DataBaseContext()
        {
        }

        //propriedade para tebela Usuario
        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<MedicoModel> Medico { get; set; }




    }
}
