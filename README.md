# StalcraftSharp
A .NET 6 wrapper for Stalcraft's HTTP API. Documentation on the API can be found here: https://eapi.stalcraft.net/.

## Note
The Stalcraft API is under active development, and as a result, this api is under active development.

## Todo
1. Implement better testing modules

## Getting Started
**I'd highly recommend you read through Stalcraft's api documentation, or at the very least read through the OAuth flow. There is a lot of good information in there that won't be included here.**

1. Setup your application via Stalcraft's telegram service.
2. Request authorization from the user. We do this by navigating to an authorization url constructed with the scopes and redirects we need.
```C#
string authorizationUrl = string.Empty;
OAuthClient oAuthClient = null;

// Create a new oauth client
oAuthClient = new StalcraftSharp.OAuthClient(<your client id>, <your client secret>, <redirect url>);

// Build an oauth authorization url
authorizationUrl = oAuthClient.GetAuthorizationUrl(OAuthClient.Scopes.Nothing); // At the moment, stalcraft doesn't have any scopes.
```
3. Once the user redirects, if they have allowed the app, the redirect url will have two parameters, `code` and `state`. If those are missing, they likely didn't allow access for our app. Take the code parameter value and request your authorization tokens:
```C#
OAuthTokens tokens = null;

// Validate the receipt of the user's token
tokens = await oAuthClient.GetAuthorizationTokensAsync(<code>); // This will return your access token, refresh token, and an expiration time. 
```

And that's it.
