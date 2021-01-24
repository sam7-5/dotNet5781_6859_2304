using System.Collections.Generic;

namespace DO
{
    /// <summary>
    ///  two types of users: 1. admin 2. user
    /// </summary>
    public class User
    {
        /* menahel has no access to users info*/
        public User(List<Trip> trips, string userName, string password, bool admin) 
        {
            UserName = userName;
            Password = password;
            Admin = admin;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

    }
}
