
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalPtApp.APIBaseURLs;
using GoalPtApp.Models.DTO;
using GoalPtApp.MsalClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GoalPtApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private string _accessToken = string.Empty;
        private string _goalPtBaseUrl = string.Empty;
        private PCASocialWrapper _pcaWrapper;
        private IConfiguration _configuration;


        [ObservableProperty]
        private bool isLoggedIn;

        [ObservableProperty]
        private string response;

        [ObservableProperty]
        private int quantity;

        [ObservableProperty]
        private string model = "gpt-3.5-turbo";

        [ObservableProperty]
        private string prompt;


        public ObservableCollection<GoalDTO> Goals { get; set; } = new();

        private float randomness = 0.1f;

        public MainPageViewModel(GoalPtConnection goalPtConnection, IConfiguration configuration)
        {
            _configuration = configuration;
            _pcaWrapper = new PCASocialWrapper(_configuration);
            _goalPtBaseUrl = goalPtConnection.Url;
            _ = LoginExecute(_pcaWrapper);
        }

        [RelayCommand]
        private async Task Login()
        {
            await LoginExecute(_pcaWrapper).ConfigureAwait(false);
        }

        [RelayCommand]
        private async void Logout()
        {
            await LogoutExecute().ConfigureAwait(false);

        }

        private async Task LogoutExecute()
        {
            _ = await _pcaWrapper.SignOutAsync().ContinueWith(async (t) =>
            {

                IsLoggedIn = false;
                _accessToken = string.Empty;
            }).ConfigureAwait(false);
        }

        [RelayCommand]
        private async void GetAGoal()
        {
            var goals = await CallApiGetAGoal(_accessToken).ConfigureAwait(false);

            foreach (var goal in goals)
            {
                Goals.Add(goal);
            }
        }

        [RelayCommand]
        private async void LoginSocial()
        {
            await LoginExecute(_pcaWrapper).ConfigureAwait(false);
        }

        private async Task<IEnumerable<GoalDTO>> CallApiGetAGoal(string accessToken)
        {
            if (accessToken == string.Empty)
            {
                return null;
            }

            try
            {
                var completion = new CompletionParams()
                {
                    Quantity = Quantity,
                    Model = Model,
                    UserPrompt = Prompt,
                    Randomness = randomness
                };


                // Set up Https Client
                var client = new HttpClient();

                // Construct HTTPs Request
                var message = new HttpRequestMessage(HttpMethod.Post, $"{_goalPtBaseUrl}GenerateResource/Goals");

                ////Add Authorization JWT Bearer to header. 
                message.Headers.Add("Authorization", $"Bearer {accessToken}");

                message.Content = new StringContent(JsonConvert
                .SerializeObject(completion), Encoding.UTF8, "application/json");

                // Send the request Capture Response.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<IEnumerable<GoalDTO>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task LoginExecute(PCASocialWrapper pcaWrapper)
        {
            try
            {
                // Attempt silent login, and obtain access token.
                var result = await pcaWrapper.AcquireTokenSilentAsync(pcaWrapper.Scopes).ConfigureAwait(false);
                IsLoggedIn = true;

                // Set access token
                _accessToken = result.AccessToken;

                // Display Access Token


            }
            // A MsalException will be thrown if this is the first time logging in or after a log out. 
            catch (MsalUiRequiredException)
            {
                try
                {
                    // Perform Interactive Login, obtain access token.
                    var result = await _pcaWrapper.AcquireTokenInteractiveAsync(pcaWrapper.Scopes);
                    IsLoggedIn = true;

                    // Set Access token.
                    _accessToken = result.AccessToken;

                    // Display Access token
                }
                catch (Exception e)
                {

                }

            }
            catch (Exception e)
            {
                IsLoggedIn = false;
            }

        }



    }
}
