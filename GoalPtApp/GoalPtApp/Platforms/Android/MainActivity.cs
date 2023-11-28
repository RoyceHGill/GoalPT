using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using GoalPtApp.MsalClient;
using Microsoft.Identity.Client;

namespace GoalPtApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{


    private string AndroidRedirectURI = $"msauth://com.companyname.goalptb2c/AA66592FCF2D423289B2352DD6D58AH7";

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        PlatformConfig.Instance.RedirectUri = AndroidRedirectURI;
        PlatformConfig.Instance.ParentWindow = this;
    }

    /// <summary>
    /// This is a callback to continue with the authentication. 
    /// </summary>
    /// <param name="requestCode"></param>
    /// <param name="resultCode"></param>
    /// <param name="data"></param>
    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
    }
}
