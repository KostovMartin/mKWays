using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxDouble : AjaxTypeGeneric<double>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return double.Parse(data, NumberFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxDoubleEnumerable : AjaxTypeEnumerable<IList<double>>, IAjaxParameter { }

    internal class AjaxDoubleArray : AjaxTypeEnumerable<double[]>, IAjaxParameter { }
}