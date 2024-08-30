using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class WechatMerchantConfig : IEntity<MasterDbContextLocator>
    {
        [Key]
        public string appid { get; set; }
        [NotNull]
        public string mchId { get; set; }
        [NotNull]
        public string apiKey { get; set; }
        public string apiv3Key { get; set; }
        [NotNull]
        public string certificate { get; set; }
        public string RsaPublicKey { get; set; }
    }
}
