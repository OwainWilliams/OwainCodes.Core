using owaincodes.Core.Blogs.Models;
using owaincodes.Core.Models;
using System.Collections.Generic;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.Interfaces
{
    public interface IBlogSearchService
    {
        PagedResults<BlogPage> GetPagedBlogFeed(BlogPageFilterModel pageFilterModel);

        IEnumerable<BlogPage> GetOlderBlogPages(int qty, int skip);
    }
}
