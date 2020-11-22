using owaincodes.Core.Models.FilterModels;
using System.Collections.Generic;

namespace owaincodes.Core.Models
{
    public class PageFilterModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public FilterModel Filters { get; set; }

        public string SearchTerm { get; set; }
        public virtual string Author { get; set; }
    }
    public class DownloadsPageFilterModel : PageFilterModel
    {
        public List<string> DownloadTypes { get; set; }
    }
}
