using Umbraco.Core.Models.PublishedContent;

namespace owaincodes.Core.Models.FilterModels
{
    public class FilterItemViewModel
    {
        public string OverrideFilterName { get; set; }
        public string GroupName { get; set; }
        public IPublishedContent Item { get; set; }
        public int GroupIndex { get; set; }
        public int OptionIndex { get; set; }

        public bool IsSelected { get; set; }

        public string AlternativeValue { get; set; }
    }
}
