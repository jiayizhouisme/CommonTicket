namespace 通用订票.Web.Entry.Model
{
    public class GetOrdersModel : UserOrderQueryModel
    {

        public GetOrdersModel(通用订票.Core.Entity.Order order) : base(order)
        {
            
        }
        public DateTime appTime { get; set; }
        
    }
}
