using System;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountSearchModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
    }
}
