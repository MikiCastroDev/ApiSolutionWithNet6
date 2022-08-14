using Api.CrossCutting.Contracts.ApiCaller;

namespace Api.Application.Services
{
    public abstract class BaseAppService
    {
        protected IServiceProvider _serviceProvider;
        protected IApiCaller _apiCaller;
        public BaseAppService(IServiceProvider serviceProvider, IApiCaller apiCaller)
        {
            _serviceProvider = serviceProvider;
            _apiCaller = apiCaller;
        }
    }
}
