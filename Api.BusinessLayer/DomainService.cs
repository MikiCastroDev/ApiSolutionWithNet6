using Api.DataAccess.Contracts;

namespace Api.BusinessLayer
{
    public class DomainService
    {
        protected IUnitOfWorkMySQL _uowSQL;
        protected IUnitOfWorkMongoDB _uowMongo;

        public DomainService(IUnitOfWorkMySQL uowSQL, IUnitOfWorkMongoDB uowMongo)
        {
            _uowSQL = uowSQL;
            _uowMongo = uowMongo;
        }
    }
}
