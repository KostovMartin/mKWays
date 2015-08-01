using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxShort : AjaxTypeGeneric<short>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return short.Parse(data, NumberFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxShortEnumerable : AjaxTypeEnumerable<IList<short>>, IAjaxParameter {}

    internal class AjaxShortArray : AjaxTypeEnumerable<short[]>, IAjaxParameter {}
}