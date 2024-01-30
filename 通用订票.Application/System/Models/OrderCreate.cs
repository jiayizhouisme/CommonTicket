﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Application.System.Models
{
    public class BaseOrderCreate {
        [Required(ErrorMessage = "请选择预约日期")]
        [Display(Name = "时间段")]
        public Guid appid { get; set; }
        [Required,MinLength(1, ErrorMessage = "需要选择至少1人"),MaxLength(5,ErrorMessage = "人数不可大于5人")]
        [Display(Name = "选择的人")]
        public ICollection<int> ids { get; set; }
    }


    public class OrderCreate : BaseOrderCreate
    {
        public Guid userid { get; set; }
        public string tenantId { get; set; }
        public string realTenantId { get; set; }
        public decimal price { get; set; }
        
    }
}
