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

        #region Authentication
        private Func<IJodelRequest<CreateAccountResponse>> _createAccountRequestFactory;
        public Func<IJodelRequest<CreateAccountResponse>> CreateAccountRequestFactory
        {
            get
            {
                if (_createAccountRequestFactory == null)
                {
                    var request = new SimplifiedRequest<CreateAccountResponse>(User, HttpMethod.Post, "/users/", "v2", "");
                    _createAccountRequestFactory = (_createAccountRequestFactory = () => request);
                    return _createAccountRequestFactory;
                }
                return _createAccountRequestFactory;
            }
        }

        private Func<IJodelRequest<CreateAccountResponse>> _refreshAccessTokenRequestFactory;
        public Func<IJodelRequest<CreateAccountResponse>> RefreshAccessTokenRequestFactory
        {
            get
            {
                if (_refreshAccessTokenRequestFactory == null)
                {
                    var request = new SimplifiedRequest<CreateAccountResponse>(User, HttpMethod.Post, "/users/refreshToken");
                    _refreshAccessTokenRequestFactory = (_refreshAccessTokenRequestFactory = () => request);
                }
                return _refreshAccessTokenRequestFactory;
            }
        }
        #endregion

        #region Verification
        private Func<IJodelRequest<bool>> _pushTokenRequestFactory;
        public Func<IJodelRequest<bool>> PushTokenRequestFactory
        {
            get
            {
                if (_pushTokenRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/users/pushToken");
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
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Post, "/user/verification/push", "v3");
                    _verifyPushTokenRequestFactory = (_verifyPushTokenRequestFactory = () => request);
                }
                return _verifyPushTokenRequestFactory;
            }
        }

        private Func<IJodelRequest<VerifyInstanceIdResponse>> _verifyInstanceIdRequestFactory;
        public Func<IJodelRequest<VerifyInstanceIdResponse>> VerifyInstanceIdRequestFactory
        {
            get
            {
                if (_verifyInstanceIdRequestFactory == null)
                {
                    var request = new SimplifiedRequest<VerifyInstanceIdResponse>(User, HttpMethod.Post, "/user/verification/iid", "v3");
                    _verifyInstanceIdRequestFactory = (_verifyInstanceIdRequestFactory = () => request);
                }
                return _verifyInstanceIdRequestFactory;
            }
        }
        #endregion

        #region Get posts by location
        private Func<IJodelRequest<GetPostsResponse>> _getPostsPopularRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsPopularRequestFactory
        {
            get
            {
                if (_getPostsPopularRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/location/popular"); //channel/popular
                    _getPostsPopularRequestFactory = (_getPostsPopularRequestFactory = () => request);
                }
                return _getPostsPopularRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsRecentRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsRecentRequestFactory
        {
            get
            {
                if (_getPostsRecentRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/location/");
                    _getPostsRecentRequestFactory = (_getPostsRecentRequestFactory = () => request);
                }
                return _getPostsRecentRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsDiscussedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsDiscussedRequestFactory
        {
            get
            {
                if (_getPostsDiscussedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/location/discussed");
                    _getPostsDiscussedRequestFactory = (_getPostsDiscussedRequestFactory = () => request);
                }
                return _getPostsDiscussedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsCombinedResponse>> _getPostsCombinedRequestFactory;
        public Func<IJodelRequest<GetPostsCombinedResponse>> GetPostsCombinedRequestFactory
        {
            get
            {
                if (_getPostsCombinedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsCombinedResponse>(User, HttpMethod.Get, "/posts/location/combo", "v3");
                    _getPostsCombinedRequestFactory = (_getPostsCombinedRequestFactory = () => request);
                }
                return _getPostsCombinedRequestFactory;
            }
        }
        #endregion

        #region Get posts by channel
        private Func<IJodelRequest<GetPostsResponse>> _getPostsChannelPopularRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsChannelPopularRequestFactory
        {
            get
            {
                if (_getPostsChannelPopularRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/channel/popular", "v3");
                    _getPostsChannelPopularRequestFactory = (_getPostsChannelPopularRequestFactory = () => request);
                }
                return _getPostsChannelPopularRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsChannelRecentRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsChannelRecentRequestFactory
        {
            get
            {
                if (_getPostsChannelRecentRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/channel/", "v3");
                    _getPostsChannelRecentRequestFactory = (_getPostsChannelRecentRequestFactory = () => request);
                }
                return _getPostsChannelRecentRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsChannelDiscussedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsChannelDiscussedRequestFactory
        {
            get
            {
                if (_getPostsChannelDiscussedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/channel/discussed", "v3");
                    _getPostsChannelDiscussedRequestFactory = (_getPostsChannelDiscussedRequestFactory = () => request);
                }
                return _getPostsChannelDiscussedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsCombinedResponse>> _getPostsChannelCombinedRequestFactory;
        public Func<IJodelRequest<GetPostsCombinedResponse>> GetPostsChannelCombinedRequestFactory
        {
            get
            {
                if (_getPostsChannelCombinedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsCombinedResponse>(User, HttpMethod.Get, "/posts/channel/combo", "v3");
                    _getPostsChannelCombinedRequestFactory = (_getPostsChannelCombinedRequestFactory = () => request);
                }
                return _getPostsChannelCombinedRequestFactory;
            }
        }
        #endregion

        #region Get posts by hashtag
        private Func<IJodelRequest<GetPostsResponse>> _getPostsHashtagPopularRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsHashtagPopularRequestFactory
        {
            get
            {
                if (_getPostsHashtagPopularRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/hashtag/popular", "v3");
                    _getPostsHashtagPopularRequestFactory = (_getPostsChannelPopularRequestFactory = () => request);
                }
                return _getPostsHashtagPopularRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsHashtagRecentRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsHashtagRecentRequestFactory
        {
            get
            {
                if (_getPostsHashtagRecentRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/hashtag/", "v3");
                    _getPostsHashtagRecentRequestFactory = (_getPostsHashtagRecentRequestFactory = () => request);
                }
                return _getPostsHashtagRecentRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsHashtagDiscussedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsHashtagDiscussedRequestFactory
        {
            get
            {
                if (_getPostsHashtagDiscussedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/hashtag/discussed", "v3");
                    _getPostsHashtagDiscussedRequestFactory = (_getPostsHashtagDiscussedRequestFactory = () => request);
                }
                return _getPostsHashtagDiscussedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsCombinedResponse>> _getPostsHashtagCombinedRequestFactory;
        public Func<IJodelRequest<GetPostsCombinedResponse>> GetPostsHashtagCombinedRequestFactory
        {
            get
            {
                if (_getPostsHashtagCombinedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsCombinedResponse>(User, HttpMethod.Get, "/posts/hashtag/combo", "v3");
                    _getPostsHashtagCombinedRequestFactory = (_getPostsHashtagCombinedRequestFactory = () => request);
                }
                return _getPostsHashtagCombinedRequestFactory;
            }
        }
        #endregion

        #region Get own posts
        private Func<IJodelRequest<GetPostsResponse>> _getPostsOwnPopularRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsOwnPopularRequestFactory
        {
            get
            {
                if (_getPostsOwnPopularRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/popular/", "v2");
                    _getPostsOwnPopularRequestFactory = (_getPostsOwnPopularRequestFactory = () => request);
                }
                return _getPostsOwnPopularRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsOwnRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsOwnRequestFactory
        {
            get
            {
                if (_getPostsOwnRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/", "v2");
                    _getPostsOwnRequestFactory = (_getPostsOwnRequestFactory = () => request);
                }
                return _getPostsOwnRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsOwnDiscussedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsOwnDiscussedRequestFactory
        {
            get
            {
                if (_getPostsOwnDiscussedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/discussed", "v2");
                    _getPostsOwnDiscussedRequestFactory = (_getPostsOwnDiscussedRequestFactory = () => request);
                }
                return _getPostsOwnDiscussedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsCombinedResponse>> _getPostsOwnCombinedRequestFactory;
        public Func<IJodelRequest<GetPostsCombinedResponse>> GetPostsOwnCombinedRequestFactory
        {
            get
            {
                if (_getPostsOwnCombinedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsCombinedResponse>(User, HttpMethod.Get, "/posts/mine/combo", "v2");
                    _getPostsOwnCombinedRequestFactory = (_getPostsOwnCombinedRequestFactory = () => request);
                }
                return _getPostsOwnCombinedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsPinnedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsPinnedRequestFactory
        {
            get
            {
                if (_getPostsPinnedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/pinned/", "v2");
                    _getPostsPinnedRequestFactory = (_getPostsPinnedRequestFactory = () => request);
                }
                return _getPostsPinnedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsRepliedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsRepliedRequestFactory
        {
            get
            {
                if (_getPostsRepliedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/replies/", "v2");
                    _getPostsRepliedRequestFactory = (_getPostsRepliedRequestFactory = () => request);
                }
                return _getPostsRepliedRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostsResponse>> _getPostsVotedRequestFactory;
        public Func<IJodelRequest<GetPostsResponse>> GetPostsVotedRequestFactory
        {
            get
            {
                if (_getPostsVotedRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostsResponse>(User, HttpMethod.Get, "/posts/mine/votes/", "v2");
                    _getPostsVotedRequestFactory = (_getPostsVotedRequestFactory = () => request);
                }
                return _getPostsVotedRequestFactory;
            }
        }
        #endregion

        #region User interactions
        private Func<IJodelRequest<bool>> _setLocationRequestFactory;
        public Func<IJodelRequest<bool>> SetLocationRequestFactory
        {
            get
            {
                if (_setLocationRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/users/location");
                    _setLocationRequestFactory = (_setLocationRequestFactory = () => request);
                }
                return _setLocationRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _setHomeTownRequestFactory;
        public Func<IJodelRequest<bool>> SetHomeTownRequestFactory
        {
            get
            {
                if (_setHomeTownRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/user/home");
                    _setHomeTownRequestFactory = (_setHomeTownRequestFactory = () => request);
                }
                return _setHomeTownRequestFactory;
            }
        }

        private Func<IJodelRequest<GetUserConfigResponse>> _getUserConfigRequestFactory;
        public Func<IJodelRequest<GetUserConfigResponse>> GetUserConfigRequestFactory
        {
            get
            {
                if (_getUserConfigRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetUserConfigResponse>(User, HttpMethod.Get, "/user/config", "v3");
                    _getUserConfigRequestFactory = (_getUserConfigRequestFactory = () => request);
                }
                return _getUserConfigRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _deleteUserHomeRequestFactory;
        public Func<IJodelRequest<bool>> DeleteUserHomeRequestFactory
        {
            get
            {
                if (_deleteUserHomeRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Delete, "/user/home", "v3");
                    _deleteUserHomeRequestFactory = (_deleteUserHomeRequestFactory = () => request);
                }
                return _deleteUserHomeRequestFactory;
            }
        }

        private Func<IJodelRequest<GetUserStatsResponse>> _getUserStatsRequestFactory;
        public Func<IJodelRequest<GetUserStatsResponse>> GetUserStatsRequestFactory
        {
            get
            {
                if (_getUserStatsRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetUserStatsResponse>(User, HttpMethod.Get, "/user/stats", "v3");
                    _getUserStatsRequestFactory = (_getUserStatsRequestFactory = () => request);
                }
                return _getUserStatsRequestFactory;
            }
        }
        #endregion

        #region Post interactions
        private Func<IJodelRequest<CreatePostResponse>> _createPostRequestFactory;
        public Func<IJodelRequest<CreatePostResponse>> CreatePostRequestFactory
        {
            get
            {
                if (_createPostRequestFactory == null)
                {
                    var request = new SimplifiedRequest<CreatePostResponse>(User, HttpMethod.Post, "/posts/", "v3");
                    _createPostRequestFactory = (_createPostRequestFactory = () => request);
                }
                return _createPostRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _deletePostRequestFactory;
        public Func<IJodelRequest<bool>> DeletePostRequestFactory
        {
            get
            {
                if (_deletePostRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Delete, "/posts/", "v2");
                    _deletePostRequestFactory = (_deletePostRequestFactory = () => request);
                }
                return _deletePostRequestFactory;
            }
        }

        private Func<IJodelRequest<VotePostResponse>> _votePostRequestFactory;
        public Func<IJodelRequest<VotePostResponse>> VotePostRequestFactory
        {
            get
            {
                if (_votePostRequestFactory == null)
                {
                    var request = new SimplifiedRequest<VotePostResponse>(User, HttpMethod.Put, "/posts/", "v2");
                    _votePostRequestFactory = (_votePostRequestFactory = () => request);
                }
                return _votePostRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _giveThanksRequestFactory;
        public Func<IJodelRequest<bool>> GiveThanksRequestFactory
        {
            get
            {
                if (_giveThanksRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Post, "/posts/", "v3");
                    _giveThanksRequestFactory = (_giveThanksRequestFactory = () => request);
                }
                return _giveThanksRequestFactory;
            }
        }

        private Func<IJodelRequest<GetPostDetailsResponse>> _getPostDetailsRequestFactory;
        public Func<IJodelRequest<GetPostDetailsResponse>> GetPostDetailsRequestFactory
        {
            get
            {
                if (_getPostDetailsRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetPostDetailsResponse>(User, HttpMethod.Get, "/posts/", "v3");
                    _getPostDetailsRequestFactory = (_getPostDetailsRequestFactory = () => request);
                }
                return _getPostDetailsRequestFactory;
            }
        }

        private Func<IJodelRequest<GetSharePostUrlResponse>> _getSharePostUrlRequestFactory;
        public Func<IJodelRequest<GetSharePostUrlResponse>> GetSharePostUrlRequestFactory
        {
            get
            {
                if (_getSharePostUrlRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetSharePostUrlResponse>(User, HttpMethod.Post, "/posts/", "v3");
                    _getSharePostUrlRequestFactory = (_getSharePostUrlRequestFactory = () => request);
                }
                return _getSharePostUrlRequestFactory;
            }
        }

        private Func<IJodelRequest<PinPostResponse>> _pinPostRequestFactory;
        public Func<IJodelRequest<PinPostResponse>> PinPostRequestFactory
        {
            get
            {
                if (_pinPostRequestFactory == null)
                {
                    var request = new SimplifiedRequest<PinPostResponse>(User, HttpMethod.Put, "/posts/", "v2");
                    _pinPostRequestFactory = (_pinPostRequestFactory = () => request);
                }
                return _pinPostRequestFactory;
            }
        }
        #endregion

        #region Channel interactions
        private Func<IJodelRequest<GetRecommendedChannelsResponse>> _getRecommendedChannelsRequestFactory;
        public Func<IJodelRequest<GetRecommendedChannelsResponse>> GetRecommendedChannelsRequestFactory
        {
            get
            {
                if (_getRecommendedChannelsRequestFactory == null)
                {
                    var request = new SimplifiedRequest<GetRecommendedChannelsResponse>(User, HttpMethod.Get, "/user/recommendedChannels", "v3");
                    _getRecommendedChannelsRequestFactory = (_getRecommendedChannelsRequestFactory = () => request);
                }
                return _getRecommendedChannelsRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _followChannelRequestFactory;
        public Func<IJodelRequest<bool>> FollowChannelRequestFactory
        {
            get
            {
                if (_followChannelRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/user/followChannel", "v3");
                    _followChannelRequestFactory = (_followChannelRequestFactory = () => request);
                }
                return _followChannelRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _followChannelsRequestFactory;
        public Func<IJodelRequest<bool>> FollowChannelsRequestFactory
        {
            get
            {
                if (_followChannelsRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/user/followChannels", "v3");
                    _followChannelsRequestFactory = (_followChannelsRequestFactory = () => request);
                }
                return _followChannelsRequestFactory;
            }
        }

        private Func<IJodelRequest<bool>> _unfollowChannelsRequestFactory;
        public Func<IJodelRequest<bool>> UnFollowChannelsRequestFactory
        {
            get
            {
                if (_unfollowChannelsRequestFactory == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Put, "/user/unfollowChannel", "v3");
                    _unfollowChannelsRequestFactory = (_unfollowChannelsRequestFactory = () => request);
                }
                return _unfollowChannelsRequestFactory;
            }
        }
        #endregion

        #region Referer
        private Func<IJodelRequest<GetUserInviteCodeResponse>> _getUserInviteCode;
        public Func<IJodelRequest<GetUserInviteCodeResponse>> GetUserInviteCode
        {
            get
            {
                if (_getUserInviteCode == null)
                {
                    var request = new SimplifiedRequest<GetUserInviteCodeResponse>(User, HttpMethod.Post, "/user/invite", "v3");
                    _getUserInviteCode = (_getUserInviteCode = () => request);
                }
                return _getUserInviteCode;
            }
        }

        private Func<IJodelRequest<bool>> _postInviteComplete;
        public Func<IJodelRequest<bool>> PostInviteComplete
        {
            get
            {
                if (_postInviteComplete == null)
                {
                    var request = new SimplifiedBoolRequest(User, HttpMethod.Post, "/user/invite/complete", "v3");
                    _postInviteComplete = (_postInviteComplete = () => request);
                }
                return _postInviteComplete;
            }
        }

        #endregion

    }
}
