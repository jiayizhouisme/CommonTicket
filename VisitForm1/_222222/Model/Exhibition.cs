using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace _222222.Model
{
    public class Exhibition
    {
        public Guid id { get; set; }
        [Comment("景区名")]
        public string name { get; set; }
        [Comment("景区介绍")]
        public string description { get; set; }
        [Comment("景区封面")]
        public string imgs { get; set; }
        public int status { get; set; }
        
        [Comment("景区提前预约天数")]
        public int? beforeDays { get; set; }
        
        public bool isDeleted { get; set; }
        [Comment("创建日期")]
        public DateTime CreateTime { get; set; }
        [Comment("价格")]
        public decimal basicPrice { get; set; }
        public int totalAmount { get; set; }
        // public passTemplate passType { get; set; }
        public string exhibitions { get; set; }
        
        public bool isMultiPart { get; set; }
        public string forbiddenRule { get; set; }
    }
}