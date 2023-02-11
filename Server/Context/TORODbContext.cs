using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TORO.Server.Models;

namespace TORO.Server.Context;

internal interface ITORODbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<UsuarioRol> UsuariosRoles { get; set; }

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
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;

    #endregion
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
