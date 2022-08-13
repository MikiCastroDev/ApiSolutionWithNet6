namespace Api.DataAccess.Contracts.Entities
{
    public class Order : Entity
    {
        #region Properties
        public string Header { get; set; }
        public string Detail { get; set; }
        #endregion
    }
}
