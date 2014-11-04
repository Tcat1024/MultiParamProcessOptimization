using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Protocol.Interface
{
    public interface IDataTable
    {
        object this[int index] { get;}
        object[] GetGroup(int index);
        int Count();
    }
}
