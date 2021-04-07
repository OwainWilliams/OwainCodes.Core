
using Examine;
using Examine.Search;
using owaincodes.Core.Blogs.Models;
using owaincodes.Core.Interfaces;
using owaincodes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Scoping;
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
        private readonly IExamineManager examineManager;
        private readonly IScopeProvider scopeProvider;
        private readonly IUmbracoContextFactory umbracoContextFactory;

        public BlogSearchService(ILogger logger, UmbracoHelper helper, IExamineManager examineManager, IScopeProvider scopeProvider, IUmbracoContextFactory umbracoContextFactory)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.umbracoHelper = helper ?? throw new ArgumentNullException(nameof(logger));
            if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out this.index))
                this.searcher = this.index.GetSearcher();
            if (this.index == null)
                throw new NullReferenceException("Unable to retrieve external index for blog search service");
            if (this.searcher == null)
                throw new NullReferenceException("Unable to retrieve external search for blog search service");

            this.examineManager = examineManager ?? throw new ArgumentNullException(nameof(examineManager));
            this.scopeProvider = scopeProvider ?? throw new ArgumentNullException(nameof(scopeProvider));
            this.umbracoContextFactory = umbracoContextFactory ?? throw new ArgumentNullException(nameof(umbracoContextFactory));
        }

      

        public PagedResults<BlogPage> GetPagedBlogFeed(PaginationDetails pageFilterModel)
        {

            try
            {

                if (examineManager.TryGetIndex(Umbraco.Core.Constants.UmbracoIndexes.ExternalIndexName, out var index))
                {
                    var searcher = index.GetSearcher();

                    if (pageFilterModel is null)
                    {
                        throw new ArgumentException(nameof(pageFilterModel));
                    }

                    if (pageFilterModel.CurrentPage < 1) pageFilterModel.CurrentPage = 1;
                    if (pageFilterModel.PageSize < 1) pageFilterModel.PageSize = 1;


                    ISearchResults results = SearchForBlogs(searcher);
                    return ProcessSearchResults<BlogPage>((int)pageFilterModel.CurrentPage, (int)pageFilterModel.PageSize, results);

                }

            }
            catch (Exception ex)
            {
                logger.Error(GetType(), ex, "Error getting Posts - {{page}", pageFilterModel.CurrentPage);
            }

            return new PagedResults<BlogPage>(-1, -1, -1)
            {
                Results = Enumerable.Empty<BlogPage>()
            };

        }

       

        private PagedResults<T> ProcessSearchResults<T>(int page, int pageSize, ISearchResults results) where T : IPublishedContent
        {

            // results has the missing blog - id 1153

            if (page * pageSize > results.TotalItemCount)
            {
                page = CalculateFinalPage(pageSize, results.TotalItemCount);
            }

            var pageResults = page > 1 ?
                 results.Skip((page - 1) * pageSize).Take(pageSize) : results.Take(pageSize);


            //var pageResults = results.TotalItemCount > 0 ? results.Skip((page - 1) * pageSize).Take(pageSize) : Enumerable.Empty<ISearchResult>();

            var returnModel = new PagedResults<T>(page, pageSize, Convert.ToInt32(results.TotalItemCount));

            using (var scope = scopeProvider.CreateScope())
            {
                using (var umbracoContext = umbracoContextFactory.EnsureUmbracoContext())
                {
                    returnModel.Results = results.Count() > 0 ? pageResults.Select(r => umbracoContext.UmbracoContext.Content.GetById(int.Parse(r.Id)))
                        .OfType<T>().ToList()
                    : Enumerable.Empty<T>();


                    scope.Complete();
                    return returnModel;

                }

            }

        }

    

        private int CalculateFinalPage(int pageSize, long totalItemCount)
        {
            return Convert.ToInt32(Math.Ceiling(totalItemCount / Convert.ToDecimal(pageSize)));
        }

        public IEnumerable<BlogPage> GetOlderBlogPages(int qty, int skip)
        {
            try
            {
                // return this.umbracoHelper.Content(this.searcher.CreateQuery().NodeTypeAlias("blogPage").OrderByDescending(new SortableField("sortOrder", SortType.Int)).Execute().Take<ISearchResult>(qty).Select<ISearchResult, string>((Func<ISearchResult, string>)(r => r.Id))).OfType<BlogPage>();
                return this.umbracoHelper.Content(this.searcher.CreateQuery()
                    .NodeTypeAlias("blogPage")
                    .OrderByDescending(new SortableField(Constants.Blogs.BlogDateSortableExamineField, SortType.Long))
                    .Execute()
                    .Skip<ISearchResult>(skip)
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


        private ISearchResults SearchForBlogs(ISearcher searcher)
        {
            var query = searcher.CreateQuery().NodeTypeAlias(BlogPage.ModelTypeAlias);

            query = query.And().RangeQuery<long>(new[] { Constants.Blogs.BlogDateSortableExamineField }, 0, DateTime.Now.Ticks, maxInclusive: true);

           
            var results = query.OrderByDescending(new SortableField(Constants.Blogs.BlogDateSortableExamineField, SortType.Long))
                    .Execute();
            return results;
        }


        private IEnumerable<T> ProcessRssResults<T>(ISearchResults results) where T : IPublishedContent
        {
            
           
            using (var scope = scopeProvider.CreateScope())
            {
                using (var umbracoContext = umbracoContextFactory.EnsureUmbracoContext())
                {
                    IEnumerable<T> resultOfRss = results.Any() ? results.Select(r => umbracoContext.UmbracoContext.Content.GetById(int.Parse(r.Id)))
                        .OfType<T>().ToList()
                    : Enumerable.Empty<T>();


                    scope.Complete();
                    return resultOfRss;

                }

            }

        }


        public IEnumerable<BlogPage> GetAllBlogs()
        {
            ISearchResults blogSearchResults = SearchForBlogs(searcher);
            IEnumerable<BlogPage> rssResults = ProcessRssResults<BlogPage>(blogSearchResults);

            return rssResults;
        }
    }
}
