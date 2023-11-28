using GoalPtApp.APIBaseURLs;
using GoalPtApp.MsalClient;
using GoalPtApp.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace GoalPtApp.Pages;

public partial class MainPage : ContentPage
{
    //private string _accessToken = string.Empty;
    //private string _goalPtBaseUrl = string.Empty;



    //bool _isLoggedIn = false;
    //public bool IsLoggedIn
    //{
    //    get => _isLoggedIn;
    //    set
    //    {
    //        if (value == _isLoggedIn) return;
    //        _isLoggedIn = value;
    //        OnPropertyChanged(nameof(IsLoggedIn));
    //    }
    //}

    public MainPage(MainPageViewModel vm)
    {

        InitializeComponent();
        BindingContext = vm;
        //_ = Login();
    }


    //private async Task Login()
    //{
    //    try
    //    {
    //        // Attempt silent login, and obtain access token.
    //        var result = await PCAWrapper.Instance.AcquireTokenSilentAsync(PCAWrapper.Scopes).ConfigureAwait(false);
    //        IsLoggedIn = true;

    //        // Set access token
    //        _accessToken = result.AccessToken;

    //        // Display Access Token
    //        await ShowOkMessage("Access Token form AcureTokenSilentAsync call", _accessToken).ConfigureAwait(false);

    //    }
    //    // A MsalException will be thrown if this is the first time logging in or after a log out. 
    //    catch (MsalUiRequiredException)
    //    {
    //        // Perform Interactive Login, obtain access token.
    //        var result = await PCAWrapper.Instance.AcquireTokenInteractiveAsync(PCAWrapper.Scopes).ConfigureAwait(false);
    //        IsLoggedIn = true;

    //        // Set Access token.
    //        _accessToken = result.AccessToken;

    //        // Display Access token
    //        await ShowOkMessage("Access Token from Acquire Token Interactive Async call", _accessToken).ConfigureAwait(false);
    //    }
    //    catch (Exception e)
    //    {
    //        IsLoggedIn = false;
    //        await ShowOkMessage("Exception in AcureTokenSilentAsync call", e.Message).ConfigureAwait(false);
    //    }

    //}

    //private async void OnLoginButtonClicked(object sender, EventArgs e)
    //{
    //    await Login().ConfigureAwait(false);
    //}

    //private async void OnLogoutButtonClicked(object sender, EventArgs e)
    //{
    //    _ = await PCAWrapper.Instance.SignOutAsync().ContinueWith(async (t) =>
    //    {
    //        await ShowOkMessage("Signed Out", "Sign out complete.").ConfigureAwait(false);
    //        IsLoggedIn = false;
    //        _accessToken = string.Empty;
    //    }).ConfigureAwait(false);
    //}

    //private async void OnGetATaskButtonClicked(object sender, EventArgs e)
    //{
    //    var ATaskData = await CallApiGetATask(_accessToken).ConfigureAwait(false);

    //    if (ATaskData != String.Empty)
    //    {
    //        await ShowOkMessage("A Task Data: ", ATaskData).ConfigureAwait(false);
    //    }
    //}

    //private async Task<string> CallApiGetATask(string accessToken)
    //{
    //    if (accessToken == string.Empty)
    //    {
    //        return string.Empty;
    //    }

    //    try
    //    {
    //        // Set up Https Client
    //        var client = new HttpClient();

    //        // Construct HTTPs Request
    //        var message = new HttpRequestMessage(HttpMethod.Get, _goalPtBaseUrl);

    //        //Add Authorization JWT Bearer to header. 
    //        message.Headers.Add("Authorization", $"Bearer {accessToken}");

    //        // Send the request Capture Response.
    //        var response = await client.SendAsync(message).ConfigureAwait(false);

    //        // Request convert to string.
    //        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //        // Return Response. 
    //        return responseString;
    //    }
    //    catch (Exception e)
    //    {
    //        return e.ToString();
    //    }
    //}

    //private Task ShowOkMessage(string title, string message)
    //{
    //    _ = Dispatcher.Dispatch(async () =>
    //    {
    //        DisplayAlert(title, message, "OK");
    //    });
    //    return Task.CompletedTask;
    //}
}

