using System.Collections.Generic;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxBool : AjaxTypeGeneric<bool>, IAjaxParameter
    {
        public object Parse(string data)
        {
            return bool.Parse(data);
        }
    }

    internal class AjaxBoolEnumerable : AjaxTypeEnumerable<IList<bool>>, IAjaxParameter {}

    internal class AjaxBoolArray : AjaxTypeEnumerable<bool[]>, IAjaxParameter {}
}