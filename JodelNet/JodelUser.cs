using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.GCM;
using JodelNet.Http;
using JodelNet.Json.RequestModels;
using JodelNet.Json.Responses;

namespace JodelNet
{
    public class JodelUser
    {
        public LocationJson Location { get; set; }
        public string DeviceUid { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string DistinctId { get; set; }
        public long ExpirationDate { get; set; }
        public DateTime ExpirationDateTime
        {
            get
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(ExpirationDate);
                return dateTime;
            }
        }

        public JodelRequestFactory RequestFactory { get; set; }

        #region Constructor
        public JodelUser(LocationJson loc, string deviceUiD, string accessToken, string refreshToken, string distinctId) : this(loc, deviceUiD)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
            DistinctId = distinctId;
        }

        public JodelUser(LocationJson loc, string deviceUiD)
        {
            Location = loc;
            DeviceUid = deviceUiD;
            RequestFactory = new JodelRequestFactory(this);
        }

        public JodelUser(LocationJson loc) : this(loc, AndroidVerification.GetRandomDeviceUid()){}

        public JodelUser(){}

        #endregion

        #region Authentication
        public async Task<bool> CreateAccountAsync()
        {
            if (!string.IsNullOrEmpty(AccessToken) || !string.IsNullOrEmpty(RefreshToken)) return false;

            var rq = new CreateAccountJson
            {
                DeviceUid = DeviceUid,
                ClientId = Constants.CLIENT_ID,
                Location = Location
            };
            var result = await RequestFactory.CreateAccountRequestFactory().PerformActionAsync(payload: rq);
            if (string.IsNullOrEmpty(result.AccessToken))
            {
                return false;
            }
            AccessToken = result.AccessToken;
            RefreshToken = result.RefreshToken;
            ExpirationDate = result.ExpirationDate;
            DistinctId = result.DistinctId;
            return true;
        }

        public async Task<bool> RefreshAccessTokenAsync()
        {
            var result = await RequestFactory.RefreshAccessTokenRequestFactory().PerformActionAsync(null, new RefreshAccessTokenJson() { ClientId = Constants.CLIENT_ID, DistinctId = DistinctId, RefreshToken = RefreshToken });
            if (result.AccessToken != "")
            {
                AccessToken = result.AccessToken;
                ExpirationDate = result.ExpirationDate;
                return result.AccessToken != "";
            }
            return result.AccessToken != "";
        }
        #endregion

        #region Verification
        public async Task<bool> PushTokenAsync(string token)
        {
            return await RequestFactory.PushTokenRequestFactory().PerformActionAsync(null,
                new PushTokenJson() { ClientId = Constants.CLIENT_ID, PushToken = token });
        }

        public async Task<bool> VerifyPushTokenAsync(string serverTime, string verificationCode)
        {
            return await RequestFactory.VerifyPushTokenRequestFactory().PerformActionAsync(null, new VerifyPushTokenJson() { ServerTime = serverTime, VerificationCode = verificationCode });
        }

        public async Task<VerifyInstanceIdResponse> VerifyInstanceIdAsync(string instanceId)
        {
            return await RequestFactory.VerifyInstanceIdRequestFactory().PerformActionAsync(null, new VerifyInstanceIdRequest() { InstanceId = instanceId});
        }
        #endregion

