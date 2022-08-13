namespace Api.DataAccess.Contracts.Entities
{
    public class OrderMongo : EntityMongo
    {
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        #endregion
    }
}
