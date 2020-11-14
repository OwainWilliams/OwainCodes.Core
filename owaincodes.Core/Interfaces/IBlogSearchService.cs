using System.Collections.Generic;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.Interfaces
{
    public interface IBlogSearchService
    {
        IEnumerable<BlogPage> GetBlogPages(int qty);

        IEnumerable<BlogPage> GetOlderBlogPages(int qty, int skip);
    }
}
