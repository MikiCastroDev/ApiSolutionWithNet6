namespace Api.DataAccess.Contracts.Entities
{
    public class Order : Entity
    {
        #region Properties
        public string Header { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int Humidity { get; set; }
        #endregion

        #region Constructor
        public Order(string header, string detail, int humidity)
        {
            this.Header = header;
            this.Detail = detail;
            this.Humidity = humidity;
            this.CreatedAt = DateTime.Now;
            this.CreatedBy = "Api";
        }
        #endregion
    }
}
