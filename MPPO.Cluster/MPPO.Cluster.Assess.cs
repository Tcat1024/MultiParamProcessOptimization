using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Cluster
{
    public class Assess
    {
        public static ClusterAssessReport_BWP GetBWP<T>(IList<T> data, ClusterResult<T> result)
        {
            Type dataType = typeof(T);
            int cCount = result.cCount;
            int dataCount = data.Count;
            int paraCount = result.Properties.Length;
            var classnumber = result.ClassNumbers;
            var properties = result.Properties;
            int[] eachClusterCount = result.CountEachCluster;
            double[,] bc = new double[dataCount,cCount];
            double[] b = new double[dataCount];
            double[] w = new double[dataCount];
            double[] bwp = new double[dataCount];
            double avgBwp = 0;
            ClusterAssessReport_BWP report = new ClusterAssessReport_BWP();
            for(int i=0;i<dataCount-1;i++)
            {
                for(int j=i+1;j<dataCount;j++)
                {
                    int cj = classnumber[j];
                    int ci = classnumber[i];
                    double temp = GetEdistence<T>(data[i], data[j],properties, paraCount, dataType);
                    int tempcount = eachClusterCount[cj];
                    if(ci==cj)
                    {
                        temp = temp / (tempcount-1);
                        w[i] += temp;
                        w[j] += temp;
                    }
                    else
                    {
                        temp = temp / tempcount;
                        bc[i, cj] += temp;
                        bc[j, ci] += temp;
                    }
                }
            }
            for(int i = 0;i<dataCount;i++)
            {
                var iclass = classnumber[i];
                double tempb = Double.PositiveInfinity;
                for(int j=0;j<iclass;j++)
                {
                    double t =bc[i, j];
                    if (t < tempb)
                        tempb = t;
                }
                for(int j=iclass+1;j<cCount;j++)
                {
                    double t = bc[i, j];
                    if (t < tempb)
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
        private static double GetEdistence<T>(T a,T b,string[] properties,int paraCount,Type dataType)
        {
            double result = 0;
            for(int i=0;i<paraCount;i++)
            {
                result+=Math.Pow(Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(a,null)) - Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(b, null)),2);
            }
            return result;
        }
    }
}
