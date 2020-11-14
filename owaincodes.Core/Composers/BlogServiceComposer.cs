
using owaincodes.Core.Interfaces;
using owaincodes.Core.Services;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace owaincodes.Core.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class BlogServiceComposer : IUserComposer, IComposer, IDiscoverable
    {
        public void Compose(Composition composition) => composition.Register<IBlogSearchService, BlogSearchService>(Lifetime.Request);
    }
}
