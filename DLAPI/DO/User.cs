using System.Collections.Generic;

namespace DO
{
    /// <summary>
    ///  two types of users: 1. admin 2. user
    /// </summary>
    public class User
    {
        /* menahel has no access to users info*/
        private List<Trip> trips;
        User() { trips = new List<Trip>(); }

        public User(List<Trip> trips, string userName, string password, bool admin) : this()
        {
            UserName = userName;
            Password = password;
            Admin = admin;
        }

        internal IEnumerable<Trip> GetTrips()
        {
            return this.trips;
        }
        #region properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        #endregion
    }
}
