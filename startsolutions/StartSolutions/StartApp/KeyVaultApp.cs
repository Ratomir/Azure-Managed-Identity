using Azure.Core;
using Azure.Security.KeyVault.Secrets;

namespace StartApp;
public class KeyVaultApp : CommonApp, IStartApp
{
    private const string KeyVaultName = "rvs-managedidentity";
    public string AppName => "KeyVault";

    public async Task StartAppAsync(CancellationToken cancellationToken)
    {
        SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
             }
        };

        var client = new SecretClient(new Uri($"https://{KeyVaultName}.vault.azure.net/"), GetAzureCredential(), options);

        KeyVaultSecret secret = client.GetSecret("firstsecret", cancellationToken: cancellationToken);

        string secretValue = secret.Value;

        Console.WriteLine("Here is the secret => " + secretValue);

        await Task.CompletedTask;
    }

    public string GetSecret(string key)
    {
        SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
             }
        };

        var client = new SecretClient(new Uri($"https://{KeyVaultName}.vault.azure.net/"), GetAzureCredential(), options);

        KeyVaultSecret secret = client.GetSecret(key);

        return secret.Value;
    }
}
