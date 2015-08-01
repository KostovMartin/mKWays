namespace Mk.AJAX.Methods.SupportedTypes
{
    internal class AjaxTypeEnumerable<TSupportedType> : AjaxTypeGeneric<TSupportedType>
    {
        public object Parse(string data)
        {
            return this.Json.Deserialize(data, this.SupportedType);
        }
    }
}