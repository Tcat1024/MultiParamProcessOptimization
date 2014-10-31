using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MPPO.Pretreat
{
    public class Standardization
    {
        public static void Zscore<T>(IList<T> data,string[] properties)
        {
            if (data == null || properties == null)
                return;
            Type dataType = typeof(T);
            int paraCount = properties.Length;
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return;
            double[] sums = new double[paraCount];
            double[] avg = new double[paraCount];
            double[] sdv = new double[paraCount];
            try
            {
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        var temp = data[j];
                        sums[i] += Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null));
                    }
                    avg[i] = sums[i] / dataCount;
                }
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        var temp = data[j];
                        sdv[i] += Math.Pow((Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null)) - avg[i]), 2);
                    }
                    sdv[i] = Math.Pow(sdv[i] / dataCount, 0.5);
                }
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        var temp = data[j];
                        double newValue = ((Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null))) - avg[i]) / sdv[i];
                        dataType.GetProperty(properties[i]).SetValue(temp, newValue, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.Assert(false, ex.Message);
            }
        }
        public static void Zscore<T>(IList<T> data, IList<T> result, string[] properties)
        {
            if (data == null || properties == null || result == null)
                return;
            Type dataType = typeof(T);
            int paraCount = properties.Length;
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return;
            double[] sums = new double[paraCount];
            double[] avg = new double[paraCount];
            double[] sdv = new double[paraCount];
            try
            {
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        var temp = data[j];
                        sums[i] += Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null));
                    }
                    avg[i] = sums[i] / dataCount;
                }
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        var temp = data[j];
                        sdv[i] += Math.Pow((Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(temp, null)) - avg[i]), 2);
                    }
                    sdv[i] = Math.Pow(sdv[i] / dataCount, 0.5);
                }
                for (int i = 0; i < paraCount; i++)
                {
                    for (int j = 0; j < dataCount; j++)
                    {
                        double newValue = ((Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(data[j], null))) - avg[i]) / sdv[i];
                        dataType.GetProperty(properties[i]).SetValue(result[j], newValue, null);
                    }
                }
            }
            catch(Exception ex)
            {
                Trace.Assert(false, ex.Message);
            }
        }
        public static void Zscore2<T>(IList<T> data, IList<T> result, string[] properties)
        {
            if (data == null || properties == null || result == null)
                return;
            Type dataType = typeof(T);
            int paraCount = properties.Length;
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return;
            double[] sums = new double[paraCount];
            double[] avg = new double[paraCount];
            double[] sdv = new double[paraCount];
            try
            {
                for (int i = 0; i < dataCount; i++)
                {
                    var temp = data[i];
                    for (int j = 0; j < paraCount; j++)
                    {
                        avg[j] += Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(temp, null)) / dataCount;
                    }
                }
                //for (int j = 0; j < paraCount; j++)
                //{
                //    avg[j] = sums[j] / dataCount;
                //}
                for (int i = 0; i < dataCount; i++)
                {
                    var temp = data[i];
                    for (int j = 0; j < paraCount; j++)
                    {
                        sdv[j] += Math.Pow((Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(temp, null)) - avg[j]), 2);
                    }
                    
                }
                for (int j = 0; j < paraCount; j++)
                {
                    sdv[j] = Math.Pow(sdv[j] / dataCount, 0.5);
                }
                for (int i = 0; i < dataCount; i++)
                {
                    for (int j = 0; j < paraCount; j++)
                    {
                        double newValue = ((Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(data[i], null))) - avg[j]) / sdv[j];
                        dataType.GetProperty(properties[j]).SetValue(result[i], newValue, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.Assert(false, ex.Message);
            }
        }
        public static void GetAvgSdv<T>(IList<T> data, string[] properties,double[] mean,double[] v)
        {
            if (data == null || properties == null)
                return;
            Type dataType = typeof(T);
            int paraCount = properties.Length;
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return;
            double[] sums = new double[paraCount];
            try
            {
                for (int i = 0; i < dataCount; i++)
                {
                    var temp = data[i];
                    for (int j = 0; j < paraCount; j++)
                    {
                        mean[j] += Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(temp, null)) / dataCount;
                    }
                }
                //for (int j = 0; j < paraCount; j++)
                //{
                //    avg[j] = sums[j] / dataCount;
                //}
                for (int i = 0; i < dataCount; i++)
                {
                    var temp = data[i];
                    for (int j = 0; j < paraCount; j++)
                    {
                        v[j] += Math.Pow((Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(temp, null)) - mean[j]), 2);
                    }

                }
                for (int j = 0; j < paraCount; j++)
                {
                    v[j] = Math.Pow(v[j] / dataCount, 0.5);
                }
            }
            catch (Exception ex)
            {
                Trace.Assert(false, ex.Message);
            }
        }
    }

}
