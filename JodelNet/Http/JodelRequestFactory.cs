using System;
using System.Net.Http;
using JodelNet.Json.Requests;
using JodelNet.Json.Responses;

namespace JodelNet.Http
{
    public class JodelRequestFactory
    {
        public JodelUser User { get; set; }

        public JodelRequestFactory(JodelUser user)
        {
            User = user;
        }

        private Func<IJodelRequest<CreateAccountResponse>> _createAccountRequestFactory;
        public Func<IJodelRequest<CreateAccountResponse>> CreateAccountRequestFactory
        {
            get
            {
                if (_createAccountRequestFactory == null)
                {
                    var request = new CreateAccountRequest(User, HttpMethod.Post, "/users/", "v2", "", false);
                    _createAccountRequestFactory = (_createAccountRequestFactory = () => request);
                    return _createAccountRequestFactory;
                }
                return _createAccountRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostResponse>> _getPostsPopularRequestFactory;
        public Func<IJodelRequest<GetPostResponse>> GetPostsPopularRequestFactory
        {
            get
            {
                if (_getPostsPopularRequestFactory == null)
                {
                    var request = new GetPostsRequest(User, HttpMethod.Get, "/posts/location/popular"); //channel/popular
                    _getPostsPopularRequestFactory = (_getPostsPopularRequestFactory = () => request);
                }
                return _getPostsPopularRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostResponse>> _getPostsRecentRequestFactory;
        public Func<IJodelRequest<GetPostResponse>> GetPostsRecentRequestFactory
        {
            get
            {
                if (_getPostsRecentRequestFactory == null)
                {
                    var request = new GetPostsRequest(User, HttpMethod.Get, "/posts/location/");
                    _getPostsRecentRequestFactory = (_getPostsRecentRequestFactory = () => request);
                }
                return _getPostsRecentRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostResponse>> _getPostsDiscussedRequestFactory;
        public Func<IJodelRequest<GetPostResponse>> GetPostsDiscussedRequestFactory
        {
            get
            {
                if (_getPostsDiscussedRequestFactory == null)
                {
                    var request = new GetPostsRequest(User, HttpMethod.Get, "/posts/location/discussed");
                    _getPostsDiscussedRequestFactory = (_getPostsDiscussedRequestFactory = () => request);
                }
                return _getPostsDiscussedRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _setLocationRequestFactory;
        public Func<IJodelRequest<bool>> SetLocationComboRequestFactory
        {
            get
            {
                if (_setLocationRequestFactory == null)
                {
                    var request = new SetLocationRequest(User, HttpMethod.Put, "/users/location");
                    _setLocationRequestFactory = (_setLocationRequestFactory = () => request);
                }
                return _setLocationRequestFactory;
            }
        }


        private Func<IJodelRequest<GetRecommendedChannelsResponse>> _getRecommendedChannelsRequestFactory;
        public Func<IJodelRequest<GetRecommendedChannelsResponse>> GetRecommendedChannelsRequestFactory
        {
            get
            {
                if (_getRecommendedChannelsRequestFactory == null)
                {
                    var request = new GetRecommendedChannelsRequest(User, HttpMethod.Get, "/user/recommendedChannels");
                    _getRecommendedChannelsRequestFactory = (_getRecommendedChannelsRequestFactory = () => request);
                }
                return _getRecommendedChannelsRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _pushTokenRequestFactory;
        public Func<IJodelRequest<bool>> PushTokenRequestFactory
        {
            get
            {
                if (_pushTokenRequestFactory == null)
                {
                    var request = new PushTokenRequest(User, HttpMethod.Put, "/users/pushToken");
                    _pushTokenRequestFactory = (_pushTokenRequestFactory = () => request);
                }
                return _pushTokenRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _verifyPushTokenRequestFactory;
        public Func<IJodelRequest<bool>> VerifyPushTokenRequestFactory
        {
            get
            {
                if (_verifyPushTokenRequestFactory == null)
                {
                    var request = new VerifyPushTokenRequest(User, HttpMethod.Post, "/user/verification/push", "v3");
                    _verifyPushTokenRequestFactory = (_verifyPushTokenRequestFactory = () => request);
                }
                return _verifyPushTokenRequestFactory;
            }
        }

        private Func<IJodelRequest<string>> _getPostDetailsRequestFactory;
        public Func<IJodelRequest<string>> GetPostDetailsRequestFactory
        {
            get
            {
                if (_getPostDetailsRequestFactory == null)
                {
                    var request = new GetPostDetailsRequest(User, HttpMethod.Get, "/posts/", "v3");
                    _getPostDetailsRequestFactory = (_getPostDetailsRequestFactory = () => request);
                }
                return _getPostDetailsRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _followChannelRequestFactory;
        public Func<IJodelRequest<bool>> FollowChannelRequestFactory
        {
            get
            {
                if (_followChannelRequestFactory == null)
                {
                    var request = new FollowChannelRequest(User, HttpMethod.Put, "/user/followChannel", "v3");
                    _followChannelRequestFactory = (_followChannelRequestFactory = () => request);
                }
                return _followChannelRequestFactory;
            }
        }

        private Func<IJodelRequest<CreateAccountResponse>> _refreshAccessTokenRequestFactory;
        public Func<IJodelRequest<CreateAccountResponse>> RefreshAccessTokenRequestFactory
        {
            get
            {
                if (_refreshAccessTokenRequestFactory == null)
                {
                    var request = new RefreshAccessTokenRequest(User, HttpMethod.Post, "/users/refreshToken");
                    _refreshAccessTokenRequestFactory = (_refreshAccessTokenRequestFactory = () => request);
                }
                return _refreshAccessTokenRequestFactory;
            }
        }

        private Func<IJodelRequest<GetUserConfigResponse>> _getUserConfigRequestFactory;
        public Func<IJodelRequest<GetUserConfigResponse>> GetUserConfigRequestFactory
        {
            get
            {
                if (_getUserConfigRequestFactory == null)
                {
                    var request = new GetUserConfigRequest(User, HttpMethod.Get, "/user/config", "v3");
                    _getUserConfigRequestFactory = (_getUserConfigRequestFactory = () => request);
                }
                return _getUserConfigRequestFactory;
            }
        }
    }
}
