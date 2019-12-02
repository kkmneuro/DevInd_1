using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsInterface4OME
{
  public  class DatavalidationInfo
  {
      public bool Result;
      public string FieldName;

      public DatavalidationInfo(bool flag, string fld)
      {
          this.Result = flag;
          this.FieldName = fld;
      }

    }
}
