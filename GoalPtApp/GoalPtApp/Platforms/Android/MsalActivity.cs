using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace GoalPtApp.Platforms.Android.Resources
{

    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal854e209a-e7f5-40d0-b442-399d46f1d52a")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
