using Microsoft.EntityFrameworkCore;
using GestionShared.Entities;

namespace GestionAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }
        
        public DbSet<Actividadad> Actividades { get; set; }

        public DbSet<Investigacion> Investigaciones { get; set; }

        public DbSet<Investigador> Investigadores { get; set; }

        public DbSet<Publicacion> Publicaciones { get; set; }

        public DbSet<RecursoEspe> RecursosEspe { get; set; }

        public DbSet<AsigRecursoEsp> AsigRecursosEsp { get; set; }

        public DbSet<PartInvestigador> PartInvestigadores { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
