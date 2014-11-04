using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using MPPO.Protocol.Interface;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataOperation
    {
        public static void DataStandard(IMdiDataForm targetform, string[] inputcolumns, string[] outputcolumns)
        {
            int i, j;
            int count = inputcolumns.Length;
            for (i = 0; i < count; i++)
            {
                var col = outputcolumns[i];
                if (!targetform.ContainsColumn(col))
                    targetform.AddColumn(col, targetform.GetColumnType(inputcolumns[i]));
            }
            var table = targetform.GetDataTable();
            int datacount = table.Count();
            int paramcount = inputcolumns.Length;
            double[,] result;
            new Thread(() =>
            {
                MPPO.Pretreat.Standardization.Zscore(table, inputcolumns, datacount, paramcount, out result);
                targetform.UIInvoke(new Action(() =>
                {
                    for (i = 0; i < paramcount; i++)
                    {
                        for (j = 0; j < datacount; j++)
                            (table[j] as DataRow)[outputcolumns[i]] = result[j, i];
                    }
                }));
            }) { IsBackground = true}.Start();       
            
        }
    }
}
