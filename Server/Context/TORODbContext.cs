using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;

namespace TORO.Server.Context;

public interface ITORODbContext
{

    DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Usuarios> Users { get; set; }  
    DbSet<Bovinos> bovinos { get; set; }
    DbSet<Padres> Father { get; set; }
    DbSet<Madres> Mother { get; set; }
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
        optionsBuilder.UseSqlServer(config.GetConnectionString("Proyecto"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<UsuarioRol> UsuariosRoles { set; get; } = null!;
    public DbSet<Usuarios> Users { set; get; } = null!;
    public DbSet<Bovinos> bovinos { set; get; } = null!;
    public DbSet<Padres> Father { set; get; } = null!;
    public DbSet<Madres> Mother { set; get; } = null!;
    public DbSet<EmbVaca> Preñeses { set; get; } = null!;
    public DbSet<ProdLeche> Producciones { set; get; } = null!;
    
    #endregion
}