using owaincodes.Core.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace owaincodes.Core.Component
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class CreateDateFoldersComposer : ComponentComposer<CreateDateContentFolderComponent>
    {
    }

  
}
