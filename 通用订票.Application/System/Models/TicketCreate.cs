namespace 通用订票.Application.System.Models
{
    public class TicketCreate
    {
        public Guid userid { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Core.Entity.Order order { get; set; }
        public ICollection<int> uid { get; set; }
        public string tenantId { get; set; }
        public string realTenantId { get; set; }
    }
}
