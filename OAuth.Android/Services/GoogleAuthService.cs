using OAuth.Droid.Services;
using OAuth.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(GoogleAuthService))]
namespace OAuth.Droid.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        internal static MainActivity MainActivity { get; set; }

        public GoogleAuthService()
        {

        }

        public void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate)
        {
            GoogleAuthenticatorHelper.Auth = new GoogleAuthenticator(
               "964681194779-8219jilqvq65g6b9pafmqsohfcnj7m0k.apps.googleusercontent.com",
               "email",
               "com.jdc.OAuth:/oauth2redirect",
               googleAuthenticationDelegate);

            // Display the activity handling the authentication
            var authenticator = GoogleAuthenticatorHelper.Auth.GetAuthenticator();
            var intent = authenticator.GetUI(MainActivity);
            MainActivity.StartActivity(intent);
        }
    }
}
