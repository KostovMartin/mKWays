using System;

namespace Mk.AJAX.Methods.SupportedTypes.Results
{
    internal class AjaxResultVoid : AjaxType, IAjaxResult
    {
        public override Type SupportedType
        {
            get { return typeof (void); }
        }

        public string Parse(object result)
        {
            return string.Empty;
        }
    }
}