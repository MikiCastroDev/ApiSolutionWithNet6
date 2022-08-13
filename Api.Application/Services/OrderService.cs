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
                return order.Header;
            }

            return "falla";
        }

        public string GetWeatherByCountry()
        {
            return "this";
        }

        private IUnitOfWorkMySQL GetUowInstance()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWorkMySQL)) as IUnitOfWorkMySQL;
        }
    }
}
