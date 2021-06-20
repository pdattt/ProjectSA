﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Models
{
    public class UserDAO
    {
        FurnitureDataContext db = new FurnitureDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public bool AddNew(User user)
        {
            try
            {
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckExist(string username)
        {
            User user = db.Users.Where(x => x.Username == username).SingleOrDefault();

            if (user != null)
                return true;
            return false;
        }

        public User GetDetail(string username)
        {
            User user = db.Users.Where(x => x.Username == username).SingleOrDefault();

            return user;
        }

        public static string Encrypt(string password)
        {
            string Key = "1975";

            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

    }
}