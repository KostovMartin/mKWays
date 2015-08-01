using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxFloat : AjaxTypeGeneric<float>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return float.Parse(data, NumberFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxFloatEnumerable : AjaxTypeEnumerable<IList<float>>, IAjaxParameter {}

    internal class AjaxFloatArray : AjaxTypeEnumerable<float[]>, IAjaxParameter {}
}