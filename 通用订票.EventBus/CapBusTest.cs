using DotNetCore.CAP;
using Furion.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.EventBus
{
    public class CapBusTest : ICapSubscribe
    {
        private ILogger<CapBusTest> _log;
        public CapBusTest(ILogger<CapBusTest> log)
        {
            this._log = log;
        }

        [CapSubscribe("testCap")]
        public void ReceiveMsg(string time)
        {
            //1. 正常接收
            _log.LogInformation($"我是订阅者,收到的内容为：{time}");
        }
    }
}
