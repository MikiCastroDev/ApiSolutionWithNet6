using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess.Contracts;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Api.Application.Services
{
    public abstract class BaseAppService
    {
        protected IServiceProvider _serviceProvider;
        protected IApiCaller _apiCaller;
        protected IMapper _mapper;
        protected ILogger _logger;
        public BaseAppService(IServiceProvider serviceProvider, IApiCaller apiCaller, IMapper mapper, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            _apiCaller = apiCaller;
            _mapper = mapper;
            _logger = logger;
        }

        #region Private Methods
        protected IUnitOfWorkMySQL GetUowInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMySQL)) as IUnitOfWorkMySQL;
        }

        protected IUnitOfWorkMongoDB GetUowMongoInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMongoDB)) as IUnitOfWorkMongoDB;
        }
        #endregion
    }
}
