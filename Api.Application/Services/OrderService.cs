using Api.Application.Contracts.DTOs;
using Api.Application.Contracts.Services;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using AutoMapper;

namespace Api.Application.Services
{
    public class OrderService : BaseAppService, IOrderService
    {
        public OrderService(IServiceProvider serviceProvider, IApiCaller apiCaller, IMapper mapper) 
            : base(serviceProvider, apiCaller, mapper){ }
        public string RegisterOrder(OrderDTO order, bool sandbox)
        {
            using (IUnitOfWorkMySQL uow = GetUowInstance())
            {
                try
                {
                    Order orderToAdd = new Order(order.header, order.detail);
                    uow.Orders.Add(orderToAdd);

                    using (IUnitOfWorkMongoDB uowMongo = GetUowMongoInstance())
                    {
                        IEnumerable<OrderMongo> orders = uowMongo.Orders.GetAll();
                        return orders.ToList()[0].Header;
                    }
                } 
                catch (Exception ex)
                {

                }
                

                return "falla";
            }
        }

        /// <summary>
        /// Get humidity and temperature based on a city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherDTO> GetWeatherByCity(string city)
        {
            WeatherDTO weather = new WeatherDTO();
            var result = await _apiCaller.GetResponseFromWeatherStack(city);
            return _mapper.Map<WeatherDTO>(result);
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
