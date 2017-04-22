﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mastodon.API
{
    public interface IMastodonApi
    {
        /// <summary>
        /// Returns an Account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Account> GetAccount(string id, CancellationToken? token = null);

        /// <summary>
        /// Returns the authenticated user's Account.
        /// </summary>
        /// <returns>The current account.</returns>
        /// <param name="token">Token.</param>
        Task<Account> GetCurrentAccount(CancellationToken? token = null);

        /// <summary>
        /// Getting an account's followers.
        /// </summary>
        /// <returns>The followers.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowers(string id, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's following.
        /// </summary>
        /// <returns>The follwing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>      
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowing(string id, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's statuses.
        /// </summary>
        /// <returns>The status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetStatuses(string id, bool isOnlyMedia = false, bool isExcludeReplies = false, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Following an account:
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Follow(string id, CancellationToken? token = null);

        /// <summary>
        /// Unfollowing an account:
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unfollow(string id, CancellationToken? token = null);

        /// <summary>
        /// Blocking an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Block(string id, CancellationToken? token = null);


        /// <summary>
        /// Unblocking an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unblock(string id, CancellationToken? token = null);

        /// <summary>
        /// Mute an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Mute(string id, CancellationToken? token = null);

        /// <summary>
        /// Unmute an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unmute(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's relationship.
        /// </summary>
        /// <returns>The relationships</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> GetRelationship(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's relationships
        /// </summary>
        /// <returns>The relationships.</returns>
        /// <param name="ids">Identifiers.</param>
        /// <param name="token">Token.</param>
        Task<Relationship[]> GetRelationships(string[] ids, CancellationToken? token = null);

        /// <summary>
        /// Searching for accounts.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="query">Query.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> SearchAccounts(string query, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's blocks.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetBlocks(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's favourites.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetFavourites(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a list of follow requests.
        /// </summary>
        /// <returns>The follow requests.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowRequests(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Authorizing follow requests.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task AuthorizeFollowRequests(string id, CancellationToken? token = null);

        /// <summary>
        /// Rejecting follow requests.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task RejectFollowRequests(string id, CancellationToken? token = null);

        /// <summary>
        /// Following a remote user.
        /// </summary>
        /// <returns>The local representation of the followed account, as an Account.</returns>
        /// <param name="uri">URI.</param>
        /// <param name="token">Token.</param>
        Task<Account> FollowRemoteUser(string uri, CancellationToken? token = null);

        /// <summary>
        /// Getting instance information.
        /// </summary>
        /// <returns>The current Instance.</returns>
        /// <param name="token">Token.</param>
        Task<Instance> GetInstance(CancellationToken? token = null);

        /// <summary>
        /// Uploading a media attachment.
        /// </summary>
        /// <returns>An Attachment that can be used when creating a status.</returns>
        /// <param name="base64EncodedMedia">Base64 encoded media.</param>
        /// <param name="token">Token.</param>
        Task<Attachment> Upload(string base64EncodedMedia, CancellationToken? token = null);
    }
}
