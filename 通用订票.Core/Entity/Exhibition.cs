using Furion.DatabaseAccessor;
using System;

namespace 通用订票.Core.Entity
{
    public class Exhibition :IEntity
    {
        public Guid id { get; set; }
        public string name{ get;set;}
        public string description { get;set;}
        public string imgs { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createTime { get; set; }
        public decimal basicPrice { get; set; }
        public PassTemplate passType { get; set; }
        
    }
    public enum PassTemplate
    {
        一张一人 = 0,
        一单一人 = 1
    }
}
