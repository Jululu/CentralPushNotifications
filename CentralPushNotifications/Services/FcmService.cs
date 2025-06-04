using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace CentralPushNotifications.Services;

public class FcmService
{
    private readonly FirebaseApp _app;

    public FcmService(IConfiguration configuration)
    {
        var path = configuration["Firebase:CredentialsPath"];
        if (FirebaseApp.DefaultInstance == null)
        {
            _app = FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(path)
            });
        }
        else
        {
            _app = FirebaseApp.DefaultInstance;
        }
    }

    public async Task<string> SendAsync(string title, string body, string token)
    {
        var message = new Message
        {
            Notification = new Notification
            {
                Title = title,
                Body = body
            },
            Token = token
        };

        return await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}
