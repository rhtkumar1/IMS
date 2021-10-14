﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiabilitiesManagementSystem.Models.ViewModel
{
    public class User
    {
        public int UserId { get; set; }
        public int LoginId { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string PinCode { get; set; }
        public string Address { get; set; }
        public string AadharNumber { get; set; }
        private string _LoginId;
        private bool _Islogin;
        public bool Islogin { get { return _Islogin; } }

        public User()
                   : this("0")
        {

        }
        public User(string PLoginId)
        {
            _LoginId = PLoginId;
            _Islogin = false;
        }
    }
}