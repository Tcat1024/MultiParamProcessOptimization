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
        private double Score = Double.NegativeInfinity;
        private object SyObject = new object();
        private IDataTable<DataRow> Data;
        private string[] Properties;
        private int MaxCount;
        private Barrier Barobj;
        private double[,] Distences;
        private int DataCount;
        private int ParaCount;
        private int MaxClusterCount;
        private int MinClusterCount;
        private Protocol.Structure.WaitObject WaitObj;
        public int MaxThreadCount;
        private ClusterReport FinalReport;
        private double[] Mean;
        private double[] Stdev;
        private int InitialMode;
        private int MethodMode;
        private List<Thread> ThreadPool;
        public KMeans(object threadpool,IDataTable<DataRow> data, string[] properties, int maxcount, int minclustercount, int maxclustercount, double[] mean, double[] v, Protocol.Structure.WaitObject wt, int initialmode, int methodmode, int maxthread)
        {
            this.Data = data;
            this.Properties = properties;
            this.MaxCount = maxcount;
            this.DataCount = data.RowCount;
            this.ParaCount = properties.Length;
            this.Distences = new double[this.DataCount, this.ParaCount];
            this.MaxClusterCount = maxclustercount;
            this.MinClusterCount = minclustercount;
            this.WaitObj = wt;
            this.InitialMode = initialmode;
            this.MethodMode = methodmode;
            this.Mean = mean;
            this.Stdev = v;
            this.MaxThreadCount = maxthread;
            this.Distences = new double[DataCount, DataCount];
            this.ThreadPool = threadpool as List<Thread>;
            Parallel.For(0, this.DataCount - 1, new Action<int>((i) =>
            {
                for (int j = i + 1; j < this.DataCount; j++)
                {
                    var temp = Assess.GetEdistence(this.Data[i], this.Data[j], this.Properties, this.ParaCount);
                    this.Distences[i, j] = temp;
                    this.Distences[j, i] = temp;
                }
            }));
        }
        public ClusterReport ParallelStart()
        {
            DateTime starttime = DateTime.Now;
            this.FinalReport = new ClusterReport();
            int threadcount = MaxThreadCount;
            int clustercount = MaxClusterCount - MinClusterCount + 1;
            if (clustercount < MaxThreadCount)
                threadcount = clustercount;
            this.Barobj = new Barrier(threadcount + 1);
            WaitObj.Flags = new int[clustercount];
            WaitObj.Max = clustercount * MaxCount;
            for (int i = 0; i < threadcount; i++)
            {
                int num = i;
                var temp = new Thread((k) =>
                {
                    this.ThreadMethod(MinClusterCount + (int)k * clustercount / threadcount, MinClusterCount + ((int)k + 1) * clustercount / threadcount, MinClusterCount);
                }) { IsBackground = true };
                this.ThreadPool.Add(temp);
                temp.Start(num);
            }
            Barobj.SignalAndWait();
            DateTime endtime = DateTime.Now;
            FinalReport.TotalCostTime = (endtime - starttime).TotalMilliseconds;
            return FinalReport;
        }
        private void ThreadMethod(int start, int end, int min)
        {
            for (int i = start; i < end; i++)
            {
                int cCount = i;
                ClusterResult clusterresult = null;
                switch (this.MethodMode)
                {
                    case 0: clusterresult = SingleStart(cCount, ref this.WaitObj.Flags[i - min]); break;
                    case 1: clusterresult = SingleStartWithWeight(cCount, ref this.WaitObj.Flags[i - min]); break;
                }
                ClusterAssessReport_BWP clusterassessreport = Assess.GetBWP(Data, clusterresult, Distences);
                lock (this.SyObject)
                {
                    this.FinalReport.HisResult.Add(clusterresult);
                    this.FinalReport.HisReport.Add(clusterassessreport);
                    if (clusterassessreport.AvgBWP > this.Score)
                    {
                        this.Score = clusterassessreport.AvgBWP;
                        FinalReport.FanialResult = clusterresult;
                        FinalReport.FanialReport = clusterassessreport;
                    }
                }
            }
            if (Barobj != null)
                Barobj.RemoveParticipant();
        }

        public ClusterResult SingleStart(int cCount, ref int flag)
        {
            DateTime starttime = DateTime.Now;
            var result = new ClusterResult();
            double[,] center = new double[cCount, ParaCount];
            int[] classnumber = new int[DataCount];
            int count = 0;
            int i, j, k;
            int[] reCount;
            bool same;
            int fail;
            double odd =2;
            switch(InitialMode)
            {
                case 0: InitCenter(cCount, center); break;
                case 1: InitCenterSPSS(cCount, center); break;
                case 2: InitCenterAvg(cCount, odd, center); break;
            }
           
            while (true)
            {
                reCount = new int[cCount];
                same = true;
                for (i = 0; i < DataCount; i++)
                {
                    double[] len = new double[cCount];
                    int min = 0;
                    for (j = 0; j < cCount; j++)
                    {
                        for (k = 0; k < ParaCount; k++)
                        {
                            len[j] += Math.Pow(Data[i][Properties[k]].ConvertToDouble() - center[j, k], 2);
                        }
                        if (len[j] < len[min])
                            min = j;
                    }
                    if (same && classnumber[i] != min)
                        same = false;
                    classnumber[i] = min;
                    reCount[min]++;
                }
                if (InitialMode == 2 && count == 0)
                {
                    fail = 0;
                    for (i = 0; i < cCount; i++)
                    {
                        if (reCount[i] == 0)
                        {
                            fail++;
                            if (fail > cCount / 10)
                                break;
                        }
                    }
                    if (fail > cCount / 10)
                    {
                        odd = odd / 2;
                        InitCenterAvg(cCount, odd, center);
                        continue;
                    }
                }
                count++;
                if (count >= MaxCount || same)
                    break;
                ResetCenter(cCount, classnumber, reCount, center);
                flag++;
            }
            result.Centers = center;
            result.ClassNumbers = classnumber;
            result.cCount = cCount;
            result.Properties = Properties;
            result.LoopCount = count;
            result.CountEachCluster = reCount;
            DateTime endtime = DateTime.Now;
            result.CostTime = (endtime - starttime).TotalMilliseconds;
            flag = MaxCount;
            return result;
        }

        public ClusterResult SingleStartWithWeight(int cCount, ref int flag)
        {
            DateTime starttime = DateTime.Now;
            var result = new ClusterResult();
            double[,] center = new double[cCount, ParaCount];
            double[] w = new double[ParaCount];
            int[] reCount;
            int i, j, k;
            for (i = 0; i < ParaCount; i++)
            {
                w[i] = (double)1 / ParaCount;
            }
            int[] classnumber = new int[DataCount];
            int count = 0;
            bool same;
            int fail;
            double odd = 2;
            switch (InitialMode)
            {
                case 0: InitCenter(cCount, center); break;
                case 1: InitCenterSPSS(cCount, center); break;
                case 2: InitCenterAvg(cCount, odd, center); break;
            }
            while (true)
            {
                reCount = new int[cCount];
                same = true;
                for (i = 0; i < DataCount; i++)
                {
                    double[] len = new double[cCount];
                    int min = 0;
                    for (j = 0; j < cCount; j++)
                    {
                        for (k = 0; k < ParaCount; k++)
                        {
                            len[j] += w[k] * Math.Pow(Data[i][Properties[k]].ConvertToDouble() - center[j, k], 2);
                        }
                        if (len[j] < len[min])
                            min = j;
                    }
                    if (same && classnumber[i] != min)
                        same = false;
                    classnumber[i] = min;
                    reCount[min]++;
                }
                if (InitialMode == 2 && count == 0)
                {
                    fail = 0;
                    for (i = 0; i < cCount; i++)
                    {
                        if (reCount[i] == 0)
                        {
                            fail++;
                            if (fail > cCount / 10)
                                break;
                        }
                    }
                    if (fail > cCount / 10)
                    {
                        odd = odd / 2;
                        InitCenterAvg(cCount, odd, center);
                        continue;
                    }
                }
                count++;
                if (count >= MaxCount || same)
                    break;
                ResetCenterAndWeights(cCount, classnumber, reCount, center, w);
                flag++;
            }
            result.Centers = center;
            result.ClassNumbers = classnumber;
            result.Weights = w;
            result.cCount = cCount;
            result.Properties = Properties;
            result.LoopCount = count;
            result.CountEachCluster = reCount;
            DateTime endtime = DateTime.Now;
            result.CostTime = (endtime - starttime).TotalMilliseconds;
            flag = MaxCount;
            return result;
        }
        private void InitCenter(int cCount, double[,] center)
        {
            Random maker = new Random();
            int index, i, j;
            List<int> indexs = new List<int>();
            for (i = 0; i < cCount; i++)
            {
                do
                {
                    index = maker.Next(DataCount);
                } while (indexs.Contains(index));
                indexs.Add(index);
                var temprow = Data[index];
                for (j = 0; j < ParaCount; j++)
                {
                    center[i, j] = temprow[Properties[j]].ConvertToDouble();
                }
            }
        }
        
        private void InitCenterAvg(int cCount,double odd, double[,] center)
        {
            int halfcCount = cCount / 2;
            if (cCount % 2 == 1)
            {
                for (int i = 0; i < cCount; i++)
                {
                    for (int j = 0; j <ParaCount ; j++)
                    {
                        center[i, j] = (Mean[j] + odd * Stdev[j] * (-halfcCount + i) / (cCount - 1)).ConvertToDouble();
                    }
                }
            }
            else
            {
                for (int i = 0; i < halfcCount; i++)
                {
                    for (int j = 0; j < ParaCount; j++)
                    {
                        center[i, j] = (Mean[j] + odd * Stdev[j] * (-halfcCount + i) / cCount).ConvertToDouble();
                    }
                }
                for (int i = halfcCount + 1; i < cCount + 1; i++)
                {
                    for (int j = 0; j < ParaCount; j++)
                    {
                        center[i - 1, j] = Convert.ToDouble(Mean[j] + odd * Stdev[j] * (-halfcCount + i) / cCount).ConvertToDouble();
                    }
                }
            }
        }
        private void InitCenterSPSS(int cCount, double[,] center)
        {
            int i, j, a, b, f, s;
            double mindxm, temp, minqi, fd, sd;
            int[] centers = new int[cCount];
            string[] ab;
            SortedList<double, string> centerdistence = new SortedList<double, string>(new DistenceCompare());
            for (i = 0; i < cCount; i++)
            {
                centers[i] = i;
            }
            for (i = 0; i < cCount - 1; i++)
            {
                for (j = i + 1; j < cCount; j++)
                {
                    centerdistence.Add(Distences[i, j], i + "," + j);
                }
            }
            for (i = cCount; i < DataCount; i++)
            {
                mindxm = Distences[i, centers[0]];
                for (j = 1; j < cCount; j++)
                {
                    temp = Distences[i, centers[j]];
                    if (mindxm > temp)
                        mindxm = temp;
                }
                if (mindxm > centerdistence.Keys[0])
                {
                    ab = centerdistence.Values[0].Split(',');
                    a = Convert.ToInt32(ab[0]);
                    b = Convert.ToInt32(ab[1]);
                    int target = a;
                    if (Distences[i, centers[a]] > Distences[i, centers[b]])
                        target = b;
                    centers[target] = i;
                    for (j = 0; j < target; j++)
                    {
                        centerdistence.RemoveAt(centerdistence.IndexOfValue(j + "," + target));
                        centerdistence.Add(Distences[centers[j], i], j + "," + target);
                    }
                    for (j = target + 1; j < cCount; j++)
                    {
                        centerdistence.RemoveAt(centerdistence.IndexOfValue(target + "," + j));
                        centerdistence.Add(Distences[centers[j], i], target + "," + j);
                    }
                }
                else
                {
                    if (Distences[i, centers[0]] > Distences[i, centers[1]])
                    {
                        f = 1;
                        s = 0;
                        fd = Distences[i, centers[1]];
                        sd = Distences[i, centers[0]];
                    }
                    else
                    {
                        f = 0;
                        s = 1;
                        fd = Distences[i, centers[0]];
                        sd = Distences[i, centers[1]];
                    }
                    for (j = 2; j < cCount; j++)
                    {
                        temp = Distences[i, j];
                        if (temp < fd)
                        {
                            f = j;
                            fd = temp;
                        }
                        else if (temp < sd)
                        {
                            s = j;
                            sd = temp;
                        }
                    }
                    minqi = 0;
                    for (j = 0; j < centerdistence.Count; j++)
                    {
                        if (centerdistence.Values[j].Split(',').Contains(f.ToString()))
                        {
                            minqi = centerdistence.Keys[j];
                        }
                    }
                    if (sd > minqi)
                    {
                        centers[f] = i;
                        for (j = 0; j < f; j++)
                        {
                            centerdistence.RemoveAt(centerdistence.IndexOfValue(j + "," + f));
                            centerdistence.Add(Distences[centers[j], i], j + "," + f);
                        }
                        for (j = f + 1; j < cCount; j++)
                        {
                            centerdistence.RemoveAt(centerdistence.IndexOfValue(f + "," + j));
                            centerdistence.Add(Distences[centers[j], i], f + "," + j);
                        }
                    }
                }
            }
            for (i = 0; i < cCount; i++)
            {
                for (j = 0; j < ParaCount; j++)
                {
                    center[i, j] = Data[centers[i]][Properties[j]].ConvertToDouble();
                }
            }
        }
        private class DistenceCompare : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                if (x < y)
                    return -1;
                return 1;
            }
        }
        private void ResetCenter(int cCount, int[] classnumber, int[] reCount, double[,] center)
        {
            double[] d = new double[ParaCount];
            double[,] newCenter = new double[cCount, ParaCount];
            for (int i = 0; i < DataCount; i++)
            {
                var temp = Data[i];
                int re = classnumber[i];
                for (int j = 0; j < ParaCount; j++)
                {
                    newCenter[re, j] += temp[Properties[j]].ConvertToDouble();
                }
            }
            for (int i = 0; i < cCount; i++)
            {
                int count = reCount[i];
                for (int j = 0; j < ParaCount; j++)
                {
                    newCenter[i, j] = newCenter[i, j] / count;
                    double newValue = newCenter[i, j];
                    center[i, j] = newValue;
                }
            }
        }
        private void ResetCenterAndWeights(int cCount, int[] result, int[] reCount, double[,] center, double[] w)
        {
            double[] d = new double[ParaCount];
            double[,] newCenter = new double[cCount, ParaCount];
            for (int i = 0; i < DataCount; i++)
            {
                var temp = Data[i];
                int re = result[i];
                for (int j = 0; j < ParaCount; j++)
                {
                    newCenter[re, j] += temp[Properties[j]].ConvertToDouble();
                }
            }
            double[] dn = new double[ParaCount];
            double[] dw = new double[ParaCount];
            double[] cj = new double[ParaCount];
            for (int i = 0; i < cCount; i++)
            {
                int count = reCount[i];
                for (int j = 0; j < ParaCount; j++)
                {
                    if (count != 0)
                    {
                        center[i, j] = newCenter[i, j] / count;
                        dw[j] += Math.Pow(center[i, j] - Mean[j], 2);
                    }
                }
            }
            for (int i = 0; i < DataCount; i++)
            {
                int re = result[i];
                var tempData = Data[i];
                for (int j = 0; j < ParaCount; j++)
                {
                    dn[j] += Math.Pow(tempData[Properties[j]].ConvertToDouble() - center[re, j], 2);
                }
            }
            double cjSum = 0;
            for (int i = 0; i < ParaCount; i++)
            {
                if (dn[i] == 0)
                    cj[i] = 0;
                else
                    cj[i] = dw[i] / dn[i];
                cjSum += cj[i];
            }
            for (int i = 0; i < ParaCount; i++)
            {
                if (cjSum == 0)
                    w[i] = 0;
                else
                    w[i] = cj[i] / cjSum;
            }
        }
    }
}
