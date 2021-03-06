﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPPO.DataMining
{
    public class ClusterResult
    {
        public int cCount { get; set; }
        public double[,] Centers { get; set; }
        public double[] Weights { get; set; }
        public int[] ClassNumbers { get; set; }
        public int[] CountEachCluster { get; set; }
        public string[] Properties { get; set; }
        public int LoopCount { get; set; }
        public double CostTime { get; set; }
    }
    public class ClusterAssessReport_BWP
    {
        public double AvgBWP { get; set; }
        public double[] B { get; set; }
        public double[] W { get; set; }
        public double[] BWP { get; set; }
    }
    public class ClusterReport
    {
        public ClusterResult FanialResult { get; set; }
        public ClusterAssessReport_BWP FanialReport { get; set; }
        public double TotalCostTime { get; set; }
        private List<ClusterResult> _HisResult = new List<ClusterResult>();
        public List<ClusterResult> HisResult
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
