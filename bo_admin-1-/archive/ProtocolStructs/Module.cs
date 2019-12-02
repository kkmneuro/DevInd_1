using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs
{
    public class Module
    {
        public Int32 _id;
        public string _ModName;

        public Module()
        {
            _id = 0;
            _ModName = string.Empty;
        }
        public override string ToString()
        {
            return
                "_id->" + _id +
                "_ModName->" + _ModName;
        }
    }
}
