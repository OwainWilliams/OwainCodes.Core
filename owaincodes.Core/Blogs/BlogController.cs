using owaincodes.Core.Blogs.Models;
using owaincodes.Core.Interfaces;
using owaincodes.Core.Models;
using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace owaincodes.Core.Controllers
{
    public class BlogController : SurfaceController
    {
        private IBlogSearchService blogSearchService;

        
        public BlogController(IBlogSearchService blogSearchService)
        {
            this.blogSearchService = blogSearchService ?? throw new ArgumentException(nameof(blogSearchService));
        }




        [ChildActionOnly]
        public ActionResult GetInitialBlogResults(PaginationDetails model)
        {
           
            var returnModel = blogSearchService.GetPagedBlogFeed(model);

            return PartialView("Blogs/AllBlogResultsListing", returnModel);
        }

        



    public ActionResult GetHomePageBlogResults(PaginationDetails model)
        {
           

            var returnModel = blogSearchService.GetPagedBlogFeed(model);
            return PartialView("Blogs/BlogResultsListing", returnModel);
        }

        [HttpPost]
        public ActionResult GetPageBlogResults(PaginationDetails model)
        {


            var returnModel = blogSearchService.GetPagedBlogFeed(model);
            return PartialView("Blogs/AllBlogResultsListing", returnModel);
        }

        // public ActionResult GetBlogsPages(int qty) => (ActionResult)this.PartialView("Blogs/BlogResultsListing", (object)this.blogSearchService.GetBlogPages(qty));


        //  public ActionResult GetAllBlogsPages(int qty) => (ActionResult)this.PartialView("Blogs/AllBlogResultsListing", (object)this.blogSearchService.GetBlogPages(qty));


        public ActionResult GetOlderBlogsPages(int qty, int skip) => (ActionResult)this.PartialView("Blogs/GetOlderBlogs", (object)this.blogSearchService.GetOlderBlogPages(qty, skip));

        private BlogPageFilterModel ValidateModel (BlogPageFilterModel model)
        {
            if (model == null)
                return new BlogPageFilterModel
                {
                    Page = 1,
                    PageSize = 10,
                    Filters = new Core.Models.FilterModels.FilterModel()
                };
            else
            {
                if (model.Page <= 0)
                    model.Page = 1;
                if (model.PageSize <= 0)
                    model.PageSize = 1;
            }
            return model;
        }

    }
}

