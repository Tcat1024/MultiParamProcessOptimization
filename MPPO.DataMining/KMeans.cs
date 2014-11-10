using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using MPPO.Protocol.Interface;
using MPPO.Protocol.Operation;

namespace MPPO.DataMining
{
    public class KMeans
    {
        public static ClusterReport<T> AutoZScoredStart<T>(IList<T> data, string[] properties, int maxCount) where T : new()
        {
            return AutoZScoredStart<T>(data, properties, maxCount, 2, Convert.ToInt32(Math.Pow(data.Count, 0.5)));
        }
        public static ClusterReport<T> AutoZScoredStart<T>(IList<T> data,string[] properties,int maxCount,int MinClusterCount,int MaxClusterCount) where T:new()
        {
            int paraCount = properties.Length;
            double[] mean = new double[paraCount];
            double[] v = new double[paraCount];
            for (int i = 0; i < paraCount; i++)
            {
                mean[i] = 0;
                v[i] = 1;
            }
            return AutoStart<T>(data, properties, maxCount, MinClusterCount, MaxClusterCount, mean, v);
        }
        public static ClusterReport<T> AutoStart<T>(IList<T> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount, double[] mean, double[] v) where T : new()
        {
            DateTime starttime = DateTime.Now;
            ClusterResult<T> clusterresult;
            ClusterAssessReport_BWP clusterassessreport;
            ClusterReport<T> finalreport = new ClusterReport<T>();
            double score = Double.NegativeInfinity;
            int maxscore = -1;
            for (int i = MinClusterCount; i <= MaxClusterCount; i++)
            {
                clusterresult = Start<T>(data, properties, i, maxCount, mean, v);
                clusterassessreport = Assess.GetBWP<T>(data, clusterresult);
                finalreport.HisResult.Add(clusterresult);
                finalreport.HisReport.Add(clusterassessreport);
                if (clusterassessreport.AvgBWP > score)
                {
                    score = clusterassessreport.AvgBWP;
                    maxscore = i;
                }
            }
            finalreport.FanialResult = finalreport.HisResult[maxscore - MinClusterCount];
            finalreport.FanialReport = finalreport.HisReport[maxscore - MinClusterCount];
            DateTime endtime = DateTime.Now;
            finalreport.TotalCostTime = (endtime - starttime).TotalMilliseconds;
            return finalreport;
        }
        public static ClusterReport<T> AutoZScoredParallelStart<T>(IList<T> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount) where T : new()
        {
            int paraCount = properties.Length;
            double[] mean = new double[paraCount];
            double[] v = new double[paraCount];
            for (int i = 0; i < paraCount; i++)
            {
                mean[i] = 0;
                v[i] = 1;
            }
            return AutoParallelStart<T>(data, properties, maxCount, MinClusterCount, MaxClusterCount, mean, v);
        }
        public static ClusterReport<T> AutoParallelStart<T>(IList<T> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount, double[] mean, double[] v) where T : new()
        {
            DateTime starttime = DateTime.Now;
            ClusterReport<T> finalreport = new ClusterReport<T>();
            Barrier barr = new Barrier(MaxClusterCount - MinClusterCount + 2);
            ParralFactory<T> factory = new ParralFactory<T>(finalreport, data, properties, maxCount, mean, v,barr);
            for (int i = MinClusterCount; i <= MaxClusterCount; i++)
            {
                Thread thd = new Thread(factory.StartThread);
                thd.Start(i);
            }
            barr.SignalAndWait();
            finalreport.FanialResult = finalreport.HisResult[factory.maxIndex];
            finalreport.FanialReport = finalreport.HisReport[factory.maxIndex];
            DateTime endtime = DateTime.Now;
            finalreport.TotalCostTime = (endtime - starttime).TotalMilliseconds;
            return finalreport;
        }
        private class ParralFactory<T> where T : new()
        {
            private double score = Double.NegativeInfinity;
            public int maxIndex = -1;
            private object SyObject = new object();
            private ClusterReport<T> finalreport;
            private IList<T> data;
            private string[] properties;
            private int maxCount;
            private double[] mean;
            private double[] v;
            private Barrier barr;
            public ParralFactory(ClusterReport<T> finalreport, IList<T> data,string[] properties,int maxCount,double[] mean,double[] v,Barrier barr)
            {
                this.finalreport = finalreport;
                this.data = data;
                this.properties = properties;
                this.maxCount = maxCount;
                this.mean = mean;
                this.v = v;
                this.barr = barr;
            }
            public void StartThread(object input)
            {
                int cCount = Convert.ToInt32(input);
                ClusterResult<T> clusterresult = Start<T>(this.data, this.properties, cCount, this.maxCount, this.mean, this.v);
                ClusterAssessReport_BWP clusterassessreport = Assess.GetBWP<T>(this.data, clusterresult);
                lock (this.SyObject)
                {
                    this.finalreport.HisResult.Add(clusterresult);
                    this.finalreport.HisReport.Add(clusterassessreport);
                    if (clusterassessreport.AvgBWP > this.score)
                    {
                        this.score = clusterassessreport.AvgBWP;
                        maxIndex = this.finalreport.HisReport.Count - 1;
                    }
                    this.barr.RemoveParticipant();
                }
            }
        }
        public static ClusterResult<T> ZScoredStart<T>(IList<T> data, string[] properties, int cCount, int maxCount) where T : new()
        {
            int paraCount = properties.Length;
            double[] mean = new double[paraCount];
            double[] v =new double[paraCount];
            for(int i =0;i<paraCount;i++)
            {
                mean[i] = 0;
                v[i]=1;
            }
            return Start<T>(data, properties, cCount,maxCount, mean, v);
        }
        public static ClusterResult<T> Start<T>(IList<T> data,string[] properties,int cCount,int maxCount,double[] mean,double[] v) where T:new()
        {
            DateTime starttime = DateTime.Now;
            int paraCount = properties.Length;
            if (data == null || properties == null||cCount < 2||paraCount!=mean.Length||paraCount!=v.Length)
                return null;
            Type dataType = typeof(T);
            int dataCount = data.Count;
            if (paraCount == 0 || dataCount == 0)
                return null;
            var result = new ClusterResult<T>();
            T[] center = new T[cCount];
            double[] w = new double[paraCount];
            for (int i = 0; i < paraCount;i++ )
            {
                w[i] = (double)1 / paraCount;
            }
            int[] classnumber = new int[dataCount];
            double odd = (double)2 / (cCount - 1);
            double eve = (double)2 / cCount;
            int count = 0;
            int[] reCount;
            InitCenter<T>(cCount, paraCount, properties, mean, v, odd, eve, center);
            while (true)
            {
                reCount = new int[cCount];
                bool fail = false;
                bool same = true;
                for (int i = 0; i < dataCount; i++)
                {
                    double[] len = new double[cCount];
                    int min = 0;
                    for (int j = 0; j < cCount; j++)
                    {
                        for (int k = 0; k < paraCount; k++)
                        {
                            len[j] += w[k] * Math.Pow(Convert.ToDouble(dataType.GetProperty(properties[k]).GetValue(data[i], null)) - Convert.ToDouble(dataType.GetProperty(properties[k]).GetValue(center[j], null)), 2);
                        }
                        if (len[j] < len[min])
                            min = j;
                    }
                    if (same && classnumber[i] != min)
                        same = false;
                    classnumber[i] = min;
                    reCount[min]++;
                }
                for (int i = 0; i < cCount; i++)
                {
                    if (reCount[i] == 0)
                    {
                        fail = true;
                        break;
                    }
                }
                if (fail)
                {
                    odd = odd / 2;
                    eve = eve / 2;
                    InitCenter<T>(cCount, paraCount, properties, mean, v, odd, eve, center);
                    continue;
                }
                count++;
                if (count >= maxCount || same)
                    break;
                ResetCenterAndWeights<T>(cCount, paraCount, properties, data, dataCount,mean, classnumber, reCount, center,w);      
            }
            result.Centers = center;
            result.ClassNumbers = classnumber;
            result.Weights = w;
            result.cCount = cCount;
            result.CountEachCluster = reCount;
            result.Properties = properties;
            DateTime endtime = DateTime.Now;
            result.CostTime = (endtime - starttime).TotalMilliseconds;
            return result;
        }
        private static void InitCenter<T>(int cCount,int paraCount, string[] properties,double[] mean,double[] v,double odd,double eve,T[] center) where T:new()
        {
            Type dataType = typeof(T);
            int halfcCount = cCount / 2;
            if (cCount % 2 == 1)
            {
                for (int i = 0; i < cCount; i++)
                {
                    var temp = new T();
                    for (int j = 0; j < paraCount; j++)
                    {
                        dataType.GetProperty(properties[j]).SetValue(temp, Convert.ToDouble(mean[j] + odd * v[j] * (-halfcCount + i)), null);
                    }
                    center[i] = temp;
                }
            }
            else
            {
                for (int i = 0; i < halfcCount; i++)
                {
                    var temp = new T();
                    for (int j = 0; j < paraCount; j++)
                    {
                        dataType.GetProperty(properties[j]).SetValue(temp, Convert.ToDouble(mean[j] + eve * v[j] * (-halfcCount + i)), null);
                    }
                    center[i] = temp;
                }
                for (int i = halfcCount + 1; i < cCount + 1; i++)
                {
                    var temp = new T();
                    for (int j = 0; j < paraCount; j++)
                    {
                        dataType.GetProperty(properties[j]).SetValue(temp, Convert.ToDouble(mean[j] + eve * v[j] * (-halfcCount + i)), null);
                    }
                    center[i - 1] = temp;
                }
            }
        }
        private static void ResetCenterAndWeights<T>(int cCount, int paraCount, string[] properties,IList<T> data,int dataCount,double[] mean,int[] result,int[] reCount,T[] center,double[] w) where T : new()
        {
            double[] d = new double[paraCount];
            double[,] newCenter = new double[cCount,paraCount];
            Type dataType = typeof(T);
            for(int i = 0;i<dataCount;i++)
            {
                var temp = data[i];
                int re = result[i];
                for(int j = 0;j<paraCount;j++)
                {
                    newCenter[re,j] += Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(temp, null));
                }
            }
            double[] dn = new double[paraCount];
            double[] dw = new double[paraCount];
            double[] cj = new double[paraCount];
            w = new double[paraCount]; 
            for(int i =0;i<cCount;i++)
            {
                var temp = center[i];
                int count = reCount[i];
                for(int j=0;j<paraCount;j++)
                {
                    newCenter[i, j] = newCenter[i, j] / count;
                    double newValue = newCenter[i, j];
                    dataType.GetProperty(properties[j]).SetValue(temp,newValue,null);
                    dw[j] += Math.Pow(newValue - mean[j], 2);
                }
            }
            for (int i = 0; i < dataCount-1; i++)
            {
                int re = result[i];
                var tempData = data[i];
                for (int j = 0; j < paraCount; j++)
                {
                    dn[j] += Math.Pow(Convert.ToDouble(dataType.GetProperty(properties[j]).GetValue(tempData, null)) - newCenter[re,j], 2);
                }
            }
            double cjSum = 0;
            for (int i = 0; i < paraCount; i++)
            {
                dn[i] += Math.Pow(Convert.ToDouble(dataType.GetProperty(properties[i]).GetValue(data[dataCount-1], null)) - newCenter[result[dataCount-1], i], 2);
                cj[i] = dw[i] / dn[i];
                cjSum += cj[i];
            }
            for (int i = 0; i < paraCount; i++)
            {
                w[i] = cj[i] / cjSum;
            }
        }


