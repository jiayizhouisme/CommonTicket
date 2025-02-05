﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.SignalR
{
    public interface ISignalRUserService
    {
        public void AddClient(string connId, RealOnlineClient client);

        public void RemoveClient(string connId);

        public RealOnlineClient isOnline(string userId);
    }
}
