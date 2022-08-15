using Api.Application.Contracts.DTOs;
using Api.Application.Contracts.Services;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using AutoMapper;
using MongoDB.Bson;

namespace Api.Application.Services
{
    public class OrderService : BaseAppService, IOrderService
    {
        public OrderService(IServiceProvider serviceProvider, IApiCaller apiCaller, IMapper mapper) 
            : base(serviceProvider, apiCaller, mapper){ }
        public async Task<Order> RegisterOrder(OrderRequest order, bool sandbox)
        {
            using (IUnitOfWorkMySQL uow = GetUowInstance())
            {
                try
                {
                    int humidity = _apiCaller.GetResponseFromWeatherStack(order.city).Result.current.humidity;
                    Order orderToAdd = new Order(order.header, order.detail, humidity);
                    uow.Orders.Add(orderToAdd);

                    if (uow.Commit() > 0)
                    {
                        using (IUnitOfWorkMongoDB uowMongo = GetUowMongoInstance())
                        {
                            OrderMongo orderToAddInMongo = new OrderMongo(order.header, order.detail, humidity);
                            uowMongo.Orders.Add(orderToAddInMongo);

                            if(orderToAddInMongo._id != default(ObjectId))
                            {
                                return orderToAdd;
                            }
                        }
                    }
                } 
                catch (Exception ex)
                {

                }
                

                return null;
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
