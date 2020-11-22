using owaincodes.Core.Interfaces;
using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace owaincodes.Core.Models
{
    public class PagedResults<T> : IPagedResults<T> where T : IPublishedContent
    {
        public long TotalResults { get; }
        public long CurrentPage { get; }
        public long PageSize { get; }

        public IEnumerable<T> Results { get; set; }

        public PagedResults(long currentPage, long pageSize, long totalResults)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalResults = totalResults;
            Results = new List<T>();
        }

        public long TotalPages
        {
            get
            {
                if (TotalResults <= 0) return 0;
                if (PageSize <= 0) return 1;

                return Convert.ToInt64(Math.Ceiling(TotalResults / Convert.ToDecimal(PageSize)));
            }
        }
    }
}
