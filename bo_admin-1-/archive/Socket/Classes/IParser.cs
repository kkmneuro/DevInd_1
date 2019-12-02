using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs;
namespace DSSocket.Classes
{
    public interface IParser:IDisposable
    {
        void Parse();
        void Read(byte[] data, int length);
        Dictionary<int, Type> Structs_ { get; set; }
        event ProtocolReaderHandler PSRead;

    }
}
