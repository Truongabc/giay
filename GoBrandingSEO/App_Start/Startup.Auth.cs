using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;


namespace GoBrandingSEO
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Home/LoGin"),
                SlidingExpiration = true
            });
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "848170853068-5nm84afcrmkujafterv17i7m34k4gdhg.apps.googleusercontent.com",
                ClientSecret = "cZj-dAjQgSc2hCvmGLkZP18T",
                CallbackPath = new PathString("/GoogleLoginCallback")
            });


        }
    }
}

