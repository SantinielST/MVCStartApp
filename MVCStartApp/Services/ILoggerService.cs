namespace MVCStartApp.Services
{
    public interface ILoggerService
    {
        Task Log(string requestUrl, object dateTimeObj);
    }
}
