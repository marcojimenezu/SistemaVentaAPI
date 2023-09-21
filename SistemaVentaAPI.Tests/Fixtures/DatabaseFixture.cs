using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.Model;

namespace SistemaVentaAPI.Tests.Fixtures;

public class DatabaseFixture
{
    public DatabaseFixture()
    {
        var contextOptions = new DbContextOptionsBuilder<DbventaContext>()
            .UseInMemoryDatabase("DBVENTA")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
        DbVentaContext = new DbventaContext(contextOptions);
        DbVentaContext.Database.EnsureDeleted();
        DbVentaContext.Database.EnsureCreated();

        DbVentaContext.Categoria.Add(new Categoria
        {
            IdCategoria = 1,
            Nombre = "Accesories",
            EsActivo = true,
            FechaRegistro = DateTime.Now
        });
        DbVentaContext.Productos.Add(new Producto
        {
            IdProducto = 1,
            Precio = 99.99m,
            Nombre = "Mouse",
            FechaRegistro = DateTime.Now,
            Stock = 100,
            EsActivo = true,
            IdCategoria = 1
        });
        DbVentaContext.Productos.Add(new Producto
        {
            IdProducto = 2,
            Precio = 888.99m,
            Nombre = "Monitor",
            FechaRegistro = DateTime.Now,
            Stock = 100,
            EsActivo = true,
            IdCategoria = 1
        });
        DbVentaContext.SaveChanges();
    }

    public DbventaContext DbVentaContext { get; set; }
}