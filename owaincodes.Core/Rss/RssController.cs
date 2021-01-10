using owaincodes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace owaincodes.Core.Rss
{
    public class RssController : SurfaceController
    {

        private IBlogSearchService blogSearchService;


        public RssController(IBlogSearchService blogSearchService)
        {
            this.blogSearchService = blogSearchService ?? throw new ArgumentException(nameof(blogSearchService));
        }



        [ChildActionOnly]
        public ActionResult RssFeed(BlogPage model)
        {
            
           var rssResultsFromExamine = blogSearchService.GetAllBlogs();
           
          
            return PartialView("Rss/RssXmlFeed", rssResultsFromExamine);
        }
    }
}
