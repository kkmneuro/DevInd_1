using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TWS.Cls
{
    [Serializable]
    public class clsSavedMW
    {

        private DataTable _MWDataTable;
        private float _FontSize;

        public DataTable MWDataTable
        {
            get { return _MWDataTable; }
            set { _MWDataTable = value; }
        }

        public float FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }

    }

}