        #region Get posts by location
        public async Task<GetPostsResponse> GetPostsRecentAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsRecentRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsPopularAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsPopularRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsDiscussedAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsDiscussedRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsCombinedResponse> GetPostsComboAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsCombinedRequestFactory().PerformActionAsync(prm);
            return result;
        }
        #endregion

        #region Get posts by channel
        public async Task<GetPostsResponse> GetPostsChannelRecentAsync(string channel, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", channel),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsChannelRecentRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsChannelPopularAsync(string channel, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", channel),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsChannelPopularRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsChannelDiscussedAsync(string channel, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", channel),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsChannelDiscussedRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsCombinedResponse> GetPostsChannelComboAsync(string channel, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", channel),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsChannelCombinedRequestFactory().PerformActionAsync(prm);
            return result;
        }
        #endregion

        #region Get posts by hashtag
        public async Task<GetPostsResponse> GetPostsHashtagRecentAsync(string hashtag, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", hashtag),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsHashtagRecentRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsHashtagPopularAsync(string hashtag, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", hashtag),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsHashtagPopularRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsHashtagDiscussedAsync(string hashtag, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", hashtag),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsHashtagDiscussedRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsCombinedResponse> GetPostsHashtagComboAsync(string hashtag, bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", hashtag),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsHashtagCombinedRequestFactory().PerformActionAsync(prm);
            return result;
        }
        #endregion

        #region Get own posts
        public async Task<GetPostsResponse> GetPostsOwnAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsOwnRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsOwnPopularAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsOwnPopularRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsResponse> GetPostsOwnDiscussedAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsOwnDiscussedRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostsCombinedResponse> GetPostsOwnComboAsync(bool home = false, int limit = 60, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.LocationCoordinates.Latitude.ToString()),
                new Pair<string, string>("lng", Location.LocationCoordinates.Longitude.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", home.ToString()),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", limit.ToString()),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", skip.ToString())
            };

            var result = await RequestFactory.GetPostsOwnCombinedRequestFactory().PerformActionAsync(prm);
            return result;
        }
        #endregion

        #region User interaction
        public async Task<bool> SetLocationAsync(LocationJson loc)
        {
            Location = loc;
            var result = await RequestFactory.SetLocationRequestFactory().PerformActionAsync(payload: new SetLocationJson() { Location = loc });
            return result;
        }

        public async Task<bool> SetHomeTownAsync(LocationJson loc)
        {
            var result = await RequestFactory.SetHomeTownRequestFactory().PerformActionAsync(payload: new SetLocationJson() { Location = loc });
            return result;
        }

        public async Task<bool> DeleteUserHomeAsync()
        {
            return await RequestFactory.DeleteUserHomeRequestFactory().PerformActionAsync();
        }

        public async Task<GetUserConfigResponse> GetUserConfigAsync()
        {
            return await RequestFactory.GetUserConfigRequestFactory().PerformActionAsync();
        }

        public async Task<GetUserStatsResponse> GetUserStatsAsync()
        {
            return await RequestFactory.GetUserStatsRequestFactory().PerformActionAsync();
        }
        #endregion

        #region Post interaction

        public async Task<CreatePostResponse> CreatePostAsync(string message, Constants.PostColor color = Constants.PostColor.Random, string image = "", string postId = "", string channel = "", bool home = false)
        {
            var pl = new CreatePostJson
            {
                Location = Location,
                Ancestor = postId,
                B64Image = image,
                Channel = channel,
                Color = !string.IsNullOrEmpty(postId) ? Constants.GetColor(color) : Constants.GetColor(Constants.PostColor.Random),
                Message = message,
                ToHome = home,
            };
            var result = await RequestFactory.CreatePostRequestFactory().PerformActionAsync(payload: pl);
            return result;
        }

        public async Task<bool> DeletePostAsync(string postId)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("postId", postId),
            };

            var result = await RequestFactory.DeletePostRequestFactory().PerformActionAsync(prm, null, postId);
            return result;
        }

        public async Task<VotePostResponse> UpvotePostAsync(string postId)
        {
            var result = await RequestFactory.VotePostRequestFactory().PerformActionAsync(urlExtension: postId + "/upvote/");
            return result;
        }

        public async Task<VotePostResponse> DownvotePostAsync(string postId)
        {
            var result = await RequestFactory.VotePostRequestFactory().PerformActionAsync(urlExtension: postId + "/downvote/");
            return result;
        }

        public async Task<bool> GiveThanksAsync(string postId)
        {
            var result = await RequestFactory.GiveThanksRequestFactory().PerformActionAsync(urlExtension: postId + "/giveThanks");
            return result;
        }

        public async Task<GetPostDetailsResponse> GetPostDetailsAsync(string postId, int skip = 0)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("details", "true"),
                new Pair<string, string>("reply", skip.ToString()),
            };

            var result = await RequestFactory.GetPostDetailsRequestFactory().PerformActionAsync(prm, null, postId + "/details");
            return result;
        }

        public async Task<GetSharePostUrlResponse> GetSharePostUrlAsync(string postId)
        {
            var result = await RequestFactory.GetSharePostUrlRequestFactory().PerformActionAsync(urlExtension: postId + "/share");
            return result;
        }
        #endregion

        #region Channel interaction
        public async Task<GetRecommendedChannelsResponse> GetRecommendedChannelsAsync()
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("home", "false"),
            };

            var result = await RequestFactory.GetRecommendedChannelsRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<bool> FollowChannelAsync(string channel)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("channel", channel),
            };
            var result = await RequestFactory.FollowChannelRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<bool> FollowChannelsAsync(List<string> channels)
        {
            var req = new FollowChannelsJson {Channels = channels};
            var result = await RequestFactory.FollowChannelsRequestFactory().PerformActionAsync(null, req);
            return result;
        }
        #endregion

        #region Referrer

        public async Task<GetUserInviteCodeResponse> GetUserInviteCode()
        {
            return await RequestFactory.GetUserInviteCode().PerformActionAsync();
        }

        public async Task<bool> PostInviteComplete(string code)
        {
            var obj = new PostInviteCompleteJson
            {
                Post = code,
                Referrer = code,
                Source = code
            };

            return await RequestFactory.PostInviteComplete().PerformActionAsync(payload: obj);
        }

        #endregion

    }
}
