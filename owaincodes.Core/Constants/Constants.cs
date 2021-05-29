namespace owaincodes.Core
{
    public static partial class Constants
    {
        public const string Site = "owaincodes";
        internal const string NodeName = "nodeName";
        internal const string CustomSort = "customOrder";
        internal const string Sort = "sortOrder";
        internal const string Parent = "parentKey";
        internal const string DateUpdated = "lastUpdated";
        internal const string Cleaned = "Cleaned";
        internal const string Sortable = "Sortable";
        internal const string Space = " ";
        internal const string FriendlyPath = "FriendlyPath";

        
        internal const string CreateDateTicks = "createDateTicks";
        internal const string DateUpdatedTicks = "lastUpdatedTicks";

        public const string DefaultHoneyPotName = "bhp";

        public static partial class CommonFields
        {
            internal const string PageTitle = "pageTitle";
            internal const string Categories = "categories";
            internal static string CategoriesExamineField { get { return Categories + Cleaned; } }
        }

        internal static class Blogs
        {
            internal const string BlogDate = "publishedDate";
            internal static string BlogDateSortableExamineField { get { return BlogDate + Sortable; } }
            internal const string Categories = "categories";
            internal static string CategoriesExamineField { get { return Categories + Cleaned; } }
            internal const string PageTitle = CommonFields.PageTitle;
        }

     

    }
    

}