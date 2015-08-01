using System;

namespace Mk.AJAX.Methods.SupportedTypes
{
    internal abstract class AjaxType : IAjaxType
    {
        public abstract Type SupportedType { get; }

        public string SupportedTypeName
        {
            get { return this.SupportedType != null ? this.SupportedType.Name.ToLower() : string.Empty; }
        }

        public IMkJson Json { get; set; }
    }
}