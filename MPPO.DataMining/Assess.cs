using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Protocol.Interface;
using MPPO.Protocol.Operation;

namespace MPPO.DataMining
{
    public class Assess
    {
        public static ClusterAssessReport_BWP GetBWP(IDataTable<DataRow> data, ClusterResult result,double[,] distence)
        {
            int cCount = result.cCount;
            int dataCount = data.RowCount;
            int paraCount = result.Properties.Length;
            var classnumber = result.ClassNumbers;
            var properties = result.Properties;
            int[] eachClusterCount = result.CountEachCluster;
            double[,] bc = new double[dataCount, cCount];
            double[] b = new double[dataCount];
            double[] w = new double[dataCount];
            double[] bwp = new double[dataCount];
            double avgBwp = 0;
            ClusterAssessReport_BWP report = new ClusterAssessReport_BWP();
            for (int i = 0; i < dataCount - 1; i++)
            {
                for (int j = i + 1; j < dataCount; j++)
                {
                    int cj = classnumber[j];
                    int ci = classnumber[i];
                    double temp = distence[i,j];
                    int tempcountj = eachClusterCount[cj];
                    int tempcounti = eachClusterCount[ci];
                    if (ci == cj)
                    {
                        temp = temp / (tempcountj - 1);
                        w[i] += temp;
                        w[j] += temp;
                    }
                    else
                    {
                        bc[i, cj] += temp / tempcountj;
                        bc[j, ci] += temp / tempcounti;
                    }
                }
            }
            for (int i = 0; i < dataCount; i++)
            {
                var iclass = classnumber[i];
                double tempb = Double.PositiveInfinity;
                for (int j = 0; j < iclass; j++)
                {
                    double t = bc[i, j];
                    if (t < tempb&&t!=0)
                        tempb = t;
                }
                for (int j = iclass + 1; j < cCount; j++)
                {
                    double t = bc[i, j];
                    if (t < tempb && t != 0)
                        tempb = t;
                }
                b[i] = tempb;
                double tempw = w[i];
                bwp[i] = (tempb - tempw) / (tempb + tempw);
                avgBwp += bwp[i];
            }
            avgBwp = avgBwp / dataCount;
            report.AvgBWP = avgBwp;
            report.B = b;
            report.W = w;
            report.BWP = bwp;
            return report;
        }
        public static double GetEdistence(DataRow a, DataRow b, string[] properties, int paraCount)
        {
            double result = 0;
            for (int i = 0; i < paraCount; i++)
            {
                result += Math.Pow(a[properties[i]].ConvertToDouble() - b[properties[i]].ConvertToDouble(), 2);
            }
            return result;
        }
        public static double GetEdistence(Protocol.Interface.IDataTable<DataRow> data,int a, int b, string[] properties, int paraCount)
        {
            double result = 0;
            for (int i = 0; i < paraCount; i++)
            {
                result += Math.Pow(data[a,properties[i]].ConvertToDouble() - data[b,properties[i]].ConvertToDouble(), 2);
            }
            return result;
        }
        public static double GetEdistence(DataRow a, double[,] b,int index, string[] properties, int paraCount)
        {
            double result = 0;
            for (int i = 0; i < paraCount; i++)
            {
                result += Math.Pow(a[properties[i]].ConvertToDouble() - b[index,i], 2);
            }
            return result;
        }
    }
}
