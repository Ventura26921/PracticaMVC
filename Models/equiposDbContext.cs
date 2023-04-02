using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<Estados_equipo> estados_equipo { get; set; }
        public DbSet<Estados_reserva> estados_Reserva { get; set; }
        public DbSet<Facultades> facultades { get; set;}
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
        
        public DbSet<Usuarios> usuarios { get; set; }

        public DbSet<carreras> Carreras { get; set; }


    }
}
