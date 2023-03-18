using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;

namespace TORO.Server.Context;

public interface ITORODbContext
{
    DbSet<Usuarios> Users { get; set; }
    DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Bovinos> bovinos { get; set; }
    DbSet<Padres> Father { get; set; }
    DbSet<Madres> Mother { get; set; }
    DbSet<EmbVaca> Preñeses { get; set; }
    DbSet<ProdLeche> Producciones { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

internal class TORODbContext : DbContext, ITORODbContext
{
    //Constructor de la clase
    protected readonly IConfiguration _configuration;
    public TORODbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("TORO"));
    }

    #region Tablas de la BD.
    public DbSet<Usuarios> Users { get; set; } = null!;
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;
    public DbSet<Bovinos> bovinos { get; set; } = null!;
    public DbSet<Padres> Father { get; set; } = null!;
    public DbSet<Madres> Mother { get; set; } = null!;
    public DbSet<EmbVaca> Preñeses { get; set; } = null!;
    public DbSet<ProdLeche> Producciones { get; set; } = null!;

    #endregion
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
