using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MPPO.Test
{
    public static class DataAccess
    {
        private const string lyqstr = "Provider=MSDAORA.1;Password=lyq;User ID=lyq;Data Source=LGORD;Persist Security Info=True";
        public static List<KRHeatInfo> GetKRHeatInfo(string HeatID)
        {
            List<KRHeatInfo> LST = new List<KRHeatInfo>();
            KRHeatInfo lst = new KRHeatInfo(); KRHeatInfo_Ini(ref lst);
            object obj = new object();

            /////// 各种事件/////////////////
            string strSQL = "SELECT * FROM KR_Heat WHERE Heat_ID> '" + HeatID + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new KRHeatInfo(); KRHeatInfo_Ini(ref lst);

                obj = dt.Rows[RowIndex]["Heat_ID"]; if (obj.ToString().Length > 0) lst.HEAT_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["IRON_ID"]; if (obj.ToString().Length > 0) lst.IRON_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["DES_STATION_NO"]; if (obj.ToString().Length > 0) lst.DES_STATION_NO = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["PLAN_NO"]; if (obj.ToString().Length > 0) lst.PLAN_NO = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["PONO"]; if (obj.ToString().Length > 0) lst.PONO = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["STEEL_GRADE"]; if (obj.ToString().Length > 0) lst.STEEL_GRADE = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["AIM_S"]; if (obj.ToString().Length > 0) lst.AIM_S = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["DES_STEP_NUM"]; if (obj.ToString().Length > 0) lst.DES_STEP_NUM = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["IRON_LADLE_ID"]; if (obj.ToString().Length > 0) lst.IRON_LADLE_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_TEMP"]; if (obj.ToString().Length > 0) lst.INI_TEMP = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["INI_WGT"]; if (obj.ToString().Length > 0) lst.INI_WGT = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_C"]; if (obj.ToString().Length > 0) lst.INI_C = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_SI"]; if (obj.ToString().Length > 0) lst.INI_SI = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_MN"]; if (obj.ToString().Length > 0) lst.INI_MN = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_P"]; if (obj.ToString().Length > 0) lst.INI_P = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["INI_S"]; if (obj.ToString().Length > 0) lst.INI_S = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["INI_TI"]; if (obj.ToString().Length > 0) lst.INI_TI = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["FIN_TEMP"]; if (obj.ToString().Length > 0) lst.FIN_TEMP = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["FIN_WGT"]; if (obj.ToString().Length > 0) lst.FIN_WGT = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["MATERIALID_ACT"]; if (obj.ToString().Length > 0) lst.MATERIALID_ACT = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["ADDWGT_ACT"]; if (obj.ToString().Length > 0) lst.ADDWGT_ACT = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_DURATION"]; if (obj.ToString().Length > 0) lst.STIRRER_DURATION = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_SPEED_MAX"]; if (obj.ToString().Length > 0) lst.STIRRER_SPEED_MAX = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_SPEED_MIN"]; if (obj.ToString().Length > 0) lst.STIRRER_SPEED_MIN = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_SPEED_AVG"]; if (obj.ToString().Length > 0) lst.STIRRER_SPEED_AVG = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["STIRRER_HEIGHT_MAX"]; if (obj.ToString().Length > 0) lst.STIRRER_HEIGHT_MAX = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_HEIGHT_MIN"]; if (obj.ToString().Length > 0) lst.STIRRER_HEIGHT_MIN = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_HEIGHT_AVG"]; if (obj.ToString().Length > 0) lst.STIRRER_HEIGHT_AVG = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_ID"]; if (obj.ToString().Length > 0) lst.STIRRER_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["STIRRER_TIMES"]; if (obj.ToString().Length > 0) lst.STIRRER_TIMES = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["LADLE_ARRIVE"]; if (obj.ToString().Length > 0) lst.LADLE_ARRIVE = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["LADLE_LEAVE"]; if (obj.ToString().Length > 0) lst.LADLE_LEAVE = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["DES_START"]; if (obj.ToString().Length > 0) lst.DES_START = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["DES_END"]; if (obj.ToString().Length > 0) lst.DES_END = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_FIRST_S"]; if (obj.ToString().Length > 0) lst.RESIDUE_FIRST_S = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["RESIDUE_FIRST_E"]; if (obj.ToString().Length > 0) lst.RESIDUE_FIRST_E = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_FIRST_DURATION"]; if (obj.ToString().Length > 0) lst.RESIDUE_FIRST_DURATION = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_FIRST_SLAG_WGT"]; if (obj.ToString().Length > 0) lst.RESIDUE_FIRST_SLAG_WGT = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_LAST_S"]; if (obj.ToString().Length > 0) lst.RESIDUE_LAST_S = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_LAST_E"]; if (obj.ToString().Length > 0) lst.RESIDUE_LAST_E = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["RESIDUE_LAST_DURATION"]; if (obj.ToString().Length > 0) lst.RESIDUE_LAST_DURATION = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["RESIDUE_LAST_SLAG_WGT"]; if (obj.ToString().Length > 0) lst.RESIDUE_LAST_SLAG_WGT = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["CALEFACIENT_USED"]; if (obj.ToString().Length > 0) lst.CALEFACIENT_USED = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["DES_DURATION"]; if (obj.ToString().Length > 0) lst.DES_DURATION = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["PRODUCE_DATE"]; if (obj.ToString().Length > 0) lst.PRODUCE_DATE = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["CREW_ID"]; if (obj.ToString().Length > 0) lst.CREW_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["SHIFT_ID"]; if (obj.ToString().Length > 0) lst.SHIFT_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["VALID_FLAG"]; if (obj.ToString().Length > 0) lst.VALID_FLAG = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["PERIOD_ID"]; if (obj.ToString().Length > 0) lst.PERIOD_ID = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["LADLE_WEIGHT"]; if (obj.ToString().Length > 0) lst.LADLE_WEIGHT = Convert.ToString(obj);

                obj = dt.Rows[RowIndex]["TEMP_TIME_F"]; if (obj.ToString().Length > 0) lst.TEMP_TIME_F = Convert.ToString(obj);
                obj = dt.Rows[RowIndex]["TEMP_TIME_E"]; if (obj.ToString().Length > 0) lst.TEMP_TIME_E = Convert.ToString(obj);

                LST.Add(lst);
            }
            dt.Dispose();

            return LST;
        }
        public static void KRHeatInfo_Ini(ref KRHeatInfo lst)
        {
            lst.HEAT_ID = " "; lst.IRON_ID = " "; lst.DES_STATION_NO = " "; lst.PLAN_NO = " ";
            lst.PONO = " "; lst.STEEL_GRADE = " "; lst.AIM_S = " "; lst.DES_STEP_NUM = " ";
            lst.IRON_LADLE_ID = " "; lst.INI_TEMP = " "; lst.INI_WGT = " "; lst.INI_C = " ";
            lst.INI_SI = " "; lst.INI_MN = " "; lst.INI_P = " "; lst.INI_S = " ";
            lst.INI_TI = " "; lst.FIN_TEMP = " "; lst.FIN_WGT = " "; lst.MATERIALID_ACT = " ";
            lst.ADDWGT_ACT = " "; lst.STIRRER_DURATION = " "; lst.STIRRER_SPEED_MAX = " "; lst.STIRRER_SPEED_MIN = " ";
            lst.STIRRER_SPEED_AVG = " "; lst.STIRRER_HEIGHT_MAX = " "; lst.STIRRER_HEIGHT_MIN = " ";
            lst.STIRRER_HEIGHT_AVG = " "; lst.STIRRER_ID = " "; lst.STIRRER_TIMES = " "; lst.LADLE_ARRIVE = " ";
            lst.LADLE_LEAVE = " "; lst.DES_START = " "; lst.DES_END = " "; lst.RESIDUE_FIRST_S = " ";
            lst.RESIDUE_FIRST_E = " "; lst.RESIDUE_FIRST_DURATION = " "; lst.RESIDUE_FIRST_SLAG_WGT = " ";
            lst.RESIDUE_LAST_S = " "; lst.RESIDUE_LAST_E = " "; lst.RESIDUE_LAST_DURATION = " ";
            lst.RESIDUE_LAST_SLAG_WGT = " "; lst.CALEFACIENT_USED = " "; lst.DES_DURATION = " ";
            lst.PRODUCE_DATE = " "; lst.CREW_ID = " "; lst.SHIFT_ID = " ";
            lst.VALID_FLAG = " "; lst.PERIOD_ID = " "; lst.LADLE_WEIGHT = " "; lst.TEMP_TIME_F = " ";
            lst.TEMP_TIME_E = " ";
        }

        //获取脱硫站KR 化学分析、测温、加料等关键事件
        public static List<KRKeyEvents> GetKRKeyEvents(string HeatID)
        {
            List<KRKeyEvents> LST = new List<KRKeyEvents>();
            KRKeyEvents lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
            string str = "";

            //为了计算Duration而设置
            DateTime StartDateTime = new DateTime();

            //获取化验成分事件
            string strSQL = "select * FROM elem_ana where Heat_ID='" + HeatID + "' and DEVICE_NO like 'LY210_KR%'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);

            if (dt.Rows.Count > 0)
            {
                int RowIndex = 0;

                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                lst.Descripion = "化验值" + RowIndex.ToString();

                //str = dt.Rows[RowIndex][""].ToString();if (str.Length>0) lst=str;
                str = dt.Rows[RowIndex]["sampletime"].ToString(); if (str.Length > 0) lst.DateAndTime = str;
                str = dt.Rows[RowIndex]["Ele_C"].ToString(); if (str.Length > 0) lst.Ele_C = str;
                str = dt.Rows[RowIndex]["Ele_Si"].ToString(); if (str.Length > 0) lst.Ele_Si = str;
                str = dt.Rows[RowIndex]["Ele_Mn"].ToString(); if (str.Length > 0) lst.Ele_Mn = str;

                str = dt.Rows[RowIndex]["Ele_S"].ToString(); if (str.Length > 0) lst.Ele_S = str;
                str = dt.Rows[RowIndex]["Ele_P"].ToString(); if (str.Length > 0) lst.Ele_P = str;
                str = dt.Rows[RowIndex]["Ele_Cu"].ToString(); if (str.Length > 0) lst.Ele_Cu = str;
                str = dt.Rows[RowIndex]["Ele_As"].ToString(); if (str.Length > 0) lst.Ele_As = str;
                str = dt.Rows[RowIndex]["Ele_Sn"].ToString(); if (str.Length > 0) lst.Ele_Sn = str;

                lst.Ele_Cu5As8Sn = (Convert.ToSingle(lst.Ele_Cu) + 5 * Convert.ToSingle(lst.Ele_As) + 8 * Convert.ToSingle(lst.Ele_Sn)).ToString();
                str = dt.Rows[RowIndex]["Ele_Cr"].ToString(); if (str.Length > 0) lst.Ele_Cr = str;
                str = dt.Rows[RowIndex]["Ele_Ni"].ToString(); if (str.Length > 0) lst.Ele_Ni = str;
                str = dt.Rows[RowIndex]["Ele_Mo"].ToString(); if (str.Length > 0) lst.Ele_Mo = str;

                str = dt.Rows[RowIndex]["Ele_Ti"].ToString(); if (str.Length > 0) lst.Ele_Ti = str;
                str = dt.Rows[RowIndex]["Ele_Nb"].ToString(); if (str.Length > 0) lst.Ele_Nb = str;
                str = dt.Rows[RowIndex]["Ele_Pb"].ToString(); if (str.Length > 0) lst.Ele_Pb = str;

                LST.Add(lst);
            }
            dt.Dispose();

            //物料添加表---主要是石灰
            strSQL = "select * FROM addition where Heat_ID='" + HeatID + "' and DEVICE_NO like 'LY210_KR'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                lst.Descripion = "脱硫剂" + RowIndex.ToString();
                str = dt.Rows[RowIndex]["ad_time"].ToString(); if (str.Length > 0) lst.DateAndTime = str;
                str = dt.Rows[RowIndex]["weight"].ToString(); if (str.Length > 0) lst.Weight = str;

                LST.Add(lst);
            }
            dt.Dispose();

            /////// 各种事件/////////////////
            strSQL = "SELECT * FROM KR_HEAT WHERE heat_ID= '" + HeatID + "'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            //获取化验成分表，是一个常规纵表
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);

                lst.Descripion = "初始铁水";
                str = dt.Rows[RowIndex]["LADLE_ARRIVE"].ToString(); if (str.Length > 0) { lst.DateAndTime = str; StartDateTime = Convert.ToDateTime(str); }

                str = dt.Rows[RowIndex]["INI_TEMP"].ToString(); if (str.Length > 0) lst.Tempture = str;
                str = dt.Rows[RowIndex]["INI_WGT"].ToString(); if (str.Length > 0) lst.Weight = str;
                str = dt.Rows[RowIndex]["INI_C"].ToString(); if (str.Length > 0) lst.Ele_C = str;
                str = dt.Rows[RowIndex]["INI_SI"].ToString(); if (str.Length > 0) lst.Ele_Si = str;
                str = dt.Rows[RowIndex]["INI_MN"].ToString(); if (str.Length > 0) lst.Ele_Mn = str;
                str = dt.Rows[RowIndex]["INI_P"].ToString(); if (str.Length > 0) lst.Ele_P = str;
                str = dt.Rows[RowIndex]["INI_S"].ToString(); if (str.Length > 0) lst.Ele_S = str;
                str = dt.Rows[RowIndex]["INI_TI"].ToString(); if (str.Length > 0) lst.Ele_Ti = str;

                LST.Add(lst);

                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                lst.Descripion = "终点铁水";
                str = dt.Rows[RowIndex]["LADLE_LEAVE"].ToString(); if (str.Length > 0) lst.DateAndTime = str;
                str = dt.Rows[RowIndex]["FIN_TEMP"].ToString(); if (str.Length > 0) lst.Tempture = str;
                str = dt.Rows[RowIndex]["FIN_WGT"].ToString(); if (str.Length > 0) lst.Weight = str;
                LST.Add(lst);

                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                lst.Descripion = "脱硫开始";
                str = dt.Rows[RowIndex]["DES_START"].ToString();
                if (str.Length > 0)
                {
                    lst.DateAndTime = str;
                }
                LST.Add(lst);

                lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                lst.Descripion = "脱硫结束";
                str = dt.Rows[RowIndex]["DES_END"].ToString();
                if (str.Length > 0)
                {
                    lst.DateAndTime = str;
                }
                LST.Add(lst);

                str = dt.Rows[RowIndex]["RESIDUE_FIRST_S"].ToString();
                if (str.Length > 0)
                {
                    lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                    lst.Descripion = "去前渣开始";
                    lst.DateAndTime = str;
                    LST.Add(lst);
                }

                str = dt.Rows[RowIndex]["RESIDUE_FIRST_E"].ToString();
                if (str.Length > 0)
                {
                    lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                    lst.Descripion = "去前渣结束";
                    lst.DateAndTime = str;
                    LST.Add(lst);
                }

                str = dt.Rows[RowIndex]["RESIDUE_LAST_S"].ToString();
                if (str.Length > 0)
                {
                    lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                    lst.Descripion = "去后渣开始";
                    lst.DateAndTime = str;
                    LST.Add(lst);
                }
                str = dt.Rows[RowIndex]["RESIDUE_LAST_E"].ToString();
                if (str.Length > 0)
                {
                    lst = new KRKeyEvents(); KRKeyEvents_Ini(ref lst);
                    lst.Descripion = "去后渣结束";
                    lst.DateAndTime = str;
                    LST.Add(lst);
                }
            }

            dt.Dispose();

            DateTime cDateTime = new DateTime();
            TimeSpan ts = new TimeSpan();
            for (int I = 0; I < LST.Count; I++)
            {
                if (DateTime.TryParse(LST[I].DateAndTime, out cDateTime))
                {
                    ts = cDateTime - StartDateTime;
                    LST[I].Duration = float.Parse((ts.TotalSeconds / 60.0).ToString("#0.00"));
                }
            }

            //按照时长排序
            LST.Sort(delegate(KRKeyEvents a, KRKeyEvents b) { return a.Duration.CompareTo(b.Duration); });

            return LST;
        }
        public static void KRKeyEvents_Ini(ref KRKeyEvents lst)
        {
            lst.DateAndTime = " "; lst.Duration = 0; lst.Descripion = " "; lst.Tempture = " ";
            lst.Weight = " "; lst.Ele_C = " "; lst.Ele_Si = " "; lst.Ele_Mn = " ";
            lst.Ele_S = " "; lst.Ele_P = " "; lst.Ele_Cu = " "; lst.Ele_As = " ";
            lst.Ele_Sn = " "; lst.Ele_Cu5As8Sn = " "; lst.Ele_Cr = " "; lst.Ele_Ni = " ";
            lst.Ele_Mo = " "; lst.Ele_Ti = " "; lst.Ele_Nb = " "; lst.Ele_Pb = " ";
        }
        private static DataTable GetDataFromOledb(string cmd, string con)
        {
            OleDbConnection conn = new OleDbConnection(con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd, conn);
            DataTable result = new DataTable();
            adp.Fill(result);
            return result;
        }
        public static List<BOFHeatInfo> GetBOFHeatInfo(string HeatID)
        {
            List<BOFHeatInfo> LST = new List<BOFHeatInfo>();
            BOFHeatInfo lst = new BOFHeatInfo(); BOFHeatInfo_Ini(ref lst);

            object obj = new object();
            string str = "";

            string strSQL = "SELECT  * FROM bof_heat WHERE heat_id>'" + HeatID + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {

                lst = new BOFHeatInfo(); BOFHeatInfo_Ini(ref lst);

                obj = dt.Rows[RowIndex]["heat_id"]; if (obj.ToString().Length > 0) lst.heat_id = obj.ToString();
                obj = dt.Rows[RowIndex]["station"]; if (obj.ToString().Length > 0) lst.treatpos = obj.ToString();
                obj = dt.Rows[RowIndex]["plan_no"]; if (obj.ToString().Length > 0) lst.plan_no = obj.ToString();
                obj = dt.Rows[RowIndex]["pono"]; if (obj.ToString().Length > 0) lst.pono = obj.ToString();
                obj = dt.Rows[RowIndex]["steel_grade"]; if (obj.ToString().Length > 0) lst.steel_grade = obj.ToString();

                obj = dt.Rows[RowIndex]["promodecode"]; if (obj.ToString().Length > 0) lst.promodecode = obj.ToString();
                obj = dt.Rows[RowIndex]["bof_campaign"]; if (obj.ToString().Length > 0) lst.bof_campaign = obj.ToString();
                obj = dt.Rows[RowIndex]["bof_life"]; if (obj.ToString().Length > 0) lst.bof_life = obj.ToString();
                obj = dt.Rows[RowIndex]["tappinghole"]; if (obj.ToString().Length > 0) lst.tappinghole = obj.ToString();
                obj = dt.Rows[RowIndex]["tap_hole_campaign"]; if (obj.ToString().Length > 0) lst.tap_hole_campaign = obj.ToString();

                obj = dt.Rows[RowIndex]["tap_hole_life"]; if (obj.ToString().Length > 0) lst.tap_hole_life = obj.ToString();
                obj = dt.Rows[RowIndex]["mainlance_id"]; if (obj.ToString().Length > 0) lst.mainlance_id = obj.ToString();
                obj = dt.Rows[RowIndex]["mainlance_life"]; if (obj.ToString().Length > 0) lst.mainlance_life = obj.ToString();
                obj = dt.Rows[RowIndex]["sublance_id"]; if (obj.ToString().Length > 0) lst.sublance_id = obj.ToString();
                obj = dt.Rows[RowIndex]["sublance_life"]; if (obj.ToString().Length > 0) lst.sublance_life = obj.ToString();

                obj = dt.Rows[RowIndex]["bath_level"]; if (obj.ToString().Length > 0) lst.bath_level = obj.ToString();
                obj = dt.Rows[RowIndex]["STEEL_LADLE_ID"]; if (obj.ToString().Length > 0) lst.steelladleid = obj.ToString();

                obj = dt.Rows[RowIndex]["slag_net_weight"]; if (obj.ToString().Length > 0) lst.slag_net_weight = obj.ToString();

                obj = dt.Rows[RowIndex]["weight_act"]; if (obj.ToString().Length > 0) lst.weight_act = obj.ToString();
                obj = dt.Rows[RowIndex]["weighting_time"]; if (obj.ToString().Length > 0) lst.weighting_time = obj.ToString();

                //obj=dt.Rows[RowIndex]["metal_act"];if (obj.ToString().Length>0) lst.metal_act=obj.ToString();
                obj = dt.Rows[RowIndex]["cao_weight"]; if (obj.ToString().Length > 0) lst.cao_weight = obj.ToString();

                obj = dt.Rows[RowIndex]["dolo_weight"]; if (obj.ToString().Length > 0) lst.dolo_weight = obj.ToString();
                obj = dt.Rows[RowIndex]["rdolo_weight"]; if (obj.ToString().Length > 0) lst.o2_act = obj.ToString();
                obj = dt.Rows[RowIndex]["mgo_weight"]; if (obj.ToString().Length > 0) lst.mgo_weight = obj.ToString();
                obj = dt.Rows[RowIndex]["caf2_weight"]; if (obj.ToString().Length > 0) lst.caf2_weight = obj.ToString();
                obj = dt.Rows[RowIndex]["iron_weight"]; if (obj.ToString().Length > 0) lst.iron_weight = obj.ToString();

                obj = dt.Rows[RowIndex]["O2_ConSUM_VOlume"]; if (obj.ToString().Length > 0) lst.o2_act = obj.ToString();
                obj = dt.Rows[RowIndex]["ar_act"]; if (obj.ToString().Length > 0) lst.ar_act = obj.ToString();
                obj = dt.Rows[RowIndex]["n2_act"]; if (obj.ToString().Length > 0) lst.n2_act = obj.ToString();

                obj = dt.Rows[RowIndex]["tsc_tem"]; if (obj.ToString().Length > 0) lst.tsc_tem = obj.ToString();
                obj = dt.Rows[RowIndex]["tsc_c"]; if (obj.ToString().Length > 0) lst.tsc_c = obj.ToString();

                obj = dt.Rows[RowIndex]["tso_tem"]; if (obj.ToString().Length > 0) lst.tso_tem = obj.ToString();
                obj = dt.Rows[RowIndex]["tso_c"]; if (obj.ToString().Length > 0) lst.tso_c = obj.ToString();
                obj = dt.Rows[RowIndex]["tso_o2ppm"]; if (obj.ToString().Length > 0) lst.tso_o2ppm = obj.ToString();

                obj = dt.Rows[RowIndex]["o2_duration"]; if (obj.ToString().Length > 0) lst.o2_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["ar_duration"]; if (obj.ToString().Length > 0) lst.ar_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["n2_duration"]; if (obj.ToString().Length > 0) lst.n2_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["after_stiring_duration"]; if (obj.ToString().Length > 0) lst.after_stiring_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow_num"]; if (obj.ToString().Length > 0) lst.reblow_num = obj.ToString();

                obj = dt.Rows[RowIndex]["reblow1_tem"]; if (obj.ToString().Length > 0) lst.reblow1_tem = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow2_tem"]; if (obj.ToString().Length > 0) lst.reblow2_tem = obj.ToString();
                obj = dt.Rows[RowIndex]["deslag_num"]; if (obj.ToString().Length > 0) lst.deslag_num = obj.ToString();
                obj = dt.Rows[RowIndex]["slag_splash_n2"]; if (obj.ToString().Length > 0) lst.slag_splash_n2 = obj.ToString();
                obj = dt.Rows[RowIndex]["ready_time"]; if (obj.ToString().Length > 0) lst.ready_time = obj.ToString();

                obj = dt.Rows[RowIndex]["charging_starttime"]; if (obj.ToString().Length > 0) lst.charging_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["charging_endtime"]; if (obj.ToString().Length > 0) lst.charging_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["blow_starttime"]; if (obj.ToString().Length > 0) lst.blow_starttime = obj.ToString();

                obj = dt.Rows[RowIndex]["blow_endtime"]; if (obj.ToString().Length > 0) lst.blow_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow1_starttime"]; if (obj.ToString().Length > 0) lst.reblow1_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow1_endtime"]; if (obj.ToString().Length > 0) lst.reblow1_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow1_duration"]; if (obj.ToString().Length > 0) lst.reblow1_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow2_starttime"]; if (obj.ToString().Length > 0) lst.reblow2_starttime = obj.ToString();

                obj = dt.Rows[RowIndex]["reblow2_endtime"]; if (obj.ToString().Length > 0) lst.reblow2_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["reblow2_duration"]; if (obj.ToString().Length > 0) lst.reblow2_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["slag_nr"]; if (obj.ToString().Length > 0) lst.slag_nr = obj.ToString();
                obj = dt.Rows[RowIndex]["tapping_starttime"]; if (obj.ToString().Length > 0) lst.tapping_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["tapping_endtime"]; if (obj.ToString().Length > 0) lst.tapping_endtime = obj.ToString();

                obj = dt.Rows[RowIndex]["tapping_duration"]; if (obj.ToString().Length > 0) lst.tapping_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["slag_starttime"]; if (obj.ToString().Length > 0) lst.slag_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["slag_endtime"]; if (obj.ToString().Length > 0) lst.slag_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["slag_duration"]; if (obj.ToString().Length > 0) lst.slag_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["product_day"]; if (obj.ToString().Length > 0) lst.product_day = obj.ToString();

                obj = dt.Rows[RowIndex]["shift_id"]; if (obj.ToString().Length > 0) lst.shift_id = obj.ToString();
                obj = dt.Rows[RowIndex]["crew_id"]; if (obj.ToString().Length > 0) lst.crew_id = obj.ToString();


                obj = dt.Rows[RowIndex]["ge_no"]; if (obj.ToString().Length > 0) lst.ge_no = obj.ToString();
                obj = dt.Rows[RowIndex]["tsc_starttime"]; if (obj.ToString().Length > 0) lst.tsc_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["tsc_endtime"]; if (obj.ToString().Length > 0) lst.tsc_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["tso_starttime"]; if (obj.ToString().Length > 0) lst.tso_starttime = obj.ToString();
                obj = dt.Rows[RowIndex]["tso_endtime"]; if (obj.ToString().Length > 0) lst.tso_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["splash_starttime"]; if (obj.ToString().Length > 0) lst.splash_starttime = obj.ToString();

                obj = dt.Rows[RowIndex]["splash_endtime"]; if (obj.ToString().Length > 0) lst.splash_endtime = obj.ToString();
                obj = dt.Rows[RowIndex]["splash_duration"]; if (obj.ToString().Length > 0) lst.splash_duration = obj.ToString();
                obj = dt.Rows[RowIndex]["o2_press"]; if (obj.ToString().Length > 0) lst.o2_press = obj.ToString();
                obj = dt.Rows[RowIndex]["o2_flux"]; if (obj.ToString().Length > 0) lst.o2_flux = obj.ToString();
                obj = dt.Rows[RowIndex]["n2_press"]; if (obj.ToString().Length > 0) lst.n2_press = obj.ToString();

                obj = dt.Rows[RowIndex]["n2_flux"]; if (obj.ToString().Length > 0) lst.n2_flux = obj.ToString();
                obj = dt.Rows[RowIndex]["sheetiron_wgt"]; if (obj.ToString().Length > 0) lst.sheetiron_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["restrin_wgt"]; if (obj.ToString().Length > 0) lst.restrin_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["alloycao_wgt"]; if (obj.ToString().Length > 0) lst.alloycao_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["cadd_wgt"]; if (obj.ToString().Length > 0) lst.cadd_wgt = obj.ToString();

                obj = dt.Rows[RowIndex]["fesi_wgt"]; if (obj.ToString().Length > 0) lst.fesi_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["al_wgt"]; if (obj.ToString().Length > 0) lst.al_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["mnsi_wgt"]; if (obj.ToString().Length > 0) lst.mnsi_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["femn_wgt"]; if (obj.ToString().Length > 0) lst.femn_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["fenb_wgt"]; if (obj.ToString().Length > 0) lst.fenb_wgt = obj.ToString();

                obj = dt.Rows[RowIndex]["hscrw_wgt"]; if (obj.ToString().Length > 0) lst.hscrw_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["lscrw_wgt"]; if (obj.ToString().Length > 0) lst.lscrw_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["sscrw_wgt"]; if (obj.ToString().Length > 0) lst.sscrw_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["mfemn_wgt"]; if (obj.ToString().Length > 0) lst.mfemn_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["lfemn_wgt"]; if (obj.ToString().Length > 0) lst.lfemn_wgt = obj.ToString();

                obj = dt.Rows[RowIndex]["duststeam_vol"]; if (obj.ToString().Length > 0) lst.duststeam_vol = obj.ToString();
                obj = dt.Rows[RowIndex]["dustwater_vol"]; if (obj.ToString().Length > 0) lst.dustwater_vol = obj.ToString();
                obj = dt.Rows[RowIndex]["recyclesteam_vol"]; if (obj.ToString().Length > 0) lst.recyclesteam_vol = obj.ToString();
                obj = dt.Rows[RowIndex]["outsteam_vol"]; if (obj.ToString().Length > 0) lst.outsteam_vol = obj.ToString();

                obj = dt.Rows[RowIndex]["ladlear_act"]; if (obj.ToString().Length > 0) lst.ladlear_act = obj.ToString();
                obj = dt.Rows[RowIndex]["rdolo_wgt"]; if (obj.ToString().Length > 0) lst.rdolo_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["change_wgt"]; if (obj.ToString().Length > 0) lst.change_wgt = obj.ToString();

                obj = dt.Rows[RowIndex]["burnslag_wgt"]; if (obj.ToString().Length > 0) lst.burnslag_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["lfslag_wgt"]; if (obj.ToString().Length > 0) lst.lfslag_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["sicabei_wgt"]; if (obj.ToString().Length > 0) lst.sicabei_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["sialfe_wgt"]; if (obj.ToString().Length > 0) lst.sialfe_wgt = obj.ToString();
                obj = dt.Rows[RowIndex]["mn_wgt"]; if (obj.ToString().Length > 0) lst.mn_wgt = obj.ToString();

                str = dt.Rows[RowIndex]["IRON_LADLE_ID"].ToString(); if (str.Length > 0) lst.IRON_LADLE_ID = str;
                str = dt.Rows[RowIndex]["IRON_ID"].ToString(); if (str.Length > 0) lst.IRON_ID = str;
                str = dt.Rows[RowIndex]["HM_WEIGHT"].ToString(); if (str.Length > 0) lst.HM_WEIGHT = str;
                str = dt.Rows[RowIndex]["HM_TRPMTURE"].ToString(); if (str.Length > 0) lst.HM_TRPMTURE = str;
                str = dt.Rows[RowIndex]["HM_TIME"].ToString(); if (str.Length > 0) lst.HM_TIME = str;
                str = dt.Rows[RowIndex]["HM_SOUREC"].ToString(); if (str.Length > 0) lst.HM_SOUREC = str;

                str = dt.Rows[RowIndex]["SCRAP_BUCKET_ID"].ToString(); if (str.Length > 0) lst.SCRAP_BUCKET_ID = str;
                str = dt.Rows[RowIndex]["SCRAP_ID"].ToString(); if (str.Length > 0) lst.SCRAP_ID = str;
                str = dt.Rows[RowIndex]["SCRAP_WEIGHT"].ToString(); if (str.Length > 0) lst.SCRAP_WEIGHT = str;
                str = dt.Rows[RowIndex]["HSCRW_WEIGHT"].ToString(); if (str.Length > 0) lst.HSCRW_WEIGHT = str;
                str = dt.Rows[RowIndex]["LSCRW_WEIGHT"].ToString(); if (str.Length > 0) lst.LSCRW_WEIGHT = str;
                str = dt.Rows[RowIndex]["SSCRW_WEIGHT"].ToString(); if (str.Length > 0) lst.SSCRW_WEIGHT = str;

                LST.Add(lst);
            }
            dt.Dispose();

            return LST;
        }
        public static void BOFHeatInfo_Ini(ref BOFHeatInfo lst)
        {
            lst.heat_id = " "; lst.treatpos = " "; lst.plan_no = " "; lst.pono = " "; lst.steel_grade = " ";
            lst.promodecode = " "; lst.bof_campaign = " "; lst.bof_life = " "; lst.tappinghole = " "; lst.tap_hole_campaign = " ";
            lst.tap_hole_life = " "; lst.mainlance_id = " "; lst.mainlance_life = " "; lst.sublance_id = " "; lst.sublance_life = " ";
            lst.bath_level = " "; lst.steelladleid = " "; lst.slag_cal_weight = " "; lst.slag_net_weight = " "; lst.weight_cal = " ";
            lst.weight_act = " "; lst.weighting_time = " "; lst.tem_act = " "; lst.tem_time = " ";
            lst.bofc_act = " "; lst.o2ppm_act = " "; lst.ladleid = " "; lst.hmw_act = " ";
            lst.hm_tem = " "; lst.hm_c = " "; lst.hm_si = " "; lst.hm_mn = " "; lst.hm_p = " ";
            lst.hm_s = " "; lst.bucketid = " "; lst.scrw_act = " "; lst.pi_act = " "; lst.return_act = " ";
            lst.metal_act = " "; lst.cao_weight = " "; lst.dolo_weight = " "; lst.rdolo_weight = " ";
            lst.mgo_weight = " "; lst.caf2_weight = " "; lst.iron_weight = " "; lst.o2_act = " "; lst.ar_act = " ";
            lst.n2_act = " "; lst.tsc_tem = " "; lst.tsc_c = " "; lst.tsc_duration = " ";
            lst.tso_tem = " "; lst.tso_c = " "; lst.tso_o2ppm = " "; lst.tso_duration = " ";
            lst.o2_duration = " "; lst.ar_duration = " "; lst.n2_duration = " "; lst.after_stiring_duration = " ";
            lst.reblow_num = " "; lst.reblow1_tem = " "; lst.reblow2_tem = " "; lst.deslag_num = " ";
            lst.slag_splash_n2 = " "; lst.ready_time = " "; lst.charging_starttime = " "; lst.hm_time = " ";
            lst.scrap_time = " "; lst.charging_endtime = " "; lst.blow_starttime = " "; lst.blow_endtime = " ";
            lst.reblow1_starttime = " "; lst.reblow1_endtime = " "; lst.reblow1_duration = " "; lst.reblow2_starttime = " ";
            lst.reblow2_endtime = " "; lst.reblow2_duration = " "; lst.slag_nr = " "; lst.tapping_starttime = " ";
            lst.tapping_endtime = " "; lst.tapping_duration = " "; lst.slag_starttime = " "; lst.slag_endtime = " ";
            lst.slag_duration = " "; lst.product_day = " "; lst.shift_id = " "; lst.crew_id = " ";
            lst.operator_c = " "; lst.checkdate = " "; lst.checkoperator = " "; lst.checkflag = " "; lst.ge_no = " ";
            lst.tsc_starttime = " "; lst.tsc_endtime = " "; lst.tso_starttime = " "; lst.tso_endtime = " ";
            lst.splash_starttime = " "; lst.splash_endtime = " "; lst.splash_duration = " ";
            lst.o2_press = " "; lst.o2_flux = " "; lst.n2_press = " "; lst.n2_flux = " "; lst.sheetiron_wgt = " ";
            lst.restrin_wgt = " "; lst.alloycao_wgt = " "; lst.cadd_wgt = " "; lst.fesi_wgt = " "; lst.al_wgt = " ";
            lst.mnsi_wgt = " "; lst.femn_wgt = " "; lst.fenb_wgt = " "; lst.hscrw_wgt = " "; lst.lscrw_wgt = " ";
            lst.sscrw_wgt = " "; lst.mfemn_wgt = " "; lst.lfemn_wgt = " "; lst.duststeam_vol = " ";
            lst.dustwater_vol = " "; lst.recyclesteam_vol = " "; lst.outsteam_vol = " "; lst.mainlance_id1 = " ";
            lst.mainlance_life1 = " "; lst.ladlear_act = " "; lst.ironid = " "; lst.rdolo_wgt = " ";
            lst.change_wgt = " "; lst.burnslag_wgt = " "; lst.lfslag_wgt = " "; lst.sicabei_wgt = " ";
            lst.sialfe_wgt = " "; lst.mn_wgt = " ";

            lst.IRON_LADLE_ID = " "; lst.IRON_ID = " "; lst.HM_WEIGHT = " "; lst.HM_TRPMTURE = " ";
            lst.HM_TIME = " "; lst.HM_SOUREC = " ";

            lst.SCRAP_BUCKET_ID = " "; lst.SCRAP_ID = " "; lst.SCRAP_WEIGHT = " "; lst.HSCRW_WEIGHT = " ";
            lst.LSCRW_WEIGHT = " "; lst.SSCRW_WEIGHT = " ";
        }
        public static List<BOFKeyEvents> GetBOFKeyEvents(string HeatID)
        {
            List<BOFKeyEvents> LST = new List<BOFKeyEvents>();
            BOFKeyEvents lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);

            string str = "";

            DateTime StartDateTime = DateTime.Now;
            //工序起始时间            
            string strSQL = "SELECT ready_time FROM BOF_HEAT WHERE heat_id='" + HeatID + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);
            if (dt.Rows.Count > 0) str = dt.Rows[0]["ready_time"].ToString(); if (str.Length > 0) StartDateTime = Convert.ToDateTime(str);

            //物料添加表
            strSQL = "SELECT * FROM BOF_HEAT WHERE heat_id='" + HeatID + "'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            if (dt.Rows.Count > 0)
            {
                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);
                lst.Decription = "铁水";
                str = dt.Rows[0]["hm_time"].ToString(); if (str.Length > 0) { lst.datetime = str; } else { lst.datetime = StartDateTime.ToString(); }
                str = dt.Rows[0]["hm_weight"].ToString(); if (str.Length > 0) lst.Weight = str;
                str = dt.Rows[0]["hm_trpmture"].ToString(); if (str.Length > 0) lst.Temp = str;
                LST.Add(lst);

                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);
                lst.Decription = "废钢";
                lst.datetime = StartDateTime.ToString();
                str = dt.Rows[0]["scrap_weight"].ToString(); if (str.Length > 0) lst.Weight = str;
                LST.Add(lst);

                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);
                lst.Decription = "TSC";
                str = dt.Rows[0]["tsc_starttime"].ToString(); if (str.Length > 0) lst.datetime = str;
                str = dt.Rows[0]["tsc_tem"].ToString(); if (str.Length > 0) lst.Temp = str;
                str = dt.Rows[0]["tsc_c"].ToString(); if (str.Length > 0) lst.Ele_C = Convert.ToDouble(str).ToString("#0.0000");
                LST.Add(lst);

                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);
                lst.Decription = "TSO";
                str = dt.Rows[0]["tso_starttime"].ToString(); if (str.Length > 0) lst.datetime = str;
                str = dt.Rows[0]["tso_tem"].ToString(); if (str.Length > 0) lst.Temp = str;
                str = dt.Rows[0]["tso_c"].ToString(); if (str.Length > 0) lst.Ele_C = Convert.ToDouble(str).ToString("#0.0000");
                str = dt.Rows[0]["tso_o2ppm"].ToString(); if (str.Length > 0) lst.O2ppm = str.Split(new char[] { '.' })[0];
                LST.Add(lst);
            }

            //化验值
            strSQL = "SELECT * FROM  addition WHERE heat_id='" + HeatID + "' AND device_no='LY210_BOF'";
            dt = GetDataFromOledb(strSQL, lyqstr);

            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);
                lst.Decription = "加料";
                lst.datetime = dt.Rows[RowIndex]["add_time"].ToString();
                lst.Mat_Name = dt.Rows[RowIndex]["mat_Name"].ToString();
                lst.Weight = dt.Rows[RowIndex]["weight"].ToString();

                LST.Add(lst);
            }

            //化验值
            strSQL = "SELECT * FROM  elem_ana WHERE heat_id='" + HeatID + "' AND device_no='LY210_BOF'";
            dt = GetDataFromOledb(strSQL, lyqstr);

            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new BOFKeyEvents(); BOFKeyEvents_Ini(ref lst);

                lst.Decription = "化验值";
                lst.datetime = dt.Rows[RowIndex]["sampletime"].ToString();

                lst.Ele_C = dt.Rows[RowIndex]["ele_c"].ToString();
                lst.Ele_Si = dt.Rows[RowIndex]["ele_si"].ToString();
                lst.Ele_Mn = dt.Rows[RowIndex]["ele_mn"].ToString();

                lst.Ele_S = dt.Rows[RowIndex]["ele_s"].ToString();
                lst.Ele_P = dt.Rows[RowIndex]["ele_p"].ToString();
                lst.Ele_Cu = dt.Rows[RowIndex]["ele_cu"].ToString();

                lst.Ele_As = dt.Rows[RowIndex]["ele_as"].ToString();
                lst.Ele_Sn = dt.Rows[RowIndex]["ele_Sn"].ToString();
                lst.Ele_Cr = dt.Rows[RowIndex]["ele_Cr"].ToString();

                lst.Ele_Ni = dt.Rows[RowIndex]["ele_Ni"].ToString();
                lst.Ele_Mo = dt.Rows[RowIndex]["ele_Mo"].ToString();
                lst.Ele_Ti = dt.Rows[RowIndex]["ele_Ti"].ToString();
                lst.Ele_Nb = dt.Rows[RowIndex]["ele_Nb"].ToString();
                lst.Ele_Pb = dt.Rows[RowIndex]["ele_Pb"].ToString();

                LST.Add(lst);
            }


            //计算时长 
            DateTime cDateTime = new DateTime();
            TimeSpan ts = new TimeSpan();
            for (int I = 0; I < LST.Count; I++)
            {
                if (DateTime.TryParse(LST[I].datetime, out cDateTime))
                {
                    ts = cDateTime - StartDateTime;
                    LST[I].Duration = float.Parse((ts.TotalSeconds / 60.0).ToString("#0.00"));
                }
            }

            //按照时长排序
            LST.Sort(delegate(BOFKeyEvents a, BOFKeyEvents b) { return a.Duration.CompareTo(b.Duration); });

            return LST;
        }
        public static void BOFKeyEvents_Ini(ref BOFKeyEvents lst)
        {
            lst.datetime = " "; lst.Duration = 0; lst.Decription = " "; lst.Weight = " "; lst.Temp = " ";
            lst.O2ppm = " "; lst.Ele_C = " "; lst.Ele_Si = " "; lst.Ele_Mn = " "; lst.Ele_S = " ";
            lst.Ele_P = " "; lst.Ele_Cu = " "; lst.Ele_As = " "; lst.Ele_Sn = " "; lst.Ele_Cr = " ";
            lst.Ele_Ni = " "; lst.Ele_Mo = " "; lst.Ele_Ti = " "; lst.Ele_Nb = " "; lst.Ele_Pb = " ";
            lst.Mat_Name = " ";
        }
        public static List<LFHeatInfo> GetLFHeatInfo(string HeatID)
        {
            List<LFHeatInfo> LST = new List<LFHeatInfo>();
            LFHeatInfo lst;
            string str = "";

            string strSQL = "SELECT * FROM LF_HEAT WHERE heat_id>'" + HeatID + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);

            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new LFHeatInfo(); LFHeatInfo_Ini(ref lst);

                str = dt.Rows[RowIndex]["heat_id"].ToString(); if (str.Length > 0) lst.heat_id = str;
                str = dt.Rows[RowIndex]["treatpos"].ToString(); if (str.Length > 0) lst.treatpos = str;
                str = dt.Rows[RowIndex]["strttime"].ToString(); if (str.Length > 0) lst.strttime = str;
                str = dt.Rows[RowIndex]["endtime"].ToString(); if (str.Length > 0) lst.endtime = str;
                str = dt.Rows[RowIndex]["station"].ToString(); if (str.Length > 0) lst.station = str;
                str = dt.Rows[RowIndex]["route"].ToString(); if (str.Length > 0) lst.route = str;

                str = dt.Rows[RowIndex]["strtgrade"].ToString(); if (str.Length > 0) lst.strtgrade = str;
                str = dt.Rows[RowIndex]["endgrade"].ToString(); if (str.Length > 0) lst.endgrade = str;
                str = dt.Rows[RowIndex]["strtsteeltemp"].ToString(); if (str.Length > 0) lst.strtsteeltemp = str;

                str = dt.Rows[RowIndex]["endsteeltemp"].ToString(); if (str.Length > 0) lst.endsteeltemp = str;
                str = dt.Rows[RowIndex]["strtsteelwei"].ToString(); if (str.Length > 0) lst.strtsteelwei = str;
                str = dt.Rows[RowIndex]["endsteelwei"].ToString(); if (str.Length > 0) lst.endsteelwei = str;

                str = dt.Rows[RowIndex]["endslagwei"].ToString(); if (str.Length > 0) lst.endslagwei = str;
                str = dt.Rows[RowIndex]["ladleno"].ToString(); if (str.Length > 0) lst.ladleno = str;
                str = dt.Rows[RowIndex]["ladlestatus"].ToString(); if (str.Length > 0) lst.ladlestatus = str;
                str = dt.Rows[RowIndex]["ladlewei"].ToString(); if (str.Length > 0) lst.ladlewei = str;

                str = dt.Rows[RowIndex]["pon"].ToString(); if (str.Length > 0) lst.pon = str;

                str = dt.Rows[RowIndex]["slidgatelife"].ToString(); if (str.Length > 0) lst.slidgatelife = str;
                str = dt.Rows[RowIndex]["slidgatebrname"].ToString(); if (str.Length > 0) lst.slidgatebrname = str;
                str = dt.Rows[RowIndex]["porozlife"].ToString(); if (str.Length > 0) lst.porozlife = str;
                str = dt.Rows[RowIndex]["porozbrname"].ToString(); if (str.Length > 0) lst.porozbrname = str;
                str = dt.Rows[RowIndex]["emptydur"].ToString(); if (str.Length > 0) lst.emptydur = str;
                str = dt.Rows[RowIndex]["eletrdholdtm"].ToString(); if (str.Length > 0) lst.eletrdholdtm = str;
                str = dt.Rows[RowIndex]["totprieng"].ToString(); if (str.Length > 0) lst.totprieng = str;
                str = dt.Rows[RowIndex]["totseceng"].ToString(); if (str.Length > 0) lst.totseceng = str;
                str = dt.Rows[RowIndex]["gastype"].ToString(); if (str.Length > 0) lst.gastype = str;
                str = dt.Rows[RowIndex]["totgas"].ToString(); if (str.Length > 0) lst.totgas = str;
                str = dt.Rows[RowIndex]["shiftnr"].ToString(); if (str.Length > 0) lst.shiftnr = str;
                str = dt.Rows[RowIndex]["shiftteam"].ToString(); if (str.Length > 0) lst.shiftteam = str;
                str = dt.Rows[RowIndex]["monitor"].ToString(); if (str.Length > 0) lst.monitor = str;
                str = dt.Rows[RowIndex]["mainoptr1"].ToString(); if (str.Length > 0) lst.mainoptr1 = str;
                str = dt.Rows[RowIndex]["mainoptr2"].ToString(); if (str.Length > 0) lst.mainoptr2 = str;

                LST.Add(lst);

            }
            dt.Dispose();

            return LST;
        }

        public static List<LFKeyEvents> GetLF_KeyEvents(string HeatID)
        {
            List<LFKeyEvents> LST = new List<LFKeyEvents>();
            LFKeyEvents lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);
            string strSQL = "";
            DataTable dt = new DataTable();

            //保存开始时间
            DateTime StartDateTime = DateTime.Now;

            //查找入炉时间,并从中提取事件
            strSQL = "SELECT * FROM LF_HEAT WHERE heat_id='" + HeatID + "'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            if (dt.Rows.Count > 0)
            {
                StartDateTime = Convert.ToDateTime(dt.Rows[0]["strttime"]);

                lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);
                lst.Decription = "到站";
                lst.datetime = dt.Rows[0]["strttime"].ToString();
                LST.Add(lst);

                lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);
                lst.Decription = "离站";
                lst.datetime = dt.Rows[0]["endtime"].ToString();
                LST.Add(lst);

            }

            //测温事件
            strSQL = "select * FROM TEMPTURE WHERE heat_id='" + HeatID + "' AND device_no='LY210_LF'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);

                lst.Decription = "第" + dt.Rows[RowIndex]["measure_num"].ToString() + "次测温";
                lst.datetime = dt.Rows[RowIndex]["measure_time"].ToString();
                lst.Temp = dt.Rows[RowIndex]["trmpture_value"].ToString();

                LST.Add(lst);
            }
            dt.Dispose();


            //** 加料事件 **//
            strSQL = "SELECT *  FROM addition WHERE heat_id='" + HeatID + "' AND device_no='LY210_LF'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);

                lst.Decription = "第" + dt.Rows[RowIndex]["add_batch"].ToString() + "批加料";
                lst.datetime = dt.Rows[RowIndex]["add_time"].ToString();
                lst.MatName = dt.Rows[RowIndex]["mat_name"].ToString();
                lst.MatCode = dt.Rows[RowIndex]["mat_ID"].ToString();
                lst.Weight = dt.Rows[RowIndex]["weight"].ToString();

                LST.Add(lst);
            }
            dt.Dispose();


            //** 化验值 **//
            strSQL = "SELECT * FROM elem_ana WHERE heat_id='" + HeatID + "' AND device_no='LY210_LF'";
            dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new LFKeyEvents(); LFKeyEvents_Ini(ref lst);

                lst.Decription = "第" + dt.Rows[RowIndex]["sample_number"].ToString() + "次化验";
                lst.datetime = dt.Rows[RowIndex]["sampletime"].ToString();

                lst.Ele_C = dt.Rows[RowIndex]["ele_c"].ToString();
                lst.Ele_Si = dt.Rows[RowIndex]["ele_si"].ToString();
                lst.Ele_Mn = dt.Rows[RowIndex]["ele_mn"].ToString();

                lst.Ele_S = dt.Rows[RowIndex]["ele_s"].ToString();
                lst.Ele_P = dt.Rows[RowIndex]["ele_p"].ToString();
                lst.Ele_Cu = dt.Rows[RowIndex]["ele_cu"].ToString();

                lst.Ele_As = dt.Rows[RowIndex]["ele_as"].ToString();
                lst.Ele_Sn = dt.Rows[RowIndex]["ele_Sn"].ToString();
                lst.Ele_Cr = dt.Rows[RowIndex]["ele_Cr"].ToString();

                lst.Ele_Ni = dt.Rows[RowIndex]["ele_Ni"].ToString();
                lst.Ele_Mo = dt.Rows[RowIndex]["ele_Mo"].ToString();
                lst.Ele_Ti = dt.Rows[RowIndex]["ele_Ti"].ToString();
                lst.Ele_Nb = dt.Rows[RowIndex]["ele_Nb"].ToString();
                lst.Ele_Pb = dt.Rows[RowIndex]["ele_Pb"].ToString();

                LST.Add(lst);

            }
            dt.Dispose();

            //计算时长 
            DateTime cDateTime = new DateTime();
            TimeSpan ts = new TimeSpan();
            for (int I = 0; I < LST.Count; I++)
            {
                if (DateTime.TryParse(LST[I].datetime, out cDateTime))
                {
                    ts = cDateTime - StartDateTime;
                    LST[I].Duration = float.Parse((ts.TotalSeconds / 60.0).ToString("#0.00"));
                }
            }

            //按照时长排序
            LST.Sort(delegate(LFKeyEvents a, LFKeyEvents b) { return a.Duration.CompareTo(b.Duration); });

            return LST;
        }
        public static void LFHeatInfo_Ini(ref LFHeatInfo lst)
        {
            lst.heat_id = " "; lst.treatpos = " "; lst.strttime = " "; lst.endtime = " "; lst.station = " ";
            lst.route = " "; lst.strtgrade = " "; lst.endgrade = " "; lst.strtsteeltemp = " "; lst.endsteeltemp = " ";
            lst.strtsteelwei = " "; lst.endsteelwei = " "; lst.endslagwei = " "; lst.ladleno = " ";
            lst.ladlestatus = " "; lst.ladlewei = " "; lst.pon = " "; lst.slidgatelife = " ";
            lst.slidgatebrname = " "; lst.porozlife = " "; lst.porozbrname = " "; lst.emptydur = " ";
            lst.eletrdholdtm = " "; lst.totprieng = " "; lst.totseceng = " "; lst.gastype = " ";
            lst.totgas = " "; lst.shiftnr = " "; lst.shiftteam = " "; lst.monitor = " "; lst.mainoptr1 = " ";
            lst.mainoptr2 = " ";
        }

        public static void LFKeyEvents_Ini(ref LFKeyEvents lst)
        {
            lst.datetime = " "; lst.Duration = 0; lst.Decription = " "; lst.MatCode = " ";
            lst.Weight = " "; lst.Temp = " "; lst.O2ppm = " "; lst.Ele_C = " ";
            lst.Ele_Si = " "; lst.Ele_Mn = " "; lst.Ele_S = " "; lst.Ele_P = " ";
            lst.Ele_Cu = " "; lst.Ele_As = " "; lst.Ele_Sn = " "; lst.Ele_Cr = " ";
            lst.Ele_Ni = " "; lst.Ele_Mo = " "; lst.Ele_Ti = " "; lst.Ele_Nb = " ";
            lst.Ele_Pb = " ";
        }
        public static List<CCHeatInfo> GetCCHeatInfo(string HeatID)
        {
            List<CCHeatInfo> LST = new List<CCHeatInfo>();
            CCHeatInfo lst = new CCHeatInfo(); CCHeatInfo_Ini(ref lst);
            string str = "";

            string strSQL = "SELECT * FROM ccm_heat WHERE heat_id>'" + HeatID + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new CCHeatInfo(); CCHeatInfo_Ini(ref lst);


                lst.heat_id = dt.Rows[RowIndex]["heat_id"].ToString();
                lst.CCM = dt.Rows[RowIndex]["ccm"].ToString();
                lst.station_code = dt.Rows[RowIndex]["station_code"].ToString();
                lst.steel_grade_id = dt.Rows[RowIndex]["steel_grade_id"].ToString();
                lst.final_steel_grade_id = dt.Rows[RowIndex]["final_steel_grade_id"].ToString();
                lst.alteration_reason_code = dt.Rows[RowIndex]["alteration_reason_code"].ToString();
                lst.shift_code = dt.Rows[RowIndex]["shift_code"].ToString();
                lst.shift_responsible = dt.Rows[RowIndex]["shift_responsible"].ToString();
                lst.team_id = dt.Rows[RowIndex]["team_id"].ToString();


                lst.liquidus_temp = dt.Rows[RowIndex]["liquidus_temp"].ToString();
                lst.route_id = dt.Rows[RowIndex]["route_id"].ToString();
                lst.practice_id = dt.Rows[RowIndex]["practice_id"].ToString();
                lst.seq_counter = dt.Rows[RowIndex]["seq_counter"].ToString();
                lst.seq_heat_counter = dt.Rows[RowIndex]["seq_heat_counter"].ToString();
                lst.seq_total_heats = dt.Rows[RowIndex]["seq_total_heats"].ToString();


                lst.ladle_id = dt.Rows[RowIndex]["ladle_id"].ToString();
                lst.ladle_life = dt.Rows[RowIndex]["ladle_life"].ToString();
                lst.ladle_arrival_date = dt.Rows[RowIndex]["ladle_arrival_date"].ToString();
                str = dt.Rows[RowIndex]["ladle_arrival_wgt"].ToString(); lst.ladle_arrival_wgt = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["ladle_tare_wgt"].ToString(); lst.ladle_tare_wgt = str.Split(new char[] { '.' })[0];
                lst.ladle_opening_date = Convert.ToDateTime(dt.Rows[RowIndex]["ladle_opening_date"]).ToString("yyyy/MM/dd HH:mm:ss");
                str = dt.Rows[RowIndex]["ladle_opening_wgt"].ToString(); lst.ladle_opening_wgt = str.Split(new char[] { '.' })[0];
                lst.ladle_close_date = dt.Rows[RowIndex]["ladle_close_date"].ToString();
                str = dt.Rows[RowIndex]["ladle_close_wgt"].ToString(); lst.ladle_close_wgt = str.Split(new char[] { '.' })[0];


                lst.start_date = dt.Rows[RowIndex]["start_date"].ToString();
                str = dt.Rows[RowIndex]["start_wgt"].ToString(); lst.start_wgt = str;//lst.start_wgt= Convert.ToInt32 (str).ToString();
                lst.stop_date = dt.Rows[RowIndex]["stop_date"].ToString();

                str = dt.Rows[RowIndex]["tapped_wgt"].ToString(); lst.tapped_wgt = str;//lst.tapped_wgt = Convert.ToInt32(str).ToString(); 
                lst.task_counter = dt.Rows[RowIndex]["task_counter"].ToString();

                str = dt.Rows[RowIndex]["tundish_at_ladle_open_wgt"].ToString(); lst.tundish_at_ladle_open_wgt = str.Split(new char[] { '.' })[0];
                lst.tundish_car_code = dt.Rows[RowIndex]["tundish_car_code"].ToString();
                lst.tundish_life = dt.Rows[RowIndex]["tundish_life"].ToString();
                str = dt.Rows[RowIndex]["tundish_id"].ToString(); lst.tundish_id = str;
                str = dt.Rows[RowIndex]["tundish_preheat_time"].ToString(); lst.tundish_preheat_time = str;
                str = dt.Rows[RowIndex]["tundish_preheat_temperature"].ToString(); lst.tundish_preheat_temperature = str;
                str = dt.Rows[RowIndex]["tundish_skull_wgt"].ToString(); lst.tundish_skull_wgt = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["tundish_powder_type"].ToString(); lst.tundish_powder_type = str;
                str = dt.Rows[RowIndex]["tundish_powder_wgt"].ToString(); lst.tundish_powder_wgt = str.Split(new char[] { '.' })[0];

                LST.Add(lst);
            }

            dt.Dispose();
            return LST;
        }

        public static void CCHeatInfo_Ini(ref CCHeatInfo lst)
        {
            lst.report_counter = "-"; lst.task_counter = "-";

            lst.heat_id = "-"; lst.CCM = "-"; lst.po_id = "-"; lst.area_id = "-"; lst.station_code = "-"; lst.steel_grade_id = "-"; lst.final_steel_grade_id = "-";
            lst.alteration_reason_code = "-"; lst.route_id = "-"; lst.practice_id = "-";

            lst.team_id = "-"; lst.shift_code = "-"; lst.shift_responsible = "-";

            lst.start_date = "-"; lst.start_wgt = "-"; lst.start_slag_wgt = "-";
            lst.stop_date = "-";
            lst.final_wgt = "-"; lst.final_slag_wgt = "-";
            lst.tapped_wgt = "-"; lst.final_temp = "-";

            lst.task_note = "-";
            lst.foreman_id = "-"; lst.scheduled_start_date = "-";
            lst.hot_heel = "-"; lst.avgel1current = "-"; lst.avgel2current = "-"; lst.avgel3current = "-";
            lst.avgactpower = "-"; lst.tap_to_tap = "-"; lst.heat_notes = "-"; lst.l3_heat_id = "-";
            lst.profile_model = "-"; lst.eaf_electrode_consumption = "-";

            lst.liquidus_temp = "-";

            lst.seq_counter = "-"; lst.seq_heat_counter = "-"; lst.seq_total_heats = "-"; lst.seq_sched_heats = "-";

            lst.ladle_id = "-"; lst.ladle_life = "-"; lst.ladle_tare_wgt = "-"; lst.ladle_turret_arm_code = "-";
            lst.ladle_arrival_date = "-"; lst.ladle_opening_date = "-"; lst.ladle_close_date = "-"; lst.ladle_arrival_wgt = "-";
            lst.ladle_opening_wgt = "-"; lst.ladle_close_wgt = "-";

            lst.tundish_id = "-"; lst.tundish_life = "-";
            lst.tundish_car_code = "-"; lst.tundish_preheat_time = "-"; lst.tundish_preheat_temperature = "-";
            lst.tundish_at_ladle_open_wgt = "-"; lst.tundish_skull_wgt = "-"; lst.tundish_powder_type = "-"; lst.tundish_powder_wgt = "-";
        }
        public static List<CC_SlabInfo> GetCC_SlabInfo(string SlabNo)
        {
            List<CC_SlabInfo> LST = new List<CC_SlabInfo>();
            CC_SlabInfo lst = new CC_SlabInfo(); CC_SlabInfo_Ini(ref lst);
            Object Obj = new object();
            string str = "";

            string strSQL = "SELECT * FROM  SLAB_L2_REPORTS WHERE slab_no='" + SlabNo + "'";
            DataTable dt = GetDataFromOledb(strSQL, lyqstr);
            for (int RowIndex = 0; RowIndex < dt.Rows.Count; RowIndex++)
            {
                lst = new CC_SlabInfo(); CC_SlabInfo_Ini(ref lst);

                lst.slab_no = dt.Rows[RowIndex]["slab_no"].ToString();
                lst.HEAT_ID = dt.Rows[RowIndex]["HEAT_ID"].ToString();
                lst.STEEL_GRADE = dt.Rows[RowIndex]["STEEL_GRADE"].ToString();

                lst.CCM = dt.Rows[RowIndex]["CCM"].ToString();
                lst.STRAND_NO = dt.Rows[RowIndex]["STRAND_NO"].ToString();
                lst.PROD_NO = dt.Rows[RowIndex]["PROD_NO"].ToString();
                lst.PROD_COUNTER = dt.Rows[RowIndex]["PROD_COUNTER"].ToString();
                lst.TAPER_START = dt.Rows[RowIndex]["TAPER_START"].ToString();
                lst.TAPER_END = dt.Rows[RowIndex]["TAPER_END"].ToString();

                str = dt.Rows[RowIndex]["WIDTH"].ToString(); lst.WIDTH = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["WIDTH_HEAD"].ToString(); lst.WIDTH_HEAD = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["WIDTH_TAIL"].ToString(); lst.WIDTH_TAIL = str.Split(new char[] { '.' })[0];

                str = dt.Rows[RowIndex]["THICKNESS"].ToString(); lst.THICKNESS = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["LENGTH"].ToString(); lst.LENGTH = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["WEIGHT"].ToString(); lst.WEIGHT = str.Split(new char[] { '.' })[0];

                lst.START_TIME = dt.Rows[RowIndex]["START_TIME"].ToString();
                lst.STOP_TIME = dt.Rows[RowIndex]["STOP_TIME"].ToString();

                str = dt.Rows[RowIndex]["START_CAST_POS"].ToString(); lst.START_CAST_POS = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["STOP_CAST_POS"].ToString(); lst.STOP_CAST_POS = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["SAMPLE_WGT"].ToString(); lst.SAMPLE_WGT = str.Split(new char[] { '.' })[0];
                str = dt.Rows[RowIndex]["DEFECT_LEVEL"].ToString(); lst.DEFECT_LEVEL = str.Split(new char[] { '.' })[0];

                lst.MANUAL_REPORT_FLG = dt.Rows[RowIndex]["MANUAL_REPORT_FLG"].ToString();
                lst.MANUAL_CUT_FLG = dt.Rows[RowIndex]["MANUAL_CUT_FLG"].ToString();
                lst.CUT_DATE = dt.Rows[RowIndex]["CUT_DATE"].ToString();
                lst.WEIGHT_REAL = dt.Rows[RowIndex]["WEIGHT_REAL"].ToString();

                LST.Add(lst);
            }
            dt.Dispose();

            return LST;
        }

        public static void CC_SlabInfo_Ini(ref CC_SlabInfo lst)
        {
            lst.slab_no = "-"; lst.HEAT_ID = "-"; lst.STEEL_GRADE = "-"; lst.CCM = "-";
            lst.STRAND_NO = "-"; lst.PROD_COUNTER = "-"; lst.PROD_NO = "-"; lst.WIDTH = "-";
            lst.WIDTH_HEAD = "-"; lst.WIDTH_TAIL = "-"; lst.THICKNESS = "-"; lst.TAPER_START = "-";
            lst.TAPER_END = "-"; lst.LENGTH = "-"; lst.WEIGHT = "-"; lst.START_TIME = "-";
            lst.STOP_TIME = "-"; lst.START_CAST_POS = "-"; lst.STOP_CAST_POS = "-"; lst.SAMPLE_WGT = "-";
            lst.DEFECT_LEVEL = "-"; lst.MANUAL_REPORT_FLG = "-"; lst.MANUAL_CUT_FLG = "-"; lst.CUT_DATE = "-";
            lst.WEIGHT_REAL = "-";
        }
    }
}
