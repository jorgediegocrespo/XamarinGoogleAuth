using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Services;
using Xamarin.Forms;

namespace OAuth
{
    public partial class MainPage : ContentPage, IGoogleAuthenticationDelegate
    {
        private IGoogleAuthService _googleAuthService;

        public MainPage()
        {
            InitializeComponent();

            _googleAuthService = DependencyService.Resolve<IGoogleAuthService>();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            _googleAuthService.Autheticate(this);
        }


        public void OnAuthenticationCanceled()
        {
            lbAccountInfo.Text = "Authentication canceled";
        }

        public async void OnAuthenticationCompleted(GoogleOAuthToken token)
        {
            var googleService = new GoogleAccountInfoService();
            lbAccountInfo.Text = await googleService.GetEmailAsync(token.TokenType, token.AccessToken);
        }

        public void OnAuthenticationFailed(string message, Exception exception)
        {
            lbAccountInfo.Text = "Authentication failed";
        }
    }
}
