using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Protocol.Interface;
using MPPO.Protocol.Operation;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataMiningOperation
    {
        public static void KMeans(IDataTable<DataRow> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount, double[] mean, double[] v, object[] flags, out DataSet report)
        {
            if (mean == null)
                data.Avg(properties, out mean);
            if (v == null)
                data.Stdev(properties, out v);
            var clusterreport = MPPO.DataMining.KMeans.AutoParallelStart(data, properties, maxCount, MinClusterCount, MaxClusterCount, mean, v, flags);
            report = new DataSet();
            DataTable overview = new DataTable("OverView");
            overview.Columns.Add(new DataColumn("序号", typeof(int)));
            overview.Columns.Add(new DataColumn("分类数", typeof(int)));
            overview.Columns.Add(new DataColumn("AvgBWP", typeof(double)));
            overview.Columns.Add(new DataColumn("耗时", typeof(double)));
            DataTable centers = new DataTable("Centers");
            int len = properties.Length;
            centers.Columns.Add(new DataColumn("序号", typeof(int)));
            int i, j, k;
            for (i = 0; i < len; i++)
            {
                centers.Columns.Add(new DataColumn(properties[i], typeof(double)));
            }
            DataTable results = new DataTable("Results");
            results.Columns.Add(new DataColumn("序号", typeof(int)));
            results.Columns.Add(new DataColumn("行号", typeof(int)));
            results.Columns.Add(new DataColumn("分类号", typeof(int)));
            results.Columns.Add(new DataColumn("B", typeof(double)));
            results.Columns.Add(new DataColumn("W", typeof(double)));
            results.Columns.Add(new DataColumn("BWP", typeof(double)));
            report.Tables.Add(overview);
            report.Tables.Add(centers);
            report.Tables.Add(results);
            report.Relations.Add(new DataRelation("OverView_Centers", overview.Columns[0], centers.Columns[0]));
            int count = clusterreport.HisResult.Count;
            int datacount = data.Count();
            for (i = 0; i < count; i++)
            {
                var tempresult = clusterreport.HisResult[i];
                var tempreport = clusterreport.HisReport[i];
                overview.Rows.Add(i, tempresult.cCount, tempreport.AvgBWP, tempresult.CostTime);
                for (j = 0; j < tempresult.cCount; j++)
                {
                    var temprow = centers.NewRow();
                    temprow[0] = i;
                    for (k = 1; k < len; k++)
                    {
                        temprow[k] = tempresult.Centers[j,k];
                    }
                    centers.Rows.Add(temprow);
                }
                for (j = 0; j < datacount; j++)
                {
                    results.Rows.Add(i, j, tempresult.ClassNumbers[j], tempreport.B[j], tempreport.W[j], tempreport.BWP[j]);
                }
            }
        }
    }
}
