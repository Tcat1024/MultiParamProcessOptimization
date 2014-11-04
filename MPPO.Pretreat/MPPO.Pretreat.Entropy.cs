using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Protocol.Operation;

namespace MPPO.Pretreat
{
    public class Entropy
    {
        public static double[] GetEntropy<T>(IList<T> data,string[] properties)
        {
            if (data == null || properties == null)
                return null;
            Type dataType = typeof(T);
            int paraCount = properties.Length;
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return null;
            double[] result = new double[paraCount];
            List<double>[] distinct = new List<double>[paraCount];
            List<int>[] distinctCount = new List<int>[paraCount];
            for(int i = 0;i<paraCount;i++)
            {
                distinct[i] = new List<double>();
                distinctCount[i] = new List<int>();
                for (int j = 0; j < dataCount; j++)
                {
                     var temp = data[j];
                     var value = Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null));
                    var index = distinct[i].IndexOf(value);
                    if (index == -1)
                    {
                        distinct[i].Add(value);
                        distinctCount[i].Add(1);
                    }
                    else
                    {
                        distinctCount[i][index]++;
                    }
                }
                int disLength = distinctCount[i].Count;
                for(int k =0;k<disLength;k++)
                {
                    int c = distinctCount[i][k];
                    double p = (double)c / dataCount;
                    result[i] += p * Math.Log(p, 2);
                }
                result[i] = -result[i];
            }
            return result;
        }

        public static double[] GetEntropy(MPPO.Protocol.Interface.IDataTable data, string[] sparams)
        {
            if (data == null || sparams == null)
                return null;
            int paraCount = sparams.Length;
            int dataCount = data.Count();
            if (paraCount == 0 || dataCount == 0)
                return null;
            double[] result = new double[paraCount];
            List<double>[] distinct = new List<double>[paraCount];
            List<int>[] distinctCount = new List<int>[paraCount];
            for (int i = 0; i < paraCount; i++)
            {
                distinct[i] = new List<double>();
                distinctCount[i] = new List<int>();
                string sparam = sparams[i];
                for (int j = 0; j < dataCount; j++)
                {
                    var temp = data[j];
                    var value = (temp as DataRow)[sparam].ConvertToDouble();
                    var index = distinct[i].IndexOf(value);
                    if (index == -1)
                    {
                        distinct[i].Add(value);
                        distinctCount[i].Add(1);
                    }
                    else
                    {
                        distinctCount[i][index]++;
                    }
                }
                int disLength = distinctCount[i].Count;
                for (int k = 0; k < disLength; k++)
                {
                    int c = distinctCount[i][k];
                    double p = (double)c / dataCount;
                    result[i] += p * Math.Log(p, 2);
                }
                result[i] = -result[i];
            }
            return result;
        }
    }
}
