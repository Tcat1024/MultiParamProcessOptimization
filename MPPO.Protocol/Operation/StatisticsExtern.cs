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
        public static double[] Avg(this IDataTable<DataRow> data, string[] selectedcolumns)
        {
            int rowcount = data.RowCount;
            int columncount = selectedcolumns.Length;
            var result = new double[columncount];
            for (int i = 0; i < columncount; i++)
            {
                for (int j = 0; j < rowcount; j++)
                {
                    result[i] += data[j,selectedcolumns[i]].ConvertToDouble();
                }
                result[i] = result[i] / rowcount;
            }
            return result;
        }
        public static double[] Stdev(this IDataTable<DataRow> data, string[] selectedcolumns, double[] avg = null)
        {
            if (avg == null)
            {
                avg = data.Avg(selectedcolumns);
            }
            int rowcount = data.RowCount;
            int columncount = selectedcolumns.Length;
            var result = new double[columncount];
            for (int i = 0; i < columncount; i++)
            {
                for (int j = 0; j < rowcount; j++)
                {
                    result[i] += Math.Pow(data[j,selectedcolumns[i]].ConvertToDouble() - avg[i], 2);
                }
                result[i] = Math.Pow(result[i] / rowcount, 0.5);
            }
            return result;
        }
    }
}
