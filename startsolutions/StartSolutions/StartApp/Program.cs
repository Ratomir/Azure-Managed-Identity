using StartApp;

CancellationToken cancellationToken = default;

Console.WriteLine("****************************************");
Console.WriteLine("******       MANAGED IDENTITY     ******");
Console.WriteLine("****************************************");
Console.WriteLine("Select the app!");
Console.WriteLine(" 1. KeyVault");
Console.WriteLine(" 2. SQL Database");
Console.Write("Input >>> ");


int.TryParse(Console.ReadLine(), out int option);
IStartApp app;
switch (option)
{
    case 1:
        app = new KeyVaultApp();
        await app.StartAppAsync(cancellationToken);
        break;
    case 2:
        app = new SqlDatabaseIdentityApp();
        await app.StartAppAsync(cancellationToken);
        break;
    default:
        break;
}

Console.WriteLine("END!");
Console.ReadKey();

