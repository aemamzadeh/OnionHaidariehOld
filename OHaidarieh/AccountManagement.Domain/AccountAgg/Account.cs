using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account:EntityBase
    {
        public string Fname { get; private set; }
        public string Lname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fname, string lname, string username, string password, string mobile, long roleId, string profilePhoto)
        {
            Fname = fname;
            Lname = lname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            ProfilePhoto = profilePhoto;
        }
        public void Edit(string fname, string lanme, string username, string mobile, long roleId, string profilePhoto)
        {
            Fname = fname;
            Lname = lanme;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(ProfilePhoto))
                ProfilePhoto = profilePhoto;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
