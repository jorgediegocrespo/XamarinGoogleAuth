using System;
namespace OAuth.Services
{
    public interface IGoogleAuthService
    {
        void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate);

    }
}
