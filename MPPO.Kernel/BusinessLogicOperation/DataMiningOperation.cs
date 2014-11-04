using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPPO.Protocol.Interface;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataMiningOperation
    {
        public static void Entropy(IDataTable data, List<string> columns, out List<Tuple<string, double>> result)
        {
            result = new List<Tuple<string, double>>();
            var columnsarray = columns.ToArray();
            var re = MPPO.Pretreat.Entropy.GetEntropy(data, columnsarray);
            int count = re.Length;
            for (int i = 0; i < count; i++)
            {
                result.Add(new Tuple<string, double>(columns[i], re[i]));
            }
            result.Sort(new Comparison<Tuple<string, double>>((a1, a2) => { return a1.Item2.CompareTo(a2.Item2); }));
        }
    }
}
