using owaincodes.Core.Models;
using Newtonsoft.Json;

namespace owaincodes.Core.Blogs.Models
{
    public class BlogPageFilterModel : PageFilterModel
    {
        [JsonProperty("q")]
        public string Keyword { get; set; }
        [JsonProperty("a")]
        public override string Author { get; set; }
        [JsonProperty("r")]
        public int Rating { get; set; }
    }
}
