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
        public enum RESULTCODE
        {
            OUTOFRANGE = -1,
            SUCCESS = 0,
        }

        public static List<Tuple<string, double>> Entropy(IDataTable<DataRow> data, List<string> columns, Protocol.Structure.WaitObject wt)
        {
            var result = new List<Tuple<string, double>>();
            var columnsarray = columns.ToArray();
            var re = MPPO.DataProcess.Entropy.GetEntropy(data, columnsarray,wt);
            int count = re.Length;
            for (int i = 0; i < count; i++)
            {
                result.Add(new Tuple<string, double>(columns[i], re[i]));
            }
            result.Sort(new Comparison<Tuple<string, double>>((a1, a2) => { return a1.Item2.CompareTo(a2.Item2); }));
            return result;
        }
        public static Tuple<RESULTCODE, DataTable> SchmidtAnalysis(IDataTable<DataRow> data, List<string> columns, int size, int space)
        {
            int columncount = columns.Count;
            int rowcount = data.RowCount;
            if(size > rowcount)
            {
                return new Tuple<RESULTCODE, DataTable>(RESULTCODE.OUTOFRANGE, null);
            }
            int index = 0;
            int cursize = 0;
            DataTable resulttable = new DataTable();
            foreach (var column in columns)
            {
                resulttable.Columns.Add(column, typeof(double));
            }
            int i, j;
            while(index < rowcount)
            {
                if (index + size <= rowcount)
                    cursize = size;
                else
                    cursize = rowcount - index;
                double[][] vectors = new double[columncount][];
                for (i = 0; i < columncount; i++)
                {
                    vectors[i] = new double[size];
                    for (j = 0; j < size; j++)
                    {
                        vectors[i][j] = data[index + j, columns[i]].ConvertToDouble();
                    }
                }
                int[] maxid;
                double[,] report;
                MPPO.DataProcess.Schmidt.Start(vectors, columncount, size, out maxid, out report);
                var temprow = resulttable.NewRow();
                for (i = 0; i < columncount; i++)
                {
                    j = maxid[i];
                    temprow[j] = report[i, j];
                }
                resulttable.Rows.Add(temprow);
                index += space;
            }
            return new Tuple<RESULTCODE, DataTable>(RESULTCODE.SUCCESS, resulttable);
        }

        public static Tuple<List<string>,List<double>,DataTable> Schmidt(IDataTable<DataRow> data, List<string> columns)
        {
            int columncount = columns.Count;
            int rowcount = data.RowCount;
            double[][] vectors = new double[columncount][];
            int i, j;
            for (i = 0; i < columncount; i++)
            {
                vectors[i] = new double[rowcount];
                for (j = 0; j < rowcount; j++)
                {
                    vectors[i][j] = data[j,columns[i]].ConvertToDouble();
                }

            }
            int[] maxid;
            double[,] report;
            MPPO.DataProcess.Schmidt.Start(vectors, columncount, rowcount, out maxid, out report);
            var result = new List<string>();
            var percents = new List<double>();
            var resultdetail = new DataTable();
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
            double total = 0;
            double percent = 0;
            for (j = 0; j < columncount; j++)
            {
                total += resultdetail.Rows[j][j].ConvertToDouble();
            }
            for (i = 0; i < columncount; i++)
            {
                percent += (resultdetail.Rows[i][i].ConvertToDouble() * 100 / total);
                percents.Add(percent);
            }
            percents[columncount - 1] = 100;
            return new Tuple<List<string>, List<double>, DataTable>(result, percents, resultdetail);
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
            int datacount = table.RowCount;
            int paramcount = inputcolumns.Length;
            double[,] result;
            MPPO.DataProcess.Standardization.Zscore(table, inputcolumns, datacount, paramcount, out result);
            for (i = 0; i < paramcount; i++)
            {
                for (j = 0; j < datacount; j++)
                    table[j,outputcolumns[i]] = result[j, i];
            }
        }
    }
}
