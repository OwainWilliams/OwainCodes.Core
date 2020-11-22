using System.Collections.Generic;

namespace owaincodes.Core.Models.FilterModels
{
    public class FilterModel : Dictionary<string, string[]>
    {
    }

    public class FilterModel<T> : Dictionary<string, T[]>
    {
    }

    public class TieredDictionaryModel<T> : Dictionary<string, Dictionary<string, T[]>>
    {

    }
}
