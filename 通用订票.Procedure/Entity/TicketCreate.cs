using Core.Queue;
using 通用订票.Base.Entity;

namespace 通用订票.Procedure.Entity

{
    public class TicketCreate : IProcedureEntity
    {
        public long userid { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Core.Entity.Order order { get; set; }
        public ICollection<long> uid { get; set; }
        public string tenantId { get; set; }
        public TicketStatus status { get; set; }
        public string[] exhibitions { get; set; }
        public Guid exhibitionId { get; set; }
    }

}
