using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxLong : AjaxTypeGeneric<long>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return long.Parse(data, NumberFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxLongEnumerable : AjaxTypeEnumerable<IList<long>>, IAjaxParameter {}

    internal class AjaxLongArray : AjaxTypeEnumerable<long[]>, IAjaxParameter {}
}