using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Test
{
    [System.SerializableAttribute]
    public class KRHeatInfo
    {
        public string HEAT_ID{get;set;}
        public string IRON_ID{get;set;}
        public string DES_STATION_NO{get;set;}
        public string PLAN_NO{get;set;}
        public string PONO{get;set;}
        public string STEEL_GRADE{get;set;}
        public string AIM_S{get;set;}
        public string DES_STEP_NUM{get;set;}
        public string IRON_LADLE_ID{get;set;}
        public string INI_TEMP{get;set;}
        public string INI_WGT{get;set;}
        public string INI_C{get;set;}
        public string INI_SI{get;set;}
        public string INI_MN{get;set;}
        public string INI_P{get;set;}
        public string INI_S{get;set;}
        public string INI_TI{get;set;}
        public string FIN_TEMP{get;set;}
        public string FIN_WGT{get;set;}
        public string MATERIALID_ACT{get;set;}
        public string ADDWGT_ACT{get;set;}
        public string STIRRER_DURATION{get;set;}
        public string STIRRER_SPEED_MAX{get;set;}
        public string STIRRER_SPEED_MIN{get;set;}
        public string STIRRER_SPEED_AVG{get;set;}
        public string STIRRER_HEIGHT_MAX{get;set;}
        public string STIRRER_HEIGHT_MIN{get;set;}
        public string STIRRER_HEIGHT_AVG{get;set;}
        public string STIRRER_ID{get;set;}
        public string STIRRER_TIMES{get;set;}
        public string LADLE_ARRIVE{get;set;}
        public string LADLE_LEAVE{get;set;}
        public string DES_START{get;set;}
        public string DES_END{get;set;}
        public string RESIDUE_FIRST_S{get;set;}
        public string RESIDUE_FIRST_E{get;set;}
        public string RESIDUE_FIRST_DURATION{get;set;}
        public string RESIDUE_FIRST_SLAG_WGT{get;set;}
        public string RESIDUE_LAST_S{get;set;}
        public string RESIDUE_LAST_E{get;set;}
        public string RESIDUE_LAST_DURATION{get;set;}
        public string RESIDUE_LAST_SLAG_WGT{get;set;}
        public string CALEFACIENT_USED{get;set;}
        public string DES_DURATION{get;set;}
        public string PRODUCE_DATE{get;set;}
        public string CREW_ID{get;set;}
        public string SHIFT_ID{get;set;}
        public string VALID_FLAG{get;set;}
        public string PERIOD_ID{get;set;}
        public string LADLE_WEIGHT{get;set;}
        public string TEMP_TIME_F{get;set;}
        public string TEMP_TIME_E{get;set;}

    }

    [System.SerializableAttribute]
    public class KRKeyEvents
    {
        public string DateAndTime{get;set;}
        public float Duration{get;set;}
        public string Descripion{get;set;}
        public string Tempture{get;set;}
        public string Weight{get;set;}
        public string Ele_C{get;set;}
        public string Ele_Si{get;set;}
        public string Ele_Mn{get;set;}
        public string Ele_S{get;set;}
        public string Ele_P{get;set;}
        public string Ele_Cu{get;set;}
        public string Ele_As{get;set;}
        public string Ele_Sn{get;set;}
        public string Ele_Cu5As8Sn{get;set;}
        public string Ele_Cr{get;set;}
        public string Ele_Ni{get;set;}
        public string Ele_Mo{get;set;}
        public string Ele_Ti{get;set;}
        public string Ele_Nb{get;set;}
        public string Ele_Pb{get;set;}
    }

    [System.SerializableAttribute]
    public class KRMixerHeightSpeed
    {
        public DateTime DateAndTime{get;set;}
        public float sngDuration{get;set;}
        public string DateTimeDuration{get;set;}
        public float Height{get;set;}
        public float Speed{get;set;}
    }
    [System.SerializableAttribute]
    public class BOFHeatInfo
    {
        public string heat_id{get;set;}
        public string treatpos{get;set;}
        public string plan_no{get;set;}
        public string pono{get;set;}
        public string steel_grade{get;set;}
        public string promodecode{get;set;}
        public string bof_campaign{get;set;}
        public string bof_life{get;set;}
        public string tappinghole{get;set;}
        public string tap_hole_campaign{get;set;}
        public string tap_hole_life{get;set;}
        public string mainlance_id{get;set;}
        public string mainlance_life{get;set;}
        public string sublance_id{get;set;}
        public string sublance_life{get;set;}
        public string bath_level{get;set;}
        public string steelladleid{get;set;}
        public string slag_cal_weight{get;set;}
        public string slag_net_weight{get;set;}
        public string weight_cal{get;set;}
        public string weight_act{get;set;}
        public string weighting_time{get;set;}
        public string tem_act{get;set;}
        public string tem_time{get;set;}
        public string bofc_act{get;set;}
        public string o2ppm_act{get;set;}
        public string ladleid{get;set;}
        public string hmw_act{get;set;}
        public string hm_tem{get;set;}
        public string hm_c{get;set;}
        public string hm_si{get;set;}
        public string hm_mn{get;set;}
        public string hm_p{get;set;}
        public string hm_s{get;set;}
        public string bucketid{get;set;}
        public string scrw_act{get;set;}
        public string pi_act{get;set;}
        public string return_act{get;set;}
        public string metal_act{get;set;}
        public string cao_weight{get;set;}
        public string dolo_weight{get;set;}
        public string rdolo_weight{get;set;}
        public string mgo_weight{get;set;}
        public string caf2_weight{get;set;}
        public string iron_weight{get;set;}
        public string o2_act{get;set;}
        public string ar_act{get;set;}
        public string n2_act{get;set;}
        public string tsc_tem{get;set;}
        public string tsc_c{get;set;}
        public string tsc_duration{get;set;}
        public string tso_tem{get;set;}
        public string tso_c{get;set;}
        public string tso_o2ppm{get;set;}
        public string tso_duration{get;set;}
        public string o2_duration{get;set;}
        public string ar_duration{get;set;}
        public string n2_duration{get;set;}
        public string after_stiring_duration{get;set;}
        public string reblow_num{get;set;}
        public string reblow1_tem{get;set;}
        public string reblow2_tem{get;set;}
        public string deslag_num{get;set;}
        public string slag_splash_n2{get;set;}
        public string ready_time{get;set;}
        public string charging_starttime{get;set;}
        public string hm_time{get;set;}
        public string scrap_time{get;set;}
        public string charging_endtime{get;set;}
        public string blow_starttime{get;set;}
        public string blow_endtime{get;set;}
        public string reblow1_starttime{get;set;}
        public string reblow1_endtime{get;set;}
        public string reblow1_duration{get;set;}
        public string reblow2_starttime{get;set;}
        public string reblow2_endtime{get;set;}
        public string reblow2_duration{get;set;}
        public string slag_nr{get;set;}
        public string tapping_starttime{get;set;}
        public string tapping_endtime{get;set;}
        public string tapping_duration{get;set;}
        public string slag_starttime{get;set;}
        public string slag_endtime{get;set;}
        public string slag_duration{get;set;}
        public string product_day{get;set;}
        public string shift_id{get;set;}
        public string crew_id{get;set;}
        public string operator_c{get;set;}
        public string checkdate{get;set;}
        public string checkoperator{get;set;}
        public string checkflag{get;set;}
        public string ge_no{get;set;}
        public string tsc_starttime{get;set;}
        public string tsc_endtime{get;set;}
        public string tso_starttime{get;set;}
        public string tso_endtime{get;set;}
        public string splash_starttime{get;set;}
        public string splash_endtime{get;set;}
        public string splash_duration{get;set;}
        public string o2_press{get;set;}
        public string o2_flux{get;set;}
        public string n2_press{get;set;}
        public string n2_flux{get;set;}
        public string sheetiron_wgt{get;set;}
        public string restrin_wgt{get;set;}
        public string alloycao_wgt{get;set;}
        public string cadd_wgt{get;set;}
        public string fesi_wgt{get;set;}
        public string al_wgt{get;set;}
        public string mnsi_wgt{get;set;}
        public string femn_wgt{get;set;}
        public string fenb_wgt{get;set;}
        public string hscrw_wgt{get;set;}
        public string lscrw_wgt{get;set;}
        public string sscrw_wgt{get;set;}
        public string mfemn_wgt{get;set;}
        public string lfemn_wgt{get;set;}
        public string duststeam_vol{get;set;}
        public string dustwater_vol{get;set;}
        public string recyclesteam_vol{get;set;}
        public string outsteam_vol{get;set;}
        public string mainlance_id1{get;set;}
        public string mainlance_life1{get;set;}
        public string ladlear_act{get;set;}
        public string ironid{get;set;}
        public string rdolo_wgt{get;set;}
        public string change_wgt{get;set;}
        public string burnslag_wgt{get;set;}
        public string lfslag_wgt{get;set;}
        public string sicabei_wgt{get;set;}
        public string sialfe_wgt{get;set;}
        public string mn_wgt{get;set;}

        public string IRON_LADLE_ID{get;set;}
        public string IRON_ID{get;set;}
        public string HM_WEIGHT{get;set;}
        public string HM_TRPMTURE{get;set;}
        public string HM_TIME{get;set;}
        public string HM_SOUREC{get;set;}
        public string SCRAP_BUCKET_ID{get;set;}
        public string SCRAP_ID{get;set;}
        public string SCRAP_WEIGHT{get;set;}
        public string HSCRW_WEIGHT{get;set;}
        public string LSCRW_WEIGHT{get;set;}
        public string SSCRW_WEIGHT{get;set;}

    }

    [System.SerializableAttribute]
    public class BOF_HisDB
    {
        public DateTime datetime{get;set;}
        public float Duration{get;set;}
        public float O2{get;set;}
        public float CO{get;set;}
        public float CO2{get;set;}

        public float ACT_INCLINE_ANGLE{get;set;}
        public float ACT_LANCE_HEIGHT{get;set;}
        public float ACT_O2_FLUX{get;set;}

        public float ACT_N2_FLUX{get;set;}
        public float ACT_AR_FLUX{get;set;}
        public float ACT_BATH_LEVEL{get;set;}
    }

    [System.SerializableAttribute]
    public class BOFKeyEvents
    {
        public string datetime{get;set;}
        public float Duration{get;set;}
        public string Decription{get;set;}
        public string Mat_Name{get;set;}
        public string Weight{get;set;}
        public string Temp{get;set;}
        public string O2ppm{get;set;}
        public string Ele_C{get;set;}
        public string Ele_Si{get;set;}
        public string Ele_Mn{get;set;}
        public string Ele_S{get;set;}
        public string Ele_P{get;set;}
        public string Ele_Cu{get;set;}
        public string Ele_As{get;set;}
        public string Ele_Sn{get;set;}
        public string Ele_Cr{get;set;}
        public string Ele_Ni{get;set;}
        public string Ele_Mo{get;set;}
        public string Ele_Ti{get;set;}
        public string Ele_Nb{get;set;}
        public string Ele_Pb{get;set;}
    }

    [System.SerializableAttribute]
    public class BOF_HM
    {
        public string HEATID{get;set;}
        public string LADLEID{get;set;}
        public string IRONID{get;set;}
        public string MOLTENIRON_WEIGHT{get;set;}
        public string MOLTENIRON_TEMPERATURE{get;set;}
        public string MOLTENIRON_TEMPERATURE_TIME{get;set;}
        public string C{get;set;}
        public string SI{get;set;}
        public string MN{get;set;}
        public string P{get;set;}
        public string S{get;set;}
        public string MOLTENIRON_SOURCE{get;set;}
        public string MOLTENSTEEL_WEIGHT{get;set;}
        public string REMARK{get;set;}
    }

    public class HEAT_TRACK
    {
        public string HeatID{get;set;}
        public string SteelGrade{get;set;}
        public string MI_Station{get;set;}
        public string KR_Station{get;set;}
        public string BOF_Station{get;set;}
        public string LF_Station{get;set;}
        public string RH_Station{get;set;}
        public string CC_Station{get;set;}

        public string MI_Arrive_Time{get;set;}
        public string KR_Arrive_Time{get;set;}
        public string BOF_Arrive_Time{get;set;}
        public string LF_Arrive_Time{get;set;}
        public string RH_Arrive_Time{get;set;}
        public string CC_Arrive_Time{get;set;}

        public string MI_Leave_Time{get;set;}
        public string KR_Leave_Time{get;set;}
        public string BOF_Leave_Time{get;set;}
        public string LF_Leave_Time{get;set;}
        public string RH_Leave_Time{get;set;}
        public string CC_Leave_Time{get;set;}

        public string MI_Duration{get;set;}
        public string KR_Duration{get;set;}
        public string BOF_Duration{get;set;}
        public string LF_Duration{get;set;}
        public string RH_Duration{get;set;}
        public string CC_Duration{get;set;}
    }

    public class Addition
    {
        public string DEVICE_NO{get;set;}
        public string STATION{get;set;}
        public string HEAT_ID{get;set;}
        public string ADD_TIME{get;set;}
        public string ADD_BATCH{get;set;}
        public string MAT_ID{get;set;}
        public string MAT_NAME{get;set;}
        public string WEIGHT{get;set;}
        public string HOPPER_ID{get;set;}
        public string PLACE{get;set;}

    }

    public class TEMPTURE
    {
        public string DEVICE_NO{get;set;}
        public string STATION{get;set;}
        public string HEAT_ID{get;set;}
        public string MEASURE_TYPE{get;set;}
        public string MEASURE_TIME{get;set;}
        public string MEASURE_NUM{get;set;}
        public string TRMPTURE_VALUE{get;set;}
    }
    public class ELEM_ANA
    {
        public string DEVICE_NO{get;set;}
        public string STATION{get;set;}
        public string HEAT_ID{get;set;}
        public string IRON_ID{get;set;}
        public string SAMPLETIME{get;set;}
        public string SAMPLE_NUMBER{get;set;}
        public string SAMPLE_ID{get;set;}
        public string ELE_ALS{get;set;}
        public string ELE_ALT{get;set;}
        public string ELE_AS{get;set;}
        public string ELE_B{get;set;}
        public string ELE_BI{get;set;}
        public string ELE_C{get;set;}
        public string ELE_CA{get;set;}
        public string ELE_CE{get;set;}
        public string ELE_CEQ{get;set;}
        public string ELE_CO{get;set;}
        public string ELE_CR{get;set;}
        public string ELE_CU{get;set;}
        public string ELE_H{get;set;}
        public string ELE_MG{get;set;}
        public string ELE_MN{get;set;}
        public string ELE_MO{get;set;}
        public string ELE_N{get;set;}
        public string ELE_NB{get;set;}
        public string ELE_NI{get;set;}
        public string ELE_O{get;set;}
        public string ELE_P{get;set;}
        public string ELE_PB{get;set;}
        public string ELE_RE{get;set;}
        public string ELE_S{get;set;}
        public string ELE_SB{get;set;}
        public string ELE_SE{get;set;}
        public string ELE_SI{get;set;}
        public string ELE_SN{get;set;}
        public string ELE_TA{get;set;}
        public string ELE_TE{get;set;}
        public string ELE_TI{get;set;}
        public string ELE_V{get;set;}
        public string ELE_W{get;set;}
        public string ELE_ZN{get;set;}
        public string ELE_ZR{get;set;}
    }
    [System.SerializableAttribute]
    public class LFHeatInfo
    {
        public string heat_id{get;set;}
        public string treatpos{get;set;}
        public string strttime{get;set;}
        public string endtime{get;set;}
        public string station{get;set;}
        public string route{get;set;}

        public string strtgrade{get;set;}
        public string endgrade{get;set;}
        public string strtsteeltemp{get;set;}
        public string endsteeltemp{get;set;}
        public string strtsteelwei{get;set;}
        public string endsteelwei{get;set;}
        public string endslagwei{get;set;}
        public string ladleno{get;set;}
        public string ladlestatus{get;set;}
        public string ladlewei{get;set;}

        public string pon{get;set;}

        public string slidgatelife{get;set;}
        public string slidgatebrname{get;set;}
        public string porozlife{get;set;}
        public string porozbrname{get;set;}
        public string emptydur{get;set;}
        public string eletrdholdtm{get;set;}
        public string totprieng{get;set;}
        public string totseceng{get;set;}
        public string gastype{get;set;}
        public string totgas{get;set;}
        public string shiftnr{get;set;}
        public string shiftteam{get;set;}
        public string monitor{get;set;}
        public string mainoptr1{get;set;}
        public string mainoptr2{get;set;}
    }

    [System.SerializableAttribute]
    public class LF_HisDB
    {
        public DateTime datetime{get;set;}
        public float Duration{get;set;}

        public Int32 SetTapNo{get;set;}
        public Int32 BrkeStatus{get;set;}

        public Int32 PriSideVoltageA{get;set;}
        public Int32 PriSideVoltageB{get;set;}
        public Int32 PriSideVoltageC{get;set;}

        public Int32 PriSideCurrentA{get;set;}
        public Int32 PriSideCurrentB{get;set;}
        public Int32 PriSideCurrentC{get;set;}

        public Int32 SecSideVlotageA{get;set;}
        public Int32 SecSideVlotageB{get;set;}
        public Int32 SecSideVlotageC{get;set;}

        public Int32 SecSideCurrentA{get;set;}
        public Int32 SecSideCurrentB{get;set;}
        public Int32 SecSideCurrentC{get;set;}

        public float BotGasFlux{get;set;}
        public float BotGasPrss{get;set;}
        public float BotGasType{get;set;}

        public float TopGasType{get;set;}
        public float TopGasFlux{get;set;}
        public float TopGasPrss{get;set;}


    }

    [System.SerializableAttribute]
    public class LFKeyEvents
    {
        public string datetime{get;set;}
        public float Duration{get;set;}
        public string Decription{get;set;}
        public string MatCode{get;set;}
        public string MatName{get;set;}
        public string Weight{get;set;}
        public string Temp{get;set;}
        public string O2ppm{get;set;}
        public string Ele_C{get;set;}
        public string Ele_Si{get;set;}
        public string Ele_Mn{get;set;}
        public string Ele_S{get;set;}
        public string Ele_P{get;set;}
        public string Ele_Cu{get;set;}
        public string Ele_As{get;set;}
        public string Ele_Sn{get;set;}
        public string Ele_Cr{get;set;}
        public string Ele_Ni{get;set;}
        public string Ele_Mo{get;set;}
        public string Ele_Ti{get;set;}
        public string Ele_Nb{get;set;}
        public string Ele_Pb{get;set;}
    }
    [System.SerializableAttribute]
    public class CCHeatInfo
    {
        public string CCM{get;set;}
        public string report_counter{get;set;}
        public string task_counter{get;set;}
        public string heat_id{get;set;}
        public string po_id{get;set;}
        public string area_id{get;set;}
        public string station_code{get;set;}
        public string steel_grade_id{get;set;}
        public string final_steel_grade_id{get;set;}
        public string alteration_reason_code{get;set;}
        public string route_id{get;set;}
        public string practice_id{get;set;}
        public string ladle_id{get;set;}
        public string ladle_life{get;set;}
        public string ladle_tare_wgt{get;set;}
        public string start_date{get;set;}
        public string stop_date{get;set;}
        public string start_wgt{get;set;}
        public string final_wgt{get;set;}
        public string tapped_wgt{get;set;}
        public string start_slag_wgt{get;set;}
        public string final_slag_wgt{get;set;}
        public string final_temp{get;set;}
        public string task_note{get;set;}
        public string team_id{get;set;}
        public string foreman_id{get;set;}
        public string shift_code{get;set;}
        public string shift_responsible{get;set;}
        public string scheduled_start_date{get;set;}
        public string hot_heel{get;set;}
        public string avgel1current{get;set;}
        public string avgel2current{get;set;}
        public string avgel3current{get;set;}
        public string avgactpower{get;set;}
        public string tap_to_tap{get;set;}
        public string heat_notes{get;set;}
        public string l3_heat_id{get;set;}
        public string profile_model{get;set;}
        public string eaf_electrode_consumption{get;set;}
        public string liquidus_temp{get;set;}


        public string ladle_arrival_wgt{get;set;}
        public string seq_counter{get;set;}
        public string seq_heat_counter{get;set;}
        public string seq_total_heats{get;set;}
        public string seq_sched_heats{get;set;}
        public string ladle_turret_arm_code{get;set;}
        public string ladle_arrival_date{get;set;}
        public string ladle_opening_date{get;set;}
        public string ladle_close_date{get;set;}
        public string ladle_opening_wgt{get;set;}
        public string ladle_close_wgt{get;set;}
        public string tundish_id{get;set;}
        public string tundish_life{get;set;}
        public string tundish_car_code{get;set;}
        public string tundish_preheat_time{get;set;}
        public string tundish_preheat_temperature{get;set;}
        public string tundish_at_ladle_open_wgt{get;set;}
        public string tundish_skull_wgt{get;set;}
        public string tundish_powder_type{get;set;}
        public string tundish_powder_wgt{get;set;}
    }

    [System.SerializableAttribute]
    public class CC_SlabInfo
    {
        public string slab_no{get;set;}
        public string HEAT_ID{get;set;}
        public string STEEL_GRADE{get;set;}
        public string CCM{get;set;}
        public string STRAND_NO{get;set;}
        public string PROD_COUNTER{get;set;}
        public string PROD_NO{get;set;}
        public string WIDTH{get;set;}
        public string WIDTH_HEAD{get;set;}
        public string WIDTH_TAIL{get;set;}
        public string THICKNESS{get;set;}
        public string TAPER_START{get;set;}
        public string TAPER_END{get;set;}
        public string LENGTH{get;set;}
        public string WEIGHT{get;set;}
        public string START_TIME{get;set;}
        public string STOP_TIME{get;set;}
        public string START_CAST_POS{get;set;}
        public string STOP_CAST_POS{get;set;}
        public string SAMPLE_WGT{get;set;}
        public string DEFECT_LEVEL{get;set;}
        public string MANUAL_REPORT_FLG{get;set;}
        public string MANUAL_CUT_FLG{get;set;}
        public string CUT_DATE{get;set;}
        public string WEIGHT_REAL{get;set;}
    }

    [System.SerializableAttribute]
    public class CC_HisData0
    {
        public DateTime datetime{get;set;}
        public float Duration{get;set;}
        public float CastingLength{get;set;}
        public float CastingSpeed{get;set;}
        public float CastingSupperHeatValue{get;set;}
        public float CastingTempture{get;set;}
        public float LD_WEIGHT{get;set;}
        public float MD_LEVAL{get;set;}
        public float MD_LEVAL_DEV{get;set;}
        public float MD_SEN_Immersion{get;set;}
        public float MEMS_Current{get;set;}
        public float MEMS_Frequency{get;set;}
        public float NOZZLE_AR_FLUX{get;set;}
        public float TD_WEIGHT{get;set;}
    }

    public class CC_MDCoolHisDB
    {   //结晶器冷却过程参数
        public DateTime DateAndTime{get;set;}
        public float Duration{get;set;}

        public float CoolWaterInTempure{get;set;}//MDCW_INLET_TEMP 结晶器冷却水入口温度

        public float CoolWaterFlux_Fix{get;set;}// MD_Fix_face_water_flow 结晶器冷却水流量(固定面)
        public float CoolWaterFlux_Loose{get;set;}//MD_Loose_face_water_flow{get;set;}//	结晶器冷却水流量(松开面)
        public float CoolWaterFlux_Right{get;set;}//	MD_Right_face_water_flow 结晶器冷却水流量(右侧)
        public float CoolWaterFlux_Left{get;set;}//	MD_Left_face_water_flow结晶器冷却水流量(左侧)

        public float CoolWaterDiffTemp_Fix{get;set;}//  MD_Fix_face_water_delta_T{get;set;}//	结晶器冷却水温差(固定面)
        public float CoolWaterDiffTemp_Loose{get;set;}//MD_Loose_face_water_delta_T{get;set;}//	结晶器冷却水温差(松散面)
        public float CoolWaterDiffTemp_Right{get;set;}// MD_Right_face_water_delta_T{get;set;}//	结晶器冷却水温差(右侧)
        public float CoolWaterDiffTemp_Left{get;set;}// MD_Left_face_water_delta_T{get;set;}//	结晶器冷却水温差(左侧)

        public float HeatFlux_Fix{get;set;}//MD_LEFT_FACE_EXTRACT{get;set;}//	结晶器冷却：固定面热流密度
        public float HeatFlux_Loose{get;set;}//MD_LOSE_FACE_EXTRACT{get;set;}//	结晶器冷却：松散面热流密度
        public float HeatFlux_Right{get;set;}//MD_RIGHT_FACE_EXTRACT	{get;set;}//结晶器冷却：右侧面热流密度
        public float HeatFlux_Left{get;set;}//MD_FIX_FACE_EXTRACT{get;set;}//结晶器冷却：左侧面热流密度        
    }
}
