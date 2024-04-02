using Furion.RemoteRequest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public class XieChengRequest
    {
        public XieChengHeader header { get; set; }
        public string body { get; set; }

        public async Task<XieChengResponse> Request()
        {
            return await XieChengConfig.CallUrl.SetBody(this).PostAsAsync<XieChengResponse>();
        }
    }
}
