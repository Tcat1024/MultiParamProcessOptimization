using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Protocol.Operation;

namespace MPPO.DataProcess
{
    public class Schmidt
    {
        public static void Start(double[][] vectors, int columncount, int rowcount, out int[] maxid, out double[,] report)
        {
            report = new double[columncount, columncount];
            maxid = new int[columncount];
            if (columncount < 1||rowcount<1)
                return;
            int i, j, maxindex, surpluscount;
            double[][] oldV = new double[columncount][];
            int oldcount = 0;
            double max;
            double[][] oldmius = new double[columncount][];
            double[] maxV = null;
            double[] newV = null;
            List<int> surplus = new List<int>();
            for(i= 0;i<columncount;i++)
                surplus.Add(i);
            for (i = 0; i < columncount; i++)
            {
                max = double.MinValue;
                maxid[i] = -1;
                maxindex = -1;
                maxV = null;
                newV = null;
                surpluscount = surplus.Count;
                for (j = 0; j < surpluscount; j++)
                {
                    int tempj = surplus[j];
                    newV = schimidt(oldV, vectors[tempj], oldcount, oldmius, rowcount);

                    report[i, tempj] = getAvgSc(newV, vectors, columncount, rowcount);
                    if (report[i, tempj] > max)
                    {
                        max = report[i, tempj];
                        maxid[i] = tempj;
                        maxV = newV;
                        maxindex = j;
                    }
                }
                oldV[i] = maxV;
                oldmius[i] = getMiu(maxV, rowcount);
                oldcount++;
                surplus.RemoveAt(maxindex);
            }
        }
        private static double getAvgSc(double[] x,double[][] old,int columncount,int rowcount)
        {
            double output = 0;
            for (int i = 0; i < columncount; i++)
            {
                output += squareCorrelation(x, old[i], rowcount);
            }
            output = output / columncount;
            return output;
        }
        private static double[] schimidt(double[][] oldV, double[] newV, int oldcount, double[][] oldmius,int rowcount)
        {
            double[] output = new double[rowcount];
            double[] dps = new double[oldcount];
            for (int i = 0; i < oldcount; i++)
            {
                dps[i] = getDotProduct(newV, oldmius[i],rowcount);
            }
            for (int i = 0; i < rowcount; i++)
            {
                output[i] = newV[i];
                for (int j = 0; j < oldcount; j++)
                {
                    output[i] -= oldmius[j][i] * dps[j];
                }
            }
            return output;
        }
        private static double[] getMiu(double[] input,int rowcount)
        {
            double[] output = new double[rowcount];
            double dp = Math.Pow(getDotProduct(input,input,rowcount),0.5);
            for(int i=0;i<rowcount;i++)
            {
                output[i] = input[i] / dp;
            }
            return output;
        }
        private static double getDotProduct(double[] a,double[] b,int rowcount)
        {
            double output = 0;
            for(int i = 0;i<rowcount;i++)
            {
                output += a[i] * b[i];
            }
            return output;
        }
        private static double squareCorrelation(double[] x,double[] y,int rowcount)
        {
            double xy = 0;
            double xx = 0;
            double yy = 0;
            for (int i = 0; i < rowcount; i++)
            {
                xy += x[i] * y[i];
                xx += x[i] * x[i];
                yy += y[i] * y[i];
            }
            if (xx == 0 || yy == 0)
                return 0;
            else return xy * xy / (xx * yy);
        }
    }
}
