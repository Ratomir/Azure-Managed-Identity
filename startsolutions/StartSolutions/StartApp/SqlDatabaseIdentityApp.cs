using DAL;
using Microsoft.EntityFrameworkCore;

namespace StartApp;
public class SqlDatabaseIdentityApp : CommonApp, IStartApp
{
    private readonly KeyVaultApp keyVaultClient;

    public SqlDatabaseIdentityApp()
    {
        this.keyVaultClient = new KeyVaultApp();
    }

    public string AppName => "SqlDatabaseIdentity";

    public async Task StartAppAsync(CancellationToken cancellationToken)
    {
        string connectionString = keyVaultClient.GetSecret("ConnectionString");
        StartDbContext startDbContext = new StartDbContext(connectionString);

        var products = startDbContext.Products
                    .FromSql($"SELECT * FROM [SalesLT].[ProductModel]")
                    .ToList();

        Console.WriteLine("Here is count of products => " + products.Count);

        await Task.CompletedTask;
    }
}
