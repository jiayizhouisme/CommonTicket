﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitForm1._222222
{
   public  class Users
    {
        public int id { get; set; }
        [Comment("用户权限等级")]
        public string? password { get; set; }
        public bool? isDeleted { get; set; }
        [Comment("创建时间")]
        public DateTime? CreateTime { get; set; }
       
        [Comment("微信openid")]
        public string? username {  get; set; }
      
        public string? openId { get; set; }
    }
}
