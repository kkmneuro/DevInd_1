using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSSocket.Interfaces
{
    public interface iGenParam4clsClient:IDisposable
    {
        int HeartBeatTolerance { get; set; }
        int HeartBeatInterval { get; set; }
        int ReConnectionInterval { get; set; }
        void Close();
        void StopProcessor();
    }
}
