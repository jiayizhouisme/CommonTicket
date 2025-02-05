﻿using BeetleX.Redis.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengResponse
    {
        public XieChengResponseHeader header { get; set; }
        public string body { get; set; }
    }
    public struct XieChengResponseHeader
    {
        public string resultCode { get; set; }
        public string resultMessage { get; set; }
    }
}
