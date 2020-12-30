namespace DAL.DO
{
    /// <summary>
    ///  two types of users: 1. admin 2. user
    /// </summary>
    public class User
    {
        /* menahel has no access to users info*/
        #region properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        #endregion
    }
}
