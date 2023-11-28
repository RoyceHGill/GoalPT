using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalPtApp.APIBaseURLs
{
    public class GoalPtConnection
    {

        public GoalPtConnection(IConfiguration configuration)
        {
            //#if DEBUG
            //            Url = configuration["BaseUrlGoalPtApiDebug"];
            //#else
            Url = configuration["BaseUrlGoalPtApiRelease"];
            //#endif
        }

        public string Url { get; set; }
    }
}
