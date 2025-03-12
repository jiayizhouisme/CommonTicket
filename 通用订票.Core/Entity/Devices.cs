using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class Devices : IEntity
    {
        [Key]
        public int id { get; set; }
        public string deviceSn { get; set; }
        public string exhibitionId { get; set; }
        public string url { get; set; }
        public HttpMethod httpMethod { get; set; }
        public DeviceType type { get; set; }
    }
    public enum DeviceType
    {
        inDevice,
        outDevice
    }
}
