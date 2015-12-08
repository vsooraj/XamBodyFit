

using Android.App;
using Android.Content;
namespace XamBodyFit
{

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AuthKey { get; set; }

        public void SaveCacheUserInfo(User user)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString("Id", user.Id.ToString());
            edit.PutString("Email", user.Email);
            edit.PutString("Password", user.Password);
            edit.PutString("AuthKey", user.AuthKey);
            edit.Commit();
        }
        public User GetCacheUserInfo()
        {
            ISharedPreferences sharedPreferences = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string authKey = sharedPreferences.GetString("AuthKey", string.Empty);
            string id = sharedPreferences.GetString("Id", "0");
            string firstName = sharedPreferences.GetString("FirstName", string.Empty);
            string lastName = sharedPreferences.GetString("LastName", string.Empty);
            string email = sharedPreferences.GetString("Email", string.Empty);
            string password = sharedPreferences.GetString("Password", string.Empty);
            User user = new User
            {
                Id = int.Parse(id),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password

            };

            return user;
        }
    }
}