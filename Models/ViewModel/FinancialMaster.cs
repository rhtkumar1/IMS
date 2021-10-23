﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IMS.Models.ViewModel
{
    public class FinancialMaster
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int FinancialId { get; set; }
        public bool IsActive { get; set; }
        public int Createdby { get; set; }
        public int Loginid { get; set; }
        public string AppToken { get; set; }
        public string AuthMode { get; set; }

        public FinancialMaster FinancialMaster_InsertUpdate(FinancialMaster financialMaster)
        {
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Financial_id", financialMaster.FinancialId));
                SqlParameters.Add(new SqlParameter("@From_date", Convert.ToDateTime(financialMaster.FromDate)));
                SqlParameters.Add(new SqlParameter("@To_date", Convert.ToDateTime(financialMaster.ToDate)));
                SqlParameters.Add(new SqlParameter("@Loginid", financialMaster.Loginid));
                financialMaster.FinancialId = DBManager.ExecuteScalar("Financial_Master_Insertupdate", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return financialMaster;
        }

        public DataTable FinancialMaster_Get()
        {
            DataTable dt = new DataTable();
            List<FinancialMaster> financialMaster = new List<FinancialMaster>();
            try
            {
                dt = DBManager.ExecuteDataTable("Financial_Master_Getdata", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public FinancialMaster FinancialMaster_Delete(FinancialMaster financialMaster)
        {
            int financialId = 0;
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Financial_id", financialMaster.FinancialId));
                SqlParameters.Add(new SqlParameter("@Loginid", financialMaster.Loginid));
                financialId = DBManager.ExecuteScalar("Financial_Master_Delete", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return financialMaster;
        }

        List<FinancialData> lstFinancialData = new List<FinancialData>();
        public List<FinancialData> Financial_List_Get()
        {
            DataTable dt = new DataTable();
            FinancialData financialData = new FinancialData();
            try
            {
                dt = DBManager.ExecuteDataTable("Financial_Master_Getdata", CommandType.StoredProcedure);
                foreach (DataRow dr in dt.Rows)
                {
                    financialData.FinancialId = Convert.ToInt32(dr["Financial_Id"]);
                    financialData.FinancialYear = Convert.ToString(dr["From_date"]).Substring(6,9) +"-"+ Convert.ToString(dr["To_date"]).Substring(6, 9);
                    lstFinancialData.Add(financialData);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return lstFinancialData;
        }

    }
    public class FinancialData
    { 
        public int FinancialId { get; set; }
        public string FinancialYear { get; set; }
    }
}