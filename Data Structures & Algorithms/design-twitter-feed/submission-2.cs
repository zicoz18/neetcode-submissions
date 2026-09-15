public class Twitter {
    private const int FEED_LIMIT_COUNT = 10;
    private const int INVALID_COUNTER = -1;
    private int globalCounter = 0;

    private struct Tweet {
        public int id;
        public int userId;
        public int counter;
    }
    Dictionary<int, List<Tweet>> userToPosts;
    Dictionary<int, List<Tweet>> userToFeed;
    Dictionary<int, List<int>> userToFollowersList;

    public Twitter() {
        userToPosts = new Dictionary<int, List<Tweet>>();
        userToFeed = new Dictionary<int, List<Tweet>>();
        userToFollowersList = new Dictionary<int, List<int>>();
    }

    private Tweet CreateNewTweet(int tweetId, int userId) {
        Tweet newTweet = new Tweet{id = tweetId, userId = userId, counter = globalCounter};
        globalCounter++;
        return newTweet;
    }

    private Tweet MockCreateInvalidTweet() {
        return new Tweet{id = INVALID_COUNTER, userId = INVALID_COUNTER, counter = INVALID_COUNTER};
    }

    private bool IsValidTweet(Tweet tweet) {
        return tweet.counter != INVALID_COUNTER;
    }

    private List<Tweet> GetUserPosts(int userId) {
        List<Tweet> posts;
        if (!userToPosts.TryGetValue(userId, out posts)) {
            userToPosts[userId] = new List<Tweet>();
            posts = userToPosts[userId];
        }
        return posts;
    }

    private List<Tweet> GetUserFeed(int userId) {
        List<Tweet> feed;
        if (!userToFeed.TryGetValue(userId, out feed)) {
            userToFeed[userId] = new List<Tweet>();
            feed = userToFeed[userId];
        }
        return feed;
    }

    private void SetUserFeed(int userId, List<Tweet> userFeed) {
        userToFeed[userId] = userFeed;
    }

    private List<int> GetUsersFollowers(int userId) {
        List<int> followerUserIds;
        if (!userToFollowersList.TryGetValue(userId, out followerUserIds)) {
            userToFollowersList[userId] = new List<int>();
            followerUserIds = userToFollowersList[userId];
        }
        return followerUserIds;
    } 

    public void PostTweet(int userId, int tweetId) {
        Tweet newTweet = CreateNewTweet(tweetId, userId);
        // Update user's posts
        List<Tweet> posts = GetUserPosts(userId);
        posts.Add(newTweet);
        // Update user's         
        List<Tweet> feed = GetUserFeed(userId);
        feed.Add(newTweet);
        // Get followers of this user
        List<int> followerUserIds = GetUsersFollowers(userId);
        // For each follower, get their feed and add this new tweet to their feed
        foreach (int followerId in followerUserIds) {
            List<Tweet> followersFeed = GetUserFeed(followerId);
            followersFeed.Add(newTweet);
        }
    }
    
    public List<int> GetNewsFeed(int userId) {
        // Get Feed
        List<Tweet> feed = GetUserFeed(userId);
        // Simplify the feed by converting it into only tweet ids and getting the latest FEED_LIMIT_COUNT tweets
        List<int> tweetIdFeed = feed.TakeLast(FEED_LIMIT_COUNT).Select(t => t.id).Reverse().ToList();
        return tweetIdFeed;
    }

    public void Follow(int followerId, int followeeId) {
        // Register follower's user id to the followed user's follower list
        List<int> followingUserIds = GetUsersFollowers(followeeId);
        followingUserIds.Add(followerId);
        // Update following user's feed by merging it with followed user's posts
        SetUserFeed(followerId, AddUserPostsToUserFeed(followeeId, followerId));
    }

    private List<Tweet> AddUserPostsToUserFeed(int userIdForPosts, int userIdForFeed) {
        List<Tweet> userFeed = GetUserFeed(userIdForFeed);
        List<Tweet> userPosts = GetUserPosts(userIdForPosts);
        // Console.WriteLine("Will merge feed and posts. Feed len: " + userFeed.Count + ", Post len: " + userPosts.Count);

        
        // TODO: We have 2 lists, which are both in order in themselfs, what we should do is, merge it so that its still in order
        int feedPointer = 0;
        int postPointer = 0;
        List<Tweet> mergedFeed = new List<Tweet>();
        HashSet<int> includedTweetIds = new HashSet<int>();
        while (feedPointer != userFeed.Count || postPointer != userPosts.Count) {
            Tweet feed = MockCreateInvalidTweet();
            if (feedPointer != userFeed.Count) {
                feed = userFeed[feedPointer];
            }
            Tweet post = MockCreateInvalidTweet();
            if (postPointer != userPosts.Count) {
                post = userPosts[postPointer];
            }
            if (IsValidTweet(post) && IsValidTweet(feed)) {
                if (post.counter < feed.counter) {
                    if (includedTweetIds.Add(post.id)) {
                        mergedFeed.Add(post);
                        postPointer++;
                    } else {
                        postPointer++;
                    }
                } else {
                    if (includedTweetIds.Add(feed.id)) {
                        mergedFeed.Add(feed);
                        feedPointer++;
                    } else {
                        feedPointer++;
                    }
                }
            } else if (IsValidTweet(post)) {
                if (includedTweetIds.Add(post.id)) {
                    mergedFeed.Add(post);
                    postPointer++;
                } else {
                    postPointer++;
                }
            } else if (IsValidTweet(feed)) {
                if (includedTweetIds.Add(feed.id)) {
                    mergedFeed.Add(feed);
                    feedPointer++;
                } else {
                    feedPointer++;
                }
            }
        }
        // Console.WriteLine("After following, merged feed's count: " + mergedFeed.Count);
        return mergedFeed;
    }
    
    public void Unfollow(int followerId, int followeeId) {
        // Remove followerId from followeId's followersList
        List<int> followerList = GetUsersFollowers(followeeId);
        followerList.Remove(followerId);
        // Update followerId's feed by removing any tweet with userId == followeeId
        SetUserFeed(followerId, RemoveUserPostsFromUserFeed(followeeId, followerId));
    }

    private List<Tweet> RemoveUserPostsFromUserFeed(int userIdForPosts, int userIdForFeed) {
        List<Tweet> userFeed = GetUserFeed(userIdForFeed);
        List<Tweet> removedFeed = new List<Tweet>();
        foreach (Tweet t in userFeed) {
            if (t.userId != userIdForPosts) {
                removedFeed.Add(t);
            }
        }
        return removedFeed;
    }
}
