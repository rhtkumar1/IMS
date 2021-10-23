﻿using IMS.Models;
using IMS.Models.CBL;
using IMS.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace IMS.Controllers
{
    [SessionAuthentication]
    public class MasterController : Controller
    {
        string AppToken = "";
        #region Financial Year
        public ActionResult FinancialIndex()
        {
            FinancialMaster financialMaster = new FinancialMaster();
            AppToken = Request.QueryString["AppToken"].ToString();
            int I = CommonUtility.GetLoginID();
            financialMaster.AppToken = AppToken;
            financialMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/FinancialMaster.cshtml", financialMaster);
        }
        [HttpGet]

        public ActionResult GetFinancialMaster(FinancialMaster financialMaster, string AppToken = "")
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                dt = financialMaster.FinancialMaster_Get();
                dt.TableName = "FinancialLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpPost]
        public ActionResult ManageFinancialMaster(FinancialMaster financialMaster)
        {
            try
            {
                FinancialMaster objFinancialMaster = financialMaster.FinancialMaster_InsertUpdate(financialMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                financialMaster.AppToken = AppToken;
                financialMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objFinancialMaster != null)
                {
                    if (objFinancialMaster.FinancialId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/FinancialMaster.cshtml", financialMaster);
        }

        [HttpPost]
        public ActionResult DeleteFinancialMaster(FinancialMaster financialMaster, int financialId)
        {
            try
            {
                financialMaster.FinancialId = financialId;
                FinancialMaster objFinancialMaster = financialMaster.FinancialMaster_Delete(financialMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                financialMaster.AppToken = AppToken;
                financialMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objFinancialMaster != null)
                {
                    if (objFinancialMaster.FinancialId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/FinancialMaster.cshtml", financialMaster);
        }
        #endregion

        #region State Master
        public ActionResult StateIndex()
        {
            StateMaster stateMaster = new StateMaster();
            AppToken = Request.QueryString["AppToken"].ToString().Replace(' ', '+');
            stateMaster.AppToken = AppToken;
            stateMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/StateMaster.cshtml", stateMaster);
        }
        [HttpGet]
        public ActionResult GetStateMaster(StateMaster stateMaster)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = stateMaster.StateMaster_Get();
                dt.TableName = "StateLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        public ActionResult ManageStateMaster(StateMaster stateMaster)
        {
            try
            {
                StateMaster objStateMaster = stateMaster.StateMaster_InsertUpdate(stateMaster);
                AppToken = (Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"]).Replace(' ', '+'); ;
                stateMaster.AppToken = AppToken;
                stateMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objStateMaster != null)
                {
                    if (objStateMaster.StateId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/StateMaster.cshtml", stateMaster);
        }
        [HttpPost]
        public ActionResult DeleteStateMaster(StateMaster stateMaster, int stateId)
        {
            try
            {
                stateMaster.StateId = stateId;
                StateMaster objStateMaster = stateMaster.StateMaster_Delete(stateMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                stateMaster.AppToken = AppToken;
                stateMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objStateMaster != null)
                {
                    if (objStateMaster.StateId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/StateMaster.cshtml", stateMaster);
        }
        #endregion

        #region Location Master
        public ActionResult LocationIndex()
        {
            LocationMaster locationMaster = new LocationMaster();
            AppToken = Request.QueryString["AppToken"].ToString().Replace(' ', '+');
            locationMaster.AppToken = AppToken;
            locationMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/LocationMaster.cshtml", locationMaster);
        }
        [HttpGet]
        public ActionResult GetLocationMaster(LocationMaster locationMaster, string AppToken = "")
        {
            DataTable dt = new DataTable();
            try
            {
                dt = locationMaster.LocationMaster_Get();
                dt.TableName = "LocationLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpPost]
        public ActionResult ManageLocationMaster(LocationMaster locationMaster)
        {
            try
            {
                //locationMaster.Loginid = SyssoftechSession
                LocationMaster objLocationMaster = locationMaster.LocationMaster_InsertUpdate(locationMaster);
                AppToken = (Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"]).Replace(' ', '+');
                locationMaster.AppToken = AppToken;
                locationMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objLocationMaster != null)
                {
                    if (objLocationMaster.LocationId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/LocationMaster.cshtml", locationMaster);
        }

        [HttpPost]
        public ActionResult DeleteLocationMaster(LocationMaster locationMaster, int locationId)
        {
            try
            {
                locationMaster.LocationId = locationId;
                LocationMaster objLocationMaster = locationMaster.LocationMaster_Delete(locationMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                locationMaster.AppToken = AppToken;
                locationMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objLocationMaster != null)
                {
                    if (objLocationMaster.LocationId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/LocationMaster.cshtml", locationMaster);
        }
        #endregion

        #region Company Master
        public ActionResult CompanyIndex()
        {
            CompanyMaster companyMaster = new CompanyMaster();
            AppToken = Request.QueryString["AppToken"].ToString();
            companyMaster.AppToken = AppToken;
            companyMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/CompanyMaster.cshtml", companyMaster);
        }
        [HttpGet]

        public ActionResult GetCompanyMaster(CompanyMaster companyMaster, string AppToken = "")
        {
            DataTable dt = new DataTable();
            try
            {
                dt = companyMaster.CompanyMaster_Get();
                dt.TableName = "CompanyLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpPost]
        public ActionResult ManageCompanyMaster(CompanyMaster companyMaster)
        {
            try
            {
                CompanyMaster objCompanyMaster = companyMaster.CompanyMaster_InsertUpdate(companyMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                companyMaster.AppToken = AppToken;
                companyMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objCompanyMaster != null)
                {
                    if (objCompanyMaster.CompanyId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/CompanyMaster.cshtml", companyMaster);
        }

        [HttpPost]
        public ActionResult DeleteCompanyMaster(CompanyMaster companyMaster, int companyId)
        {
            try
            {
                companyMaster.CompanyId = companyId;
                CompanyMaster objCompanyMaster = companyMaster.CompanyMaster_Delete(companyMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                companyMaster.AppToken = AppToken;
                companyMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objCompanyMaster != null)
                {
                    if (objCompanyMaster.CompanyId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
            }
        }
        #endregion

        #region Office Master
        public ActionResult OfficeIndex()
        {
            OfficeMaster officeMaster = new OfficeMaster();
            AppToken = Request.QueryString["AppToken"].ToString().Replace(' ', '+');
            officeMaster.AppToken = AppToken;
            officeMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/OfficeMaster.cshtml", officeMaster);
        }
        [HttpGet]

        public ActionResult GetOfficeMaster(OfficeMaster officeMaster, string AppToken = "")
        {
            DataTable dt = new DataTable();
            try
            {
                dt = officeMaster.OfficeMaster_Get();
                dt.TableName = "OfficeLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpPost]
        public ActionResult ManageOfficeMaster(OfficeMaster officeMaster)
        {
            try
            {
                OfficeMaster objOfficeMaster = officeMaster.OfficeMaster_InsertUpdate(officeMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                officeMaster.AppToken = AppToken;
                officeMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objOfficeMaster != null)
                {
                    if (objOfficeMaster.OfficeId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/OfficeMaster.cshtml", officeMaster);
        }

        [HttpPost]
        public ActionResult DeleteOfficeMaster(OfficeMaster officeMaster, int officeId)
        {
            try
            {
                officeMaster.OfficeId = officeId;
                OfficeMaster objOfficeMaster = officeMaster.OfficeMaster_Delete(officeMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                officeMaster.AppToken = AppToken;
                officeMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objOfficeMaster != null)
                {
                    if (objOfficeMaster.OfficeId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/OfficeMaster.cshtml", officeMaster);
        }
        #endregion

        #region Role
        public ActionResult RoleIndex()
        {
            RoleMaster roleMaster = new RoleMaster();
            AppToken = Request.QueryString["AppToken"].ToString().Replace(' ', '+');
            roleMaster.AppToken = AppToken;
            roleMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
            return View("~/Views/Admin/Masters/RoleMaster.cshtml", roleMaster);
        }
        [HttpGet]
        public ActionResult GetRoleMaster(RoleMaster roleMaster, string AppToken = "")
        {
            DataTable dt = new DataTable();
            try
            {
                dt = roleMaster.RoleMaster_Get();
                dt.TableName = "RoleLists";
            }
            catch (Exception)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpPost]
        public ActionResult ManageRoleMaster(RoleMaster roleMaster)
        {
            try
            {
                RoleMaster objRoleMaster = roleMaster.RoleMaster_InsertUpdate(roleMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                roleMaster.AppToken = AppToken;
                roleMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objRoleMaster != null)
                {
                    if (objRoleMaster.RoleId > 0)
                    {
                        ViewBag.Msg = "Updated Sucessfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Saved Sucessfully";
                    }
                }
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/RoleMaster.cshtml", roleMaster);
        }

        [HttpPost]
        public ActionResult DeleteRoleMaster(RoleMaster roleMaster, int roleId)
        {
            try
            {
                roleMaster.RoleId = roleId;
                RoleMaster objRoleMaster = roleMaster.RoleMaster_Delete(roleMaster);
                AppToken = Request.QueryString["AppToken"] == null ? Request.Form["AppToken"] : Request.QueryString["AppToken"];
                roleMaster.AppToken = AppToken;
                roleMaster.AuthMode = CommonUtility.GetAuthMode(AppToken).ToString();
                if (objRoleMaster != null)
                {
                    if (objRoleMaster.RoleId > 0)
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Sucess", Msg = "Deleted sucessfully !" }));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                    }
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new { Status = "Error", Msg = "Something went wronge !" }));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "some error occurred, please try again..!";
            }
            return View("~/Views/Admin/Masters/RoleMaster.cshtml", roleMaster);
        }
        #endregion
    }
}