using System.Collections.Generic;

namespace owaincodes.Core.Interfaces
{
    public interface IPagedResults<out T>
    {
        long TotalResults { get; }
        long CurrentPage { get; }
        long PageSize { get; }
        long TotalPages { get; }
        IEnumerable<T> Results { get; }
    }
}
