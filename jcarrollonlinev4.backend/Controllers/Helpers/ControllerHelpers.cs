using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Models.ForumThreadEntries;
using jcarrollonlinev4.backend.Models.Rss;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;

namespace JCarrollOnlineV2.Controllers.Helpers
{
    public static class ControllerHelpers
    {
        //private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static async Task<int> GetThreadPostCountAsync(int thread, IJCarrollOnlineDbContext data)
        {
            return data == null
                ? throw new ArgumentNullException(nameof(data))
                : await data.ForumThreadEntry.Where(i => i.RootId == thread).AsQueryable().CountAsync().ConfigureAwait(false);
        }

        public static async Task<int> GetThreadCountAsync(Forum forum, JCarrollOnlineV4DbContext data)
        {
            return data == null
                ? throw new ArgumentNullException(nameof(data))
                : await data.ForumThreadEntry.Where(i => i.Forum.Id == forum.Id && i.ParentId == null).CountAsync().ConfigureAwait(false);
        }

        public static async Task<DateTime> GetLastReplyAsync(int? rootId, IJCarrollOnlineDbContext data)
        {
            if (rootId != null)
            {
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                ForumThreadEntry? fte = await data.ForumThreadEntry.Where(m => m.RootId == rootId).OrderByDescending(m => m.UpdatedAt).FirstOrDefaultAsync().ConfigureAwait(false);
                return fte.UpdatedAt;
            }
            else
            {
                return DateTime.Now;
            }
        }

        public static async Task<LastThreadModel> GetLatestThreadDataAsync(Forum forum, JCarrollOnlineV4DbContext data)
        {
            LastThreadModel lastThreadViewModel = new LastThreadModel();

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ForumThreadEntry? forumThreadEntry = await data.ForumThreadEntry.Where(i => i.Forum.Id == forum.Id)
                .Include(i => i.Author)
                .OrderByDescending(i => i.UpdatedAt)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (forumThreadEntry != null)
            {
                lastThreadViewModel.InjectFrom(forumThreadEntry);
                //lastThreadViewModel.Author = new ApplicationUserViewModel();
                //lastThreadViewModel.Author.InjectFrom(forumThreadEntry.Author);
                //lastThreadViewModel.Forum = new ForaModel();
                //lastThreadViewModel.Forum.InjectFrom(forumThreadEntry.Forum);

                bool rootNotFound = true;

                if (forumThreadEntry.ParentId != null)
                {
                    while (rootNotFound)
                    {
                        //forumThreadEntry = await data.ForumThreadEntry.FindAsync(forumThreadEntry.ParentId).ConfigureAwait(false);
                        if (forumThreadEntry != null)
                        {
                            if (forumThreadEntry.ParentId == null)
                            {
                                rootNotFound = false;
                            }
                        }
                    }
                }

                //lastThreadViewModel.PostRoot = forumThreadEntry.Id;

                return lastThreadViewModel;
            }

            return null;
        }

        public static async Task<RssFeedModel> UpdateRssAsync()
        {
            //_logger.Info("Obtaining rss data");
            Uri mlbUri = new Uri("https://www.mlb.com/mariners/feeds/news/rss.xml");
            //TNX.RssReader.RssFeed rssFeed = await TNX.RssReader.RssHelper.ReadFeedAsync(mlbUri).ConfigureAwait(false);

            //_logger.Info("Processing rss data");
            RssFeedModel rssFeedModel = new RssFeedModel
            {
                RssFeedItems = new List<RssFeedItemModel>()
            };

            //foreach (TNX.RssReader.RssItem item in rssFeed.Items)
            //{
            //    if (!string.IsNullOrWhiteSpace(item.Link))
            //    {
            //        RssFeedItemViewModel rss = new RssFeedItemViewModel();

            //        rss.InjectFrom(item);
            //        rss.Link = new Uri(item.Link);
            //        rss.UpdatedAt = DateTime.Now;
            //        rssFeedViewModel.RssFeedItems.Add(rss);
            //    }
            //}

            //_logger.Info(string.Format(CultureInfo.InvariantCulture, "Processed {0} rss records", rssFeedViewModel.RssFeedItems.Count));

            return rssFeedModel;
        }
    }
}