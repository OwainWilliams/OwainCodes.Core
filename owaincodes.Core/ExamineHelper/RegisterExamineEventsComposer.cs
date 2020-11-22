using owaincodes.Core.ExamineHelper;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace CAS.Core.ExamineHelper
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class RegisterExamineEventsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<IndexerComponent>();
        }
    }
}