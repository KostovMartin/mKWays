using System;

namespace Mk.AJAX.Methods.SupportedTypes.Results
{
    internal class AjaxResultDefault : AjaxType, IAjaxResult
    {
        public override Type SupportedType
        {
            get { return null; }
        }

        public string Parse(object result)
        {
            return this.Json.Serialize(result);
        }
    }
}