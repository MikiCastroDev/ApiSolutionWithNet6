using Api.CrossCutting.Contracts.ApiCaller;
using AutoMapper;

namespace Api.Application.Services
{
    public abstract class BaseAppService
    {
        protected IServiceProvider _serviceProvider;
        protected IApiCaller _apiCaller;
        protected IMapper _mapper;
        public BaseAppService(IServiceProvider serviceProvider, IApiCaller apiCaller, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _apiCaller = apiCaller;
            _mapper = mapper;
        }
    }
}
