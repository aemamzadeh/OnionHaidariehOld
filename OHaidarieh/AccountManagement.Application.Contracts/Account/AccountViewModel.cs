using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
        public long RoleId { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
