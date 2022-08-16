using Api.Application.Contracts.DTOs;
using Api.Application.Contracts.Services;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Api.Application.Services
{
    public class OrderService : BaseAppService, IOrderService
    {
        public OrderService(IServiceProvider serviceProvider, IApiCaller apiCaller, IMapper mapper, ILogger logger) 
            : base(serviceProvider, apiCaller, mapper, logger){ }

        /// <summary>
        /// Register an order
        /// </summary>
        /// <param name="order">Order data</param>
        /// <param name="sandbox">Database configuration</param>
        /// <returns></returns>
        public async Task<OrderDTO> RegisterOrder(OrderRequest order, bool sandbox)
        {
            _logger.LogInformation($"->RegisterOrder: {order.header}");

            try
            {
                using (IUnitOfWorkMySQL uow = GetUowInstance())
                {
                    //Get humidity from city in the current time
                    int humidity = _apiCaller.GetResponseFromWeatherStack(order.city).Result.current.humidity;
                    //We create the data to persist in MySQL
                    Order orderToAdd = new Order(order.header, order.detail, humidity);
                    uow.Orders.Add(orderToAdd);

                    if (uow.Commit() > 0)
                    {
                        _logger.LogInformation($"-->RegisterOrder - Registered: {order.header} in MySQL database");
                        using (IUnitOfWorkMongoDB uowMongo = GetUowMongoInstance())
                        {
                            //We create the data to persist in MySQL
                            OrderMongo orderToAddInMongo = new OrderMongo(order.header, order.detail, humidity);
                            uowMongo.Orders.Add(orderToAddInMongo);

                            if (orderToAddInMongo._id != default(ObjectId))
                            {
                                _logger.LogInformation($"-->RegisterOrder - Registered: {order.header} in MongoDB database");
                                OrderDTO result = _mapper.Map<OrderDTO>(orderToAdd);
                                result.mongoId = orderToAddInMongo._id.ToString();
                                return result;
                            }
                            else
                            {
                                _logger.LogWarning($"-->RegisterOrder - Error registered: {order.header} in MySQL database");
                            }
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"-->RegisterOrder - Error registered: {order.header} in MySQL database");
                    }

                    _logger.LogInformation($"<-RegisterOrder");
                    
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySQL"))
                    _logger.LogError($"-->RegisterOrder - Error registered: {order.header} in MySQL database");
                if (ex.Message.Contains("MongoDB"))
                    _logger.LogError($"-->RegisterOrder - Error registered: {order.header} in MongoDB database");
                return default(OrderDTO);
            }

            return default(OrderDTO);
        }

        /// <summary>
        /// Get humidity and temperature based on a city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherDTO> GetWeatherByCity(string city)
        {
            _logger.LogInformation($"->GetWeatherByCity: {city}");

            try
            {
                WeatherDTO weather = new WeatherDTO();
                var result = await _apiCaller.GetResponseFromWeatherStack(city);
                _logger.LogInformation($"<-GetWeatherByCity: {city}");
                return _mapper.Map<WeatherDTO>(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySQL"))
                    _logger.LogError($"-->GetWeatherByCity - Error registered: {city} in MySQL database");
                if (ex.Message.Contains("MongoDB"))
                    _logger.LogError($"-->GetWeatherByCity - Error registered: {city} in MongoDB database");
                return default(WeatherDTO);
            }
        }
    }
}
