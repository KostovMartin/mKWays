using System;

namespace Mk.AJAX.Methods.SupportedTypes.Parameters
{
    internal class AjaxUserDefined : AjaxType, IAjaxParameter
    {
        private readonly Type _type;
        public AjaxUserDefined() {}

        public AjaxUserDefined(Type type)
        {
            this._type = type;
        }

        public override Type SupportedType
        {
            get { return this._type; }
        }

        public object Parse(string data)
        {
            return this.Json.Deserialize(data, this.SupportedType);
        }
    }
}