        /// <summary>
        /// 并行开始K均值聚类
        /// </summary>
        /// <param name="data">数据源</param>
        /// <param name="properties"> 聚类列集合</param>
        /// <param name="maxCount">单次聚类最大循环数</param>
        /// <param name="MinClusterCount">最小聚类数</param>
        /// <param name="MaxClusterCount">最大聚类数</param>
        /// <param name="mean">各列平均数</param>
        /// <param name="v">各列标准差</param>
        /// <param name="flags">用以查看当前进度</param>
        /// <param name="quick">是否采用快速聚类</param>
        /// <returns>聚类结果报告</returns>
        public static ClusterReport AutoParallelStart(IDataTable<DataRow> data, string[] properties, int maxCount, int MinClusterCount, int MaxClusterCount, double[] mean, double[] v, Protocol.Structure.WaitObject wt, int methodid)
        {
            DateTime starttime = DateTime.Now;
            ClusterReport finalreport = new ClusterReport();
            int threadcount = 15;
            int clustercount = MaxClusterCount - MinClusterCount + 1;
            if (clustercount < 15)
                threadcount = clustercount;
            Barrier barr = new Barrier(threadcount + 1);
            ParralFactory factory = new ParralFactory(finalreport, data, properties, maxCount, mean, v, barr);
            wt.Flags = new int[clustercount];
            wt.Max = clustercount * maxCount;
            for (int i = 0; i < threadcount; i++)
            {
                int num = i;
                new Thread((k) =>
                {
                    factory.Start(MinClusterCount + (int)k * clustercount / threadcount, MinClusterCount + ((int)k + 1) * clustercount / threadcount, wt.Flags, MinClusterCount, methodid);
                }) { IsBackground = true }.Start(num);
            }
            barr.SignalAndWait();
            finalreport.FanialResult = finalreport.HisResult[factory.maxIndex];
            finalreport.FanialReport = finalreport.HisReport[factory.maxIndex];
            DateTime endtime = DateTime.Now;
            finalreport.TotalCostTime = (endtime - starttime).TotalMilliseconds;
            return finalreport;
        }
        private class ParralFactory
        {
            private double score = Double.NegativeInfinity;
            public int maxIndex = -1;
            private object SyObject = new object();
            private ClusterReport finalreport;
            private IDataTable<DataRow> data;
            private string[] properties;
            private int maxCount;
            private double[] mean;
            private double[] v;
            private Barrier barr;
            public ParralFactory(ClusterReport finalreport, IDataTable<DataRow> data, string[] properties, int maxCount, double[] mean, double[] v, Barrier barr = null)
            {
                this.finalreport = finalreport;
                this.data = data;
                this.properties = properties;
                this.maxCount = maxCount;
                this.mean = mean;
                this.v = v;
                this.barr = barr;
            }
            public void Start(int start, int end, int[] flags, int min, int methodid)
            {
                for (int i = start; i < end; i++)
                {
                    int cCount = i;
                    ClusterResult clusterresult = null;
                    switch(methodid)
                    {
                        case 0:clusterresult = SingleStart(this.data, this.properties, cCount, this.maxCount, this.mean, this.v, ref flags[i - min]);break;
                        case 1:clusterresult = SingleImproveStart(this.data, this.properties, cCount, this.maxCount, this.mean, this.v, ref flags[i - min]);break;
                    }
                    ClusterAssessReport_BWP clusterassessreport = Assess.GetBWP(this.data, clusterresult);
                    lock (this.SyObject)
                    {
                        this.finalreport.HisResult.Add(clusterresult);
                        this.finalreport.HisReport.Add(clusterassessreport);
                        if (clusterassessreport.AvgBWP > this.score)
                        {
                            this.score = clusterassessreport.AvgBWP;
                            maxIndex = this.finalreport.HisReport.Count - 1;
                        }
                    }
                }
                if (barr != null)
                    this.barr.RemoveParticipant();
            }
        }
        public static ClusterResult SingleImproveStart(IDataTable<DataRow> data, string[] properties, int cCount, int maxCount, double[] mean, double[] v,ref int flag)
        {
            DateTime starttime = DateTime.Now;
            int paraCount = properties.Length;
            if (data == null || properties == null || cCount < 2 || paraCount != mean.Length || paraCount != v.Length)
                return null;
            int dataCount = data.RowCount;
            if (paraCount == 0 || dataCount == 0)
                return null;
            var result = new ClusterResult();
            double[,] center = new double[cCount, paraCount];
            double[] w = new double[paraCount];
            for (int i = 0; i < paraCount; i++)
            {
                w[i] = (double)1 / paraCount;
            }
            int[] classnumber = new int[dataCount];
            double odd = 2;
            int count = 0;
            int[] reCount;
            InitCenter(cCount, paraCount, properties, mean, v, odd, center,data);
            while (true)
            {
                reCount = new int[cCount];
                bool fail = false;
                bool same = true;
                for (int i = 0; i < dataCount; i++)
                {
                    double[] len = new double[cCount];
                    int min = 0;
                    for (int j = 0; j < cCount; j++)
                    {
                        for (int k = 0; k < paraCount; k++)
                        {
                            len[j] += w[k] * Math.Pow(data[i][properties[k]].ConvertToDouble() - center[j,k], 2);
                        }
                        if (len[j] < len[min])
                            min = j;
                    }
                    if (same && classnumber[i] != min)
                        same = false;
                    classnumber[i] = min;
                    reCount[min]++;
                }
                for (int i = 0; i < cCount; i++)
                {
                    if (reCount[i] == 0)
                    {
                        fail = true;
                        break;
                    }
                }
                if (fail)
                {
                    odd = odd / 2;
                    InitCenter(cCount, paraCount, properties, mean, v, odd, center,data);
                    continue;
                }
                count++;
                if (count >= maxCount || same)
                    break;
                ResetCenterAndWeights(cCount, paraCount, properties, data, dataCount, mean, classnumber, reCount,center,w);

                flag++;
            }
            result.Centers = center;
            result.ClassNumbers = classnumber;
            result.Weights = w;
            result.cCount = cCount;
            result.CountEachCluster = reCount;
            result.Properties = properties;
            result.LoopCount = count;
            DateTime endtime = DateTime.Now;
            result.CostTime = (endtime - starttime).TotalMilliseconds;
            flag = maxCount;
            return result;
        }
        public static ClusterResult SingleStart(IDataTable<DataRow> data, string[] properties, int cCount, int maxCount, double[] mean, double[] v, ref int flag)
        {
            DateTime starttime = DateTime.Now;
            int paraCount = properties.Length;
            if (data == null || properties == null || cCount < 2 || paraCount != mean.Length || paraCount != v.Length)
                return null;
            int dataCount = data.RowCount;
            if (paraCount == 0 || dataCount == 0)
                return null;
            var result = new ClusterResult();
            double[,] center = new double[cCount, paraCount];
            int[] classnumber = new int[dataCount];
            double odd = 2;
            int count = 0;
            int[] reCount;
            InitCenter(cCount, paraCount, properties, mean, v, odd, center, data);
            while (true)
            {
                reCount = new int[cCount];
                bool fail = false;
                bool same = true;
                for (int i = 0; i < dataCount; i++)
                {
                    double[] len = new double[cCount];
                    int min = 0;
                    for (int j = 0; j < cCount; j++)
                    {
                        for (int k = 0; k < paraCount; k++)
                        {
                            len[j] += Math.Pow(data[i][properties[k]].ConvertToDouble() - center[j, k], 2);
                        }
                        if (len[j] < len[min])
                            min = j;
                    }
                    if (same && classnumber[i] != min)
                        same = false;
                    classnumber[i] = min;
                    reCount[min]++;
                }
                for (int i = 0; i < cCount; i++)
                {
                    if (reCount[i] == 0)
                    {
                        fail = true;
                        break;
                    }
                }
                if (fail)
                {
                    odd = odd / 2;
                    InitCenter(cCount, paraCount, properties, mean, v, odd, center, data);
                    continue;
                }
                count++;
                if (count >= maxCount || same)
                    break;
                ResetCenter(cCount, paraCount, properties, data, dataCount, mean, classnumber, reCount,center);

                flag++;
            }
            result.Centers = center;
            result.ClassNumbers = classnumber;
            result.cCount = cCount;
            result.CountEachCluster = reCount;
            result.Properties = properties;
            result.LoopCount = count;
            DateTime endtime = DateTime.Now;
            result.CostTime = (endtime - starttime).TotalMilliseconds;
            flag = maxCount;
            return result;
        }
        private static void InitCenter(int cCount,int paraCount, string[] properties,double[] mean,double[] v,double odd,double[,] center,IDataTable<DataRow> data)
        {
            int halfcCount = cCount / 2;
            if (cCount % 2 == 1)
            {
                for (int i = 0; i < cCount; i++)
                {
                    for (int j = 0; j < paraCount; j++)
                    {
                        center[i,j] = (mean[j] + odd * v[j] * (-halfcCount + i)/(cCount-1)).ConvertToDouble();
                    }
                }
            }
            else
            {
                for (int i = 0; i < halfcCount; i++)
                {
                    for (int j = 0; j < paraCount; j++)
                    {
                        center[i,j] = (mean[j] + odd * v[j] * (-halfcCount + i)/cCount).ConvertToDouble();
                    }
                }
                for (int i = halfcCount + 1; i < cCount+1; i++)
                {
                    for (int j = 0; j < paraCount; j++)
                    {
                        center[i-1,j] = Convert.ToDouble(mean[j] + odd * v[j] * (-halfcCount + i) / cCount).ConvertToDouble();
                    }
                }
            }
        }
        private static void ResetCenterAndWeights(int cCount, int paraCount, string[] properties, IDataTable<DataRow> data, int dataCount, double[] mean, int[] result, int[] reCount,double[,] center,double[] w)
        {
            double[] d = new double[paraCount];
            double[,] newCenter = new double[cCount, paraCount];
            for (int i = 0; i < dataCount; i++)
            {
                var temp = data[i];
                int re = result[i];
                for (int j = 0; j < paraCount; j++)
                {
                    newCenter[re, j] += temp[properties[j]].ConvertToDouble();
                }
            }
            double[] dn = new double[paraCount];
            double[] dw = new double[paraCount];
            double[] cj = new double[paraCount];
            for (int i = 0; i < cCount; i++)
            {
                int count = reCount[i];
                for (int j = 0; j < paraCount; j++)
                {
                    newCenter[i, j] = newCenter[i, j] / count;
                    double newValue = newCenter[i, j];
                    center[i,j] = newValue;
                    dw[j] += Math.Pow(newValue - mean[j], 2);
                }
            }
            for (int i = 0; i < dataCount; i++)
            {
                int re = result[i];
                var tempData = data[i];
                for (int j = 0; j < paraCount; j++)
                {

                    dn[j] += Math.Pow(tempData[properties[j]].ConvertToDouble() - newCenter[re, j], 2);
                }
            }
            double cjSum = 0;
            for (int i = 0; i < paraCount; i++)
            {
                if (dn[i] == 0)
                    cj[i] = 0;
                else
                    cj[i] = dw[i] / dn[i];
                cjSum += cj[i];
            }
            for (int i = 0; i < paraCount; i++)
            {
                if (cjSum == 0)
                    w[i] = 0;
                else
                    w[i] = cj[i] / cjSum;
            }
        }
        private static void ResetCenter(int cCount, int paraCount, string[] properties, IDataTable<DataRow> data, int dataCount, double[] mean, int[] result, int[] reCount, double[,] center)
        {
            double[] d = new double[paraCount];
            double[,] newCenter = new double[cCount, paraCount];
            for (int i = 0; i < dataCount; i++)
            {
                var temp = data[i];
                int re = result[i];
                for (int j = 0; j < paraCount; j++)
                {
                    newCenter[re, j] += temp[properties[j]].ConvertToDouble();
                }
            }
            for (int i = 0; i < cCount; i++)
            {
                int count = reCount[i];
                for (int j = 0; j < paraCount; j++)
                {
                    newCenter[i, j] = newCenter[i, j] / count;
                    double newValue = newCenter[i, j];
                    center[i, j] = newValue;
                }
            }
        }
    }
}
