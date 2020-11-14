
using Examine;
using Examine.Search;
using owaincodes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Logging;
using Umbraco.Examine;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.Services
{
    public class BlogSearchService : IBlogSearchService
    {
        private readonly ILogger logger;
        private readonly UmbracoHelper umbracoHelper;
        private readonly IIndex index;
        private readonly ISearcher searcher;

        public BlogSearchService(ILogger logger, UmbracoHelper helper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.umbracoHelper = helper ?? throw new ArgumentNullException(nameof(logger));
            if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out this.index))
                this.searcher = this.index.GetSearcher();
            if (this.index == null)
                throw new NullReferenceException("Unable to retrieve external index for blog search service");
            if (this.searcher == null)
                throw new NullReferenceException("Unable to retrieve external search for blog search service");
        }

        public IEnumerable<BlogPage> GetBlogPages(int qty)
        {
            try
            {
              //  return this.umbracoHelper.Content(this.searcher.CreateQuery().NodeTypeAlias("blogPage").OrderByDescending(new SortableField("sortOrder", SortType.Int)).Execute().Take<ISearchResult>(qty).Select<ISearchResult, string>((Func<ISearchResult, string>)(r => r.Id))).OfType<BlogPage>();
                return this.umbracoHelper.Content(this.searcher.CreateQuery()
                    .NodeTypeAlias("blogPage")
                    .OrderBy(new SortableField("publishedDate", SortType.String))
                    .Execute()
                    .Take<ISearchResult>(qty)
                    .Select<ISearchResult, string>((Func<ISearchResult, string>)(r => r.Id)))
                    .OfType<BlogPage>();
            }
            catch (Exception ex)
            {
                this.logger.Error(this.GetType(), ex, "Error getting latest blogs");
            }
            return (IEnumerable<BlogPage>)new List<BlogPage>();
        }

        public IEnumerable<BlogPage> GetOlderBlogPages(int qty, int skip)
        {
            try
            {
                // return this.umbracoHelper.Content(this.searcher.CreateQuery().NodeTypeAlias("blogPage").OrderByDescending(new SortableField("sortOrder", SortType.Int)).Execute().Take<ISearchResult>(qty).Select<ISearchResult, string>((Func<ISearchResult, string>)(r => r.Id))).OfType<BlogPage>();
                return this.umbracoHelper.Content(this.searcher.CreateQuery().NodeTypeAlias("blogPage").OrderBy(new SortableField("publishedDate", SortType.String)).Execute().Skip<ISearchResult>(skip).Take<ISearchResult>(qty).Select<ISearchResult, string>((Func<ISearchResult, string>)(r => r.Id))).OfType<BlogPage>();
            }
            catch (Exception ex)
            {
                this.logger.Error(this.GetType(), ex, "Error getting latest blogs");
            }
            return (IEnumerable<BlogPage>)new List<BlogPage>();
        }
    }
}
