namespace Api.Application.Contracts.DTOs
{
    public class OrderDTO
    {
        public string header { get; set; }
        public string detail { get; set; }
        public int humidity { get; set; }
        public long mysqlId { get; set; }
        public string mongoId { get; set; }
    }
}
