namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public long RoleId { get; set; }

        public AuthViewModel(long id, string fname, string lname, string username, long roleId)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            Username = username;
            RoleId = roleId;
        }
    }
}