namespace Mk.AJAX.Methods.SupportedTypes
{
    internal interface IAjaxResult : IAjaxType
    {
        string Parse(object data);
    }
}