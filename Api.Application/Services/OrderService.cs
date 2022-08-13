using Api.Application.Contracts.Services;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;

namespace Api.Application.Services
{
    public class OrderService : BaseAppService, IOrderService
    {

        public OrderService(IServiceProvider serviceProvider) : base(serviceProvider){ }
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

        public string GetWeatherByCountry()
        {
            return "this";
        }

        private IUnitOfWorkMySQL GetUowInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMySQL)) as IUnitOfWorkMySQL;
        }

        private IUnitOfWorkMongoDB GetUowMongoInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMongoDB)) as IUnitOfWorkMongoDB;
        }
    }
}
