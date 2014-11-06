using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Protocol.Interface;

namespace MPPO.Protocol.Operation
{
    public static class StatisticsExtern
    {
            public static void Avg(this IDataTable<DataRow> data, string[] selectedcolumns, out double[] result)
            {
                int rowcount = data.Count();
                int columncount = selectedcolumns.Length;
                result = new double[columncount];
                for (int i = 0; i < columncount; i++)
                {
                    for (int j = 0; j < rowcount; j++)
                    {
                        result[i] += data[j][selectedcolumns[i]].ConvertToDouble();
                    }
                }
            }
            public static void Stdev(this IDataTable<DataRow> data, string[] selectedcolumns, out double[] result,double[] avg = null)
            {
                if(avg==null)
                {
                    data.Avg(selectedcolumns,out avg);
                }
                int rowcount = data.Count();
                int columncount = selectedcolumns.Length;
                result = new double[columncount];
                for (int i = 0; i < columncount; i++)
                {
                    for (int j = 0; j < rowcount; j++)
                    {
                        result[i] += Math.Pow(data[j][selectedcolumns[i]].ConvertToDouble()-avg[i],2);
                    }
                    result[i] = Math.Pow(result[i] / rowcount, 0.5);
                }
            }
    }
}
