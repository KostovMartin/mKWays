using System;

namespace Mk.AJAX.Methods.SupportedTypes
{
    internal abstract class AjaxTypeGeneric<TSupportedType> : AjaxType
    {
        public override sealed Type SupportedType
        {
            get { return typeof (TSupportedType); }
        }
    }
}