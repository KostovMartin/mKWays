using System;
using Mk.AJAX.Methods.SupportedTypes.Results;

namespace Mk.AJAX.Methods.SupportedTypes.Factories
{
    internal class ResultsFactory : TypesFactory<IAjaxResult>
    {
        private readonly IAjaxResult _ajaxResultDefault;

        public ResultsFactory(IMkJson json) : base(json)
        {
            this._ajaxResultDefault = new AjaxResultDefault {Json = json};
        }

        public string Parse(Type type, object result)
        {
            if (result == null)
            {
                return string.Empty;
            }

            IAjaxResult resultType;
            if (this.TryGetType(type, out resultType))
            {
                return resultType.Parse(result);
            }

            return this._ajaxResultDefault.Parse(result);
        }
    }
}