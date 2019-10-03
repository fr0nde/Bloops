using Facebook.Unity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public static class FacebookService
    {
        public static bool IsLogged 
        { 
            get
            {
                return FB.IsLoggedIn;
            } 
        }

        public static async Task<bool> AuthenticateAsync()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, result =>
            {
                tcs.SetResult(!string.IsNullOrEmpty(result?.RawResult));
            });
            return await tcs.Task;
        }
    }
}
