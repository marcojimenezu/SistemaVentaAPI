using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.DBContext;

public interface IDbVentaContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DatabaseFacade Database { get; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<DetalleVenta> DetalleVenta { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuRol> MenuRols { get; set; }
    public DbSet<NumeroDocumento> NumeroDocumentos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Venta { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}