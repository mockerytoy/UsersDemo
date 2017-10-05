using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using Users.Repository;

namespace Demo.Web
{
    public class Startup
    {
        public  void Configuration(IAppBuilder app, HostingEnvironment hostingEnvironment)
        {
            ConfigureAuth(app, hostingEnvironment);
            
        }

        public void ConfigureAuth(IAppBuilder app, HostingEnvironment hostingEnvironment)
        {
            app.CreatePerOwinContext(UsersDbContext.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/LogOn"),
                //AuthenticationScheme = "Cookies",
                //AutomaticAuthenticate = true,
                //AutomaticChallenge = true,
                //LoginPath = "/login",
                //CookieSecure = hostingEnvironment.IsDevelopment()
                //            ? CookieSecurePolicy.SameAsRequest
                //            : CookieSecurePolicy.Always
                CookieSecure = CookieSecureOption.SameAsRequest
            });

           // app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

           
        }
    }
}