namespace MyAuthApi.NewFolder
{
    public class UserInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }  // for age check
        public string Country { get; set; }        // for country check
        public string Role { get; set; }
    }
}
