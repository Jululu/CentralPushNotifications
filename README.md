# CentralPushNotifications

This project provides a minimal ASP.NET Core API for sending Firebase Cloud Messaging (FCM) push notifications.

## Firebase configuration

1. Create a Firebase project in the [Firebase console](https://console.firebase.google.com/).
2. Generate a new **service account** key and download the JSON credentials file.
3. Place the downloaded file somewhere on your server and set its path in `appsettings.Development.json` (or `appsettings.json`) under the `Firebase:CredentialsPath` option.
4. Copy `Firebase/serviceAccount.example.json` to the location of your credentials file and fill it with your real values.

Front-end applications can share the configuration found in `Firebase/firebase.client.example.json`.

## Running the API

```bash
# Build the solution
# dotnet build

# Run the API
# dotnet run --project CentralPushNotifications/CentralPushNotifications.csproj
```

The API exposes a single endpoint `/notifications` to send a push notification using a device token.
