using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalPtApp.Settings
{
    public class ClientSettings
    {
        // Azure AD B2C Twitter Authentication
        public string ClientIdSocial { get; set; } = null;
        public string TenantSocial { get; set; } = null;
        public string TenantIdSocial { get; set; } = null;
        public string InstanceSocial { get; set; } = null;
        public string PolicySignUpSignInSocial { get; set; } = null;
        public string AuthoritySocial { get; set; } = null;
        public NestedSettings[] ScopesSocial { get; set; } = null;
    }
}
