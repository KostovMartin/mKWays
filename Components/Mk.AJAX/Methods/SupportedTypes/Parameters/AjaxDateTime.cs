using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxDateTime : AjaxTypeGeneric<DateTime>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return DateTime.Parse(data, DateTimeFormatInfo.InvariantInfo);
        }
    }

    internal class AjaxDateTimeEnumerable : AjaxTypeEnumerable<IList<DateTime>>, IAjaxParameter {}

    internal class AjaxDateTimeArray : AjaxTypeEnumerable<DateTime[]>, IAjaxParameter {}
}