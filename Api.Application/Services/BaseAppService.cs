namespace Api.Application.Services
{
    public abstract class BaseAppService
    {
        protected IServiceProvider _serviceProvider;
        public BaseAppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
