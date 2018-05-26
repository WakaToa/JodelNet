# JodelNet (Inofficial C# Jodel API wrapper)
JodelNet is an inofficial interface to the private Jodel App API. Not affiliated with *The Jodel Venture GmbH*.

----

## Read before start
**This repository was created for educational purposes only.**

----

## Getting started
Create a new JodelUser object
```
Location location = Location.GetFromString("Berlin", "GOOGLEMAPS_APIKEY");
JodelUser jodelUser = new JodelUser(location); //Creates a fresh account object with a given location

Alternatives:

JodelUser jodelUser = new JodelUser(location, "deviceUiD");
JodelUser jodelUser = new JodelUser(location, "deviceUiD", "accessToken", "refreshToken", "distinctId"); //'load' an existing account
```

Create the account.
```
await jodelUser.CreateAccountAsync();
```

To perform all actions (like voting and posting/creating new content), you need to verify your account using Google Cloud Messaging (GCM)
```
await AndroidVerification.VerifyAccountAsync(jodelUser);
```

----

### Methods
```
//Authentication
CreateAccountAsync()
RefreshAccessTokenAsync();

//Verification
PushTokenAsync();
VerifyPushTokenAsync();

//Get posts by location
GetPostsRecentAsync();
GetPostsPopularAsync();
GetPostsDiscussedAsync();
GetPostsComboAsync();

//Get posts by channel
GetPostsChannelRecentAsync();
GetPostsChannelPopularAsync();
GetPostsChannelDiscussedAsync();
GetPostsChannelComboAsync();

//Get posts by hashtag
GetPostsHashtagRecentAsync();
GetPostsHashtagPopularAsync();
GetPostsHashtagDiscussedAsync();
GetPostsHashtagComboAsync();

//Get own posts
GetPostsOwnAsync();
GetPostsOwnPopularAsync();
GetPostsOwnDiscussedAsync();
GetPostsOwnComboAsync();

//User interaction
SetLocationAsync();
SetHomeTownAsync();
DeleteUserHomeAsync();
GetUserConfigAsync();

//Post interaction (verified account needed)
CreatePostAsync();
DeletePostAsync();
UpvotePostAsync();
DownvotePostAsync();
GiveThanksAsync();
GetPostDetailsAsync();
GetSharePostUrlAsync();

//Channel interaction
GetRecommendedChannelsAsync();
FollowChannelAsync();
FollowChannelsAsync();
```

----
### Signing requests | Retrieving the HMAC secret
Jodel signs every request using a HMAC hash. The secret changes every time they update the android app and you need to decrypt the new one from a native x86 library. Take a look at [JodelUpdate](https://github.com/WakaToa/JodelUpdate/) to retrieve the new HMAC secret.

----
### Todos

 - Add all methods from Jodel
 - Code cleanup
----
### Acknowledgments
Thanks to

 - nborrmann ([jodel_api](https://github.com/nborrmann/jodel_api))
 - ioncodes ([JodelAPI](https://github.com/ioncodes/JodelAPI))
 - cfib90 ([ojoc-keyhack](https://bitbucket.org/cfib90/ojoc-keyhack/overview))
 
for developing their awesome projects which helped me a lot understanding how Jodel works.

----
### License

MIT
