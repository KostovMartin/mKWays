namespace Mk.AJAX.Methods.SupportedTypes.Results
{
    internal class AjaxResultString : AjaxTypeGeneric<string>, IAjaxResult
    {
        public string Parse(object result)
        {
            return result.ToString();
        }
    }
}