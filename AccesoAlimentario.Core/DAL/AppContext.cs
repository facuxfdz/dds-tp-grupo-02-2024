using AccesoAlimentario.Core.Entities.Heladeras;
using AccesoAlimentario.Core.Entities.Personas.Beneficiarios;
using AccesoAlimentario.Core.Entities.Personas.Colaboradores;
using AccesoAlimentario.Core.Entities.Personas.Tecnicos;
using Microsoft.EntityFrameworkCore;

namespace AccesoAlimentario.Core.DAL;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }
    public DbSet<Heladera> Heladeras { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<PuntoEstrategico> PuntosEstrategicos { get; set; }
    public DbSet<Vianda> Viandas { get; set; }
    public DbSet<PersonaHumana> PersonasHumanas { get; set; }
    public DbSet<PersonaJuridica> PersonasJuridicas { get; set; }
    public DbSet<Tecnico> Tecnicos { get; set; }
    public DbSet<PersonaVulnerable> PersonasVulnerables { get; set; }
    
    // Using mysql 8 as database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=acceso_alimentario;user=admin;password=pass123");
    }
}