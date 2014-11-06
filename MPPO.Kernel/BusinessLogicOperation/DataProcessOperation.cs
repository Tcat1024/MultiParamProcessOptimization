using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using MPPO.Protocol.Interface;
using MPPO.Protocol.Operation;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataProcessOperation
    {
        public static void Entropy(IDataTable<DataRow> data, List<string> columns, out List<Tuple<string, double>> result)
        {
            result = new List<Tuple<string, double>>();
            var columnsarray = columns.ToArray();
            var re = MPPO.DataProcess.Entropy.GetEntropy(data, columnsarray);
            int count = re.Length;
            for (int i = 0; i < count; i++)
            {
                result.Add(new Tuple<string, double>(columns[i], re[i]));
            }
            result.Sort(new Comparison<Tuple<string, double>>((a1, a2) => { return a1.Item2.CompareTo(a2.Item2); }));
        }
        public static void Schmidt(IDataTable<DataRow> data, List<string> columns, out List<string> result, out DataTable resultdetail)
        {
            int columncount = columns.Count;
            int rowcount = data.Count();
            double[][] vectors = new double[columncount][];
            int i, j;
            for (i = 0; i < columncount; i++)
            {
                vectors[i] = new double[rowcount];
                for (j = 0; j < rowcount; j++)
                {
                    vectors[i][j] = data[j][columns[i]].ConvertToDouble();
                }

            }
            int[] maxid;
            double[,] report;
            MPPO.DataProcess.Schmidt.Start(vectors, columncount, rowcount, out maxid, out report);
            result = new List<string>();
            resultdetail = new DataTable();
            foreach (var column in columns)
            {
                resultdetail.Columns.Add(column, typeof(double));
            }
            for (i = 0; i < columncount; i++)
            {
                var temprow = resultdetail.NewRow();
                for (j = 0; j < columncount; j++)
                {
                    temprow[j] = report[i, j];
                }
                resultdetail.Rows.Add(temprow);
            }
            for (i = 0; i < columncount; i++)
            {
                var columnname = columns[maxid[i]];
                result.Add(columnname);
                resultdetail.Columns[columnname].SetOrdinal(i);
            }
        }
        public static void DataStandard(IMdiDataForm<DataRow> targetform, string[] inputcolumns, string[] outputcolumns)
        {
            int i, j;
            int count = inputcolumns.Length;
            var table = targetform.GetDataTable();
            for (i = 0; i < count; i++)
            {
                var col = outputcolumns[i];
                if (!table.ContainsColumn(col))
                    table.AddColumn(col, table.GetColumnType(inputcolumns[i]));
            }
            int datacount = table.Count();
            int paramcount = inputcolumns.Length;
            double[,] result;
            new Thread(() =>
            {
                MPPO.DataProcess.Standardization.Zscore(table, inputcolumns, datacount, paramcount, out result);
                targetform.UIInvoke(new Action(() =>
                {
                    for (i = 0; i < paramcount; i++)
                    {
                        for (j = 0; j < datacount; j++)
                            table[j][outputcolumns[i]] = result[j, i];
                    }
                }));
            }) { IsBackground = true}.Start();       
            
        }
    }
}
