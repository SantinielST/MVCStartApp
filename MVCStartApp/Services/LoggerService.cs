using MVCStartApp.BLL.Models;
using MVCStartApp.DLL.Repository.Interfaces;

namespace MVCStartApp.Services
{
    public class LoggerService(IRequestRepository requestRepository) : ILoggerService
    {
        private readonly IRequestRepository _requestRepository = requestRepository;

        public async Task Log(string requestUrl, object dateTimeObj)
        {
            var requestDateTime = (DateTime)dateTimeObj;

            var request = new Request()
            {
                Id = Guid.NewGuid(),
                Date = requestDateTime,
                Url = requestUrl
            };

            await _requestRepository.AddRequest(request);
        }
    }
}
