using System.Collections.Generic;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxString : AjaxTypeGeneric<string>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return data;
        }
    }

    internal class AjaxStringEnumerable : AjaxTypeEnumerable<IList<string>>, IAjaxParameter {}

    internal class AjaxStringArray : AjaxTypeEnumerable<string[]>, IAjaxParameter {}
}