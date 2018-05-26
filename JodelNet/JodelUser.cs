using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.GCM;
using JodelNet.Http;
using JodelNet.Json.Models;
using JodelNet.Json.Responses;

namespace JodelNet
{
    public class JodelUser
    {
        public Location Location { get; set; }
        public string DeviceUid { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string DistinctId { get; set; }
        public int ExpirationDate { get; set; }
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


        public JodelUser()
        {
            
        }

        public JodelUser(Location loc, string deviceUiD, string accessToken, string refreshToken, string distinctId) : this(loc, deviceUiD)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
            DistinctId = distinctId;
        }

        public JodelUser(Location loc, string deviceUiD)
        {
            Location = loc;
            DeviceUid = deviceUiD;
            RequestFactory = new JodelRequestFactory(this);
        }

        public JodelUser(Location loc) : this(loc, AndroidVerification.GetRandomDeviceUid())
        {
        }

        public async Task<bool> CreateAccountAsync()
        {
            if (!string.IsNullOrEmpty(AccessToken) || !string.IsNullOrEmpty(RefreshToken)) return false;

            var rq = new CreateAccountJson
            {
                device_uid = DeviceUid,
                client_id = Constants.CLIENT_ID,
                location = Location
            };
            var result = await RequestFactory.CreateAccountRequestFactory().PerformActionAsync(payload: rq);
            if (string.IsNullOrEmpty(result.access_token))
            {
                return false;
            }
            AccessToken = result.access_token;
            RefreshToken = result.refresh_token;
            ExpirationDate = result.expiration_date;
            DistinctId = result.distinct_id;
            return true;
        }

        public async Task<GetPostResponse> GetPostsRecentAsync()
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.loc_coordinates.lat.ToString()),
                new Pair<string, string>("lng", Location.loc_coordinates.lng.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", "false"),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", "60"),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", "0")
            };

            var result = await RequestFactory.GetPostsRecentRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostResponse> GetPostsPopularAsync()
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.loc_coordinates.lat.ToString()),
                new Pair<string, string>("lng", Location.loc_coordinates.lng.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", "false"),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", "60"),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", "0")
            };

            var result = await RequestFactory.GetPostsPopularRequestFactory().PerformActionAsync(prm);
            return result;
        }

        public async Task<GetPostResponse> GetPostsDiscussedAsync()
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("lat", Location.loc_coordinates.lat.ToString()),
                new Pair<string, string>("lng", Location.loc_coordinates.lng.ToString()),
                new Pair<string, string>("stickies", "false"),
                new Pair<string, string>("home", "false"),
                new Pair<string, string>("channel", ""),
                new Pair<string, string>("limit", "60"),
                new Pair<string, string>("hashtag", ""),
                new Pair<string, string>("skip", "0")
            };

            var result = await RequestFactory.GetPostsDiscussedRequestFactory().PerformActionAsync(prm);
            return result;
        }

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

        public async Task<string> GetPostDetailsAsync(string postId)
        {
            var prm = new List<Pair<string, string>>
            {
                new Pair<string, string>("details", "true"),
                new Pair<string, string>("reply", "0"),
            };

            var result = await RequestFactory.GetPostDetailsRequestFactory().PerformActionAsync(prm, null, postId + "/details");
            return result;
        }

        public async Task<bool> PushTokenAsync(string token)
        {
            return await RequestFactory.PushTokenRequestFactory().PerformActionAsync(null,
                new PushTokenJson() {client_id = Constants.CLIENT_ID, push_token = token});
        }

        public async Task<bool> VerifyPushTokenAsync(string serverTime, string verificationCode)
        {
            return await RequestFactory.VerifyPushTokenRequestFactory().PerformActionAsync(null,
                new VerifyPushTokenJson() { server_time = serverTime, verification_code = verificationCode});
        }

        public async Task<bool> RefreshAccessTokenAsync()
        {
            var result =  await RequestFactory.RefreshAccessTokenRequestFactory().PerformActionAsync(null, new RefreshAccessTokenJson(){ client_id = Constants.CLIENT_ID, distinct_id = DistinctId, refresh_token = RefreshToken});
            if (result.access_token != "")
            {
                AccessToken = result.access_token;
                ExpirationDate = result.expiration_date;
                return result.access_token != "";
            }
            return result.access_token != "";
        }

        public async Task<GetUserConfigResponse> GetUserConfigAsync()
        {
            return await RequestFactory.GetUserConfigRequestFactory().PerformActionAsync();
        }

        public async Task<bool> SetLocationAsync(Location loc)
        {
            Location = loc;
            var result = await RequestFactory.SetLocationComboRequestFactory().PerformActionAsync(payload: new SetLocationJson(){location = loc});
            return result;
        }
    }
}
