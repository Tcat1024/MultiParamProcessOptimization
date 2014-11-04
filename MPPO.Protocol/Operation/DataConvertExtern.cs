using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Protocol.Operation
{
    public static class DataConvertExtern
    {
        public static double ConvertToDouble(this object o)
        {
            if (o is DBNull)
                return 0;
            else
                return Convert.ToDouble(o);
        }
    }
}
