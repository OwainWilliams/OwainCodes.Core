namespace owaincodes.Core.Models
{
    public class PaginationDetails
    {
        public long CurrentPage { get; set; }
        public int CurrentPageQty { get; set; }
        public long PageSize { get; set; }
        public int LastPage { get; set; }
        public long TotalResults { get; set; }

        public string ItemType { get; set; }
    }
}

