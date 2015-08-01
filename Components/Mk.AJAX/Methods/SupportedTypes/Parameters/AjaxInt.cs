using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxInt : AjaxTypeGeneric<int>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return int.Parse(data, NumberFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxIntEnumerable : AjaxTypeEnumerable<IList<int>>, IAjaxParameter {}

    internal class AjaxIntArray : AjaxTypeEnumerable<int[]>, IAjaxParameter {}
}