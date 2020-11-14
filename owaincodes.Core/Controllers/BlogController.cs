using owaincodes.Core.Interfaces;
using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace owaincodes.Core.Controllers
{
    public class BlogController : SurfaceController
    {
        private IBlogSearchService blogSearchService;

        public BlogController(IBlogSearchService blogSearchService) => this.blogSearchService = blogSearchService ?? throw new ArgumentException(nameof(blogSearchService));

        [ChildActionOnly]
        public ActionResult GetBlogsPages(int qty) => (ActionResult)this.PartialView("Blogs/BlogResultsListing", (object)this.blogSearchService.GetBlogPages(qty));

        public ActionResult GetAllBlogsPages(int qty) => (ActionResult)this.PartialView("Blogs/AllBlogResultsListing", (object)this.blogSearchService.GetBlogPages(qty));


        public ActionResult GetOlderBlogsPages(int qty, int skip) => (ActionResult)this.PartialView("Blogs/GetOlderBlogs", (object)this.blogSearchService.GetOlderBlogPages(qty, skip));
    }
}
