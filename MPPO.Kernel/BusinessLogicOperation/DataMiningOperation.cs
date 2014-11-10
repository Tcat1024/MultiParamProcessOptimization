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
        public static DataSet KMeans(IDataTable<DataRow> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount, double m, double s, Protocol.Structure.WaitObject wt,int methodid)
        {
            MinClusterCount = MinClusterCount < 2 ? 2 : MinClusterCount;
            MaxClusterCount = MaxClusterCount < 2 ? (int)Math.Pow(data.RowCount, 0.5) : MaxClusterCount;
            maxCount = maxCount < 2 ? 20 : maxCount;
            int paracount = properties.Length;
            int i, j, k;
            double[] mean;
            double[] std;
            if (!double.IsNaN(m))
            {
                mean = new double[paracount];
                for (i = 0; i < paracount; i++)
                    mean[i] = m;
            }
            else
                mean = data.Avg(properties);
            if (!double.IsNaN(s))
            {
                std = new double[paracount];
                for (i = 0; i < paracount; i++)
                    std[i] = s;
            }
            else
                std = data.Stdev(properties, mean);
            var clusterreport = MPPO.DataMining.KMeans.AutoParallelStart(data, properties, maxCount, MinClusterCount, MaxClusterCount, mean, std, wt, methodid);
            var report = new DataSet();
            DataTable overview = new DataTable("OverView");
            overview.Columns.Add(new DataColumn("序号", typeof(int)));
            overview.Columns.Add(new DataColumn("分类数", typeof(int)));
            overview.Columns.Add(new DataColumn("AvgBWP", typeof(double)));
            overview.Columns.Add(new DataColumn("耗时", typeof(double)));
            overview.Columns.Add(new DataColumn("循环次数", typeof(int)));
            DataTable centers = new DataTable("Centers");
            int len = properties.Length;
            centers.Columns.Add(new DataColumn("序号", typeof(int)));
            centers.Columns.Add(new DataColumn("类标号", typeof(int)));
            for (i = 0; i < len; i++)
            {
                centers.Columns.Add(new DataColumn(properties[i], typeof(double)));
            }
            DataTable results = new DataTable("Results");
            results.Columns.Add(new DataColumn("序号", typeof(int)));
            results.Columns.Add(new DataColumn("行号", typeof(int)));
            results.Columns.Add(new DataColumn("类标号", typeof(int)));
            results.Columns.Add(new DataColumn("BWP", typeof(double)));
            results.Columns.Add(new DataColumn("B", typeof(double)));
            results.Columns.Add(new DataColumn("W", typeof(double)));
            report.Tables.Add(overview);
            report.Tables.Add(centers);
            report.Tables.Add(results);
            report.Relations.Add(new DataRelation("OverView_Centers", overview.Columns[0], centers.Columns[0]));
            int count = clusterreport.HisResult.Count;
            int datacount = data.RowCount;
            for (i = 0; i < count; i++)
            {
                var tempresult = clusterreport.HisResult[i];
                var tempreport = clusterreport.HisReport[i];
                overview.Rows.Add(i, tempresult.cCount, tempreport.AvgBWP, tempresult.CostTime,tempresult.LoopCount);
                for (j = 0; j < tempresult.cCount; j++)
                {
                    var temprow = centers.NewRow();
                    temprow[0] = i;
                    temprow[1] = j;
                    for (k = 0; k < len; k++)
                    {
                        temprow[k+2] = tempresult.Centers[j,k];
                    }
                    centers.Rows.Add(temprow);
                }
                for (j = 0; j < datacount; j++)
                {
                    results.Rows.Add(i, j, tempresult.ClassNumbers[j],tempreport.BWP[j], tempreport.B[j], tempreport.W[j]);
                }
            }
            return report;
        }
    }
}
