using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;

namespace TORO.Server.Context;

public interface ITORODbContext
{

    DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Usuario> Usuarios { get; set; }  
    DbSet<Bovino> bovinos { get; set; }
    DbSet<Padre> Father { get; set; }
    DbSet<Madre> Mother { get; set; }
    DbSet<EmbVaca> Preñeses { get; set; }
    DbSet<ProdLeche> Producciones { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class TORODbContext : DbContext, ITORODbContext
{
    private readonly IConfiguration config;

    public TORODbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("TORO"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<UsuarioRol> UsuariosRoles { set; get; } = null!;
    public DbSet<Usuario> Usuarios { set; get; } = null!;
    public DbSet<Bovino> bovinos { set; get; } = null!;
    public DbSet<Padre> Father { set; get; } = null!;
    public DbSet<Madre> Mother { set; get; } = null!;
    public DbSet<EmbVaca> Preñeses { set; get; } = null!;
    public DbSet<ProdLeche> Producciones { set; get; } = null!;
    
    #endregion
}