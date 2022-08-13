using Api.DataAccess.Contracts;

namespace Api.BusinessLayer.BusinessServices
{
    public class OrderBusinessService : DomainService
    {
        #region Constructor
        public OrderBusinessService(IUnitOfWorkMySQL uowSQL, IUnitOfWorkMongoDB uowMongo) : base(uowSQL, uowMongo) { }
        #endregion
    }
}
