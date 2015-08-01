namespace Mk.AJAX.Methods.SupportedTypes
{
    internal interface IAjaxParameter : IAjaxType
    {
        object Parse(string data);
    }
}