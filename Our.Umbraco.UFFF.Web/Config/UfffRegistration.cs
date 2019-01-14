using Our.Umbraco.Ufff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace Our.Umbraco.UFFF.Web.Config
{
    public class UfffRegistration : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            UfffApplication.Init();
        }
    }
}
