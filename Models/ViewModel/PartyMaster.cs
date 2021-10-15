﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace IMS.Models.ViewModel
{
    public class PartyMaster
    {

        public int PartyId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int OfficeId { get; set; }
        public int GroupId { get; set; }
        public bool MaintainRef { get; set; }
        public int CreditDays { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal VariableLimit { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int Createdby { get; set; }
        public int Loginid { get; set; }


        public PartyMaster PartyMaster_InsertUpdate(PartyMaster partyMaster)
        {
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Party_Id", partyMaster.PartyId));
                SqlParameters.Add(new SqlParameter("@Title", partyMaster.Title));
                SqlParameters.Add(new SqlParameter("@Code", partyMaster.Code));
                SqlParameters.Add(new SqlParameter("@Office_Id", partyMaster.OfficeId));
                SqlParameters.Add(new SqlParameter("@Group_Id", partyMaster.GroupId));
                SqlParameters.Add(new SqlParameter("@Maintain_Ref", partyMaster.MaintainRef));
                SqlParameters.Add(new SqlParameter("@CreditDays", partyMaster.CreditDays));
                SqlParameters.Add(new SqlParameter("@CreditLimit", partyMaster.CreditLimit));
                SqlParameters.Add(new SqlParameter("@VariableLimit", partyMaster.VariableLimit));
                SqlParameters.Add(new SqlParameter("@Prefix", partyMaster.Prefix));
                SqlParameters.Add(new SqlParameter("@FirstName", partyMaster.FirstName));
                SqlParameters.Add(new SqlParameter("@MiddleName", partyMaster.MiddleName));
                SqlParameters.Add(new SqlParameter("@LastName", partyMaster.LastName));
                SqlParameters.Add(new SqlParameter("@Mobile", partyMaster.Mobile));
                SqlParameters.Add(new SqlParameter("@Email", partyMaster.Email));
                SqlParameters.Add(new SqlParameter("@Gender", partyMaster.Gender));
                SqlParameters.Add(new SqlParameter("@Address1", partyMaster.Address1)); 
                SqlParameters.Add(new SqlParameter("@Address2", partyMaster.Address2));
                SqlParameters.Add(new SqlParameter("@City", partyMaster.City));
                SqlParameters.Add(new SqlParameter("@State", partyMaster.State));
                SqlParameters.Add(new SqlParameter("@Region", partyMaster.Region));
                SqlParameters.Add(new SqlParameter("@Zip", partyMaster.Zip));
                SqlParameters.Add(new SqlParameter("@Country", partyMaster.Country));
                SqlParameters.Add(new SqlParameter("@Remarks", partyMaster.Remarks));
                SqlParameters.Add(new SqlParameter("@IsActive", partyMaster.IsActive));
                SqlParameters.Add(new SqlParameter("@Loginid", partyMaster.Loginid));
                partyMaster.PartyId = DBManager.ExecuteScalar("Party_Master_Insertupdate", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return partyMaster;
        }


        public DataTable PartyMaster_Get(PartyMaster partyMaster)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Party_Id", partyMaster.PartyId));
                SqlParameters.Add(new SqlParameter("@Title", partyMaster.Title));
                dt = DBManager.ExecuteDataTableWithParameter("Party_Master_Getdata", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return dt;
        }


    }
}