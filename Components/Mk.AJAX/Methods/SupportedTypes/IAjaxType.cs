using System;

namespace Mk.AJAX.Methods.SupportedTypes
{
    internal interface IAjaxType
    {
        Type SupportedType { get; }
        string SupportedTypeName { get; }
        IMkJson Json { get; set; }
    }
}