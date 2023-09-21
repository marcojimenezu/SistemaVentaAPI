using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaVenta.DAL.DBContext;

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
    }

    public DbventaContext DbVentaContext { get; set; }
}