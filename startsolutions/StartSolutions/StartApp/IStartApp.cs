namespace StartApp;
public interface IStartApp
{
    public string AppName { get; }
    Task StartAppAsync(CancellationToken cancellationToken);
}
