using System;

namespace Aria.GoogleFCM
{
    public interface IFirebaseIIDService
    {
        //Methods
        void OnTokenRefresh();
        void SendRegistrationToServer(string token);
    }
}
