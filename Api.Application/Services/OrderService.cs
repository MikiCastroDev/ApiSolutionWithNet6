using Api.Application.Contracts.Services;
using Api.Application.DTOs;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;

namespace Api.Application.Services
{
    public class OrderService : BaseAppService, IOrderService
    {
        private readonly IApiCaller caller;

        public OrderService(IServiceProvider serviceProvider, IApiCaller apiCaller) 
            : base(serviceProvider, apiCaller){ }
        public string RegisterOrder()
        {
            using (IUnitOfWorkMySQL uow = GetUowInstance())
            {
                Order order = uow.Orders.GetById(2);
                using (IUnitOfWorkMongoDB uowMongo = GetUowMongoInstance())
                {
                    IEnumerable<OrderMongo> orders = uowMongo.Orders.GetAll();
                    return orders.ToList()[0].Header;
                }

                return "falla";
            }
        }

        public async Task<string> GetWeatherByCity(string city)
        {
            WheaterDTO wheater = new WheaterDTO();
            var result = await _apiCaller.GetResponseFromWeatherStack(city);
            wheater.temperature = (result).current.temperature;
            return "Temperature " + wheater.temperature;
        }

        #region Private Methods
        private IUnitOfWorkMySQL GetUowInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMySQL)) as IUnitOfWorkMySQL;
        }

        private IUnitOfWorkMongoDB GetUowMongoInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMongoDB)) as IUnitOfWorkMongoDB;
        }
        #endregion
    }
}
