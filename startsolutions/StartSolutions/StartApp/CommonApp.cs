using Azure.Core;
using Azure.Identity;

namespace StartApp;
public class CommonApp
{
    private static readonly object _lock = new();
    private TokenCredential? _credential;

    public TokenCredential GetAzureCredential()
    {
        if (_credential == null)
        {
            lock (_lock)
            {
                _credential = new DefaultAzureCredential();
            }
        }

        return _credential;
    }
}
