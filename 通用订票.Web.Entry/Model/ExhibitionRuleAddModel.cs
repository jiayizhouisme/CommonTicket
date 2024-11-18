using 通用订票.Core.Model;

namespace 通用订票.Web.Entry.Model
{
    public class ExhibitionRuleAddModel
    {
        public Guid id { get; set; }
        public ForbiddenRule rule { get; set; }
    }
}
