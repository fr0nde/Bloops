using System.Threading.Tasks;
using UnityEngine;

public static class SocialService
{
    #region Static properties

    public static string SocialID
    {
        get { return Social.localUser?.id; }
    }

    public static string SocialName
    {
        get { return Social.localUser?.userName; }
    }

    #endregion

    #region Public static methods

    public static async Task<bool> AuthenticateAsync()
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        Social.localUser.Authenticate(success => tcs.SetResult(success));
        return await tcs.Task;
    }

    #endregion
}
