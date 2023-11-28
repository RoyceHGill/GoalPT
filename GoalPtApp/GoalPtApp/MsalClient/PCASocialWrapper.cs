using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalPtApp.Settings;
using static System.Formats.Asn1.AsnWriter;

namespace GoalPtApp.MsalClient
{
    public class PCASocialWrapper
    {

        private readonly IConfiguration _configuration;
        private readonly ClientSettings _settings;

        internal IPublicClientApplication PCA { get; }

        internal bool UseEmbedded { get; set; } = false;

        public string[] Scopes { get; set; }



        // Constructor of singleton
        public PCASocialWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _settings = _configuration.GetRequiredSection("Settings").Get<ClientSettings>();
            Scopes = _settings.ScopesSocial.ToStringArray();


            PCA = PublicClientApplicationBuilder
                .Create(_settings.ClientIdSocial)
                .WithB2CAuthority(_settings.AuthoritySocial)
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .Build();
        }

        /// <summary>
        /// Acquire the token Silently. 
        /// </summary>
        /// <param name="scopes">desired scopes</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes)
        {
            var accounts = await PCA.GetAccountsAsync(_settings.PolicySignUpSignInSocial).ConfigureAwait(false);

            var account = accounts.FirstOrDefault();

            var authResult = await PCA.AcquireTokenSilent(scopes, account).ExecuteAsync().ConfigureAwait(false);

            return authResult;
        }

        /// <summary>
        /// Perform the Sign in process to acquire token.
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes)
        {
            var systemWebViewOptions = new SystemWebViewOptions();
#if IOS 
            // embedded view is not supported on Android
            if (UseEmbedded)
            {

                return await PCA.AcquireTokenInteractive(scopes)
                                        .WithUseEmbeddedWebView(false)
                                        .WithParentActivityOrWindow(PlatformConfig.Instance.ParentWindow)
                                        .ExecuteAsync()
                                        .ConfigureAwait(false);
            }

            // Hide the privacy prompt in iOS
            systemWebViewOptions.iOSHidePrivacyPrompt = true;
#endif
            var accounts = await PCA.GetAccountsAsync(_settings.PolicySignUpSignInSocial).ConfigureAwait(false);

            var account = accounts.FirstOrDefault();


            return await PCA.AcquireTokenInteractive(scopes)
                .WithB2CAuthority(_settings.AuthoritySocial)
                .WithAccount(account)
                .WithParentActivityOrWindow(PlatformConfig.Instance.ParentWindow)
                .WithUseEmbeddedWebView(false)
                .ExecuteAsync()
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Signout may not perform the complete signout as company portal may hold the token
        /// </summary>
        /// <returns></returns>
        public async Task SignOutAsync()
        {
            var accounts = await PCA.GetAccountsAsync().ConfigureAwait(false);
            foreach (var account in accounts)
            {
                await PCA.RemoveAsync(account).ConfigureAwait(false);
            }
        }
    }
}


