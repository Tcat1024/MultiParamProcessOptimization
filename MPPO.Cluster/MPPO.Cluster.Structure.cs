using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Cluster
{
    public class ClusterResult<T>
    {
        public int cCount { get; set; }
        public T[] Centers { get; set; }
        public double[] Weights { get; set; }
        public int[] ClassNumbers { get; set; }
        public int[] CountEachCluster { get; set; }
        public string[] Properties { get; set; }
        public double CastTime { get; set; }
    }
    public class ClusterAssessReport_BWP
    {
        public double AvgBWP { get; set; }
        public double[] B { get; set; }
        public double[] W { get; set; }
        public double[] BWP { get; set; }
    }
    public class ClusterReport<T>
    {
        public ClusterResult<T> FanialResult { get; set; }
        public ClusterAssessReport_BWP FanialReport { get; set; }
        public double TotalCastTime { get; set; }
        private List<ClusterResult<T>> _HisResult = new List<ClusterResult<T>>();
        public List<ClusterResult<T>> HisResult
        {
            get
            {
                return this._HisResult;
            }
        }
        private List<ClusterAssessReport_BWP> _HisReport = new List<ClusterAssessReport_BWP>();
        public List<ClusterAssessReport_BWP> HisReport
        {
            get
            {
                return this._HisReport;
            }
        }
    }
}
