using System;
using System.Collections.Generic;
using Mk.AJAX.Methods.SupportedTypes.Parameters;

namespace Mk.AJAX.Methods.SupportedTypes.Factories
{
    internal class ParametersFactory : TypesFactory<IAjaxParameter>
    {
        public ParametersFactory(IMkJson json) : base(json) {}

        protected override sealed void FillSupportedTypes(Type type)
        {
            base.FillSupportedTypes(type);

            if (type.GetCustomAttributes(typeof (JsonModelAttribute), true).Length > 0)
            {
                this.TryAddType(type, new AjaxUserDefined(type));
            }
        }

        public object Parse(Type type, string data)
        {
            IAjaxParameter parameterType;
            if (this.TryGetType(type, out parameterType))
            {
                return parameterType.Parse(data);
            }

            foreach (Type implementedInterface in type.GetInterfaces())
            {
                if (implementedInterface.Name == typeof (IList<>).Name)
                {
                    Type generic = typeof (IList<>);
                    if (this.TryGetType(generic.MakeGenericType(type.GetGenericArguments()[0]), out parameterType))
                    {
                        return parameterType.Parse(data);
                    }
                }
            }
            throw new ArgumentException(string.Format("Type is not supported : {0}", type));
        }
    }
}