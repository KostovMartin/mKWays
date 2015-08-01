using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mk.AJAX.Methods.SupportedTypes.Factories
{
    internal class TypesFactory<TFactoryType>
        where TFactoryType : class, IAjaxType
    {
        private readonly bool _isInited;

        private readonly IMkJson _json;
        private readonly Dictionary<Type, TFactoryType> _supportedTypes = new Dictionary<Type, TFactoryType>();

        protected TypesFactory(IMkJson json)
        {
            if (!this._isInited)
            {
                this._isInited = true;
                this._json = json;
                this.Init();
            }
        }

        private void Init()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    this.FillSupportedTypes(type);
                }
            }
        }

        protected virtual void FillSupportedTypes(Type type)
        {
            foreach (Type classType in type.GetInterfaces())
            {
                if (classType == typeof (TFactoryType))
                {
                    var myType = Activator.CreateInstance(type) as TFactoryType;
                    if (myType != null && myType.SupportedType != null)
                    {
                        this.TryAddType(type, myType);
                    }
                    break;
                }
            }
        }

        protected bool TryAddType(Type type, TFactoryType myType)
        {
            if (!this._supportedTypes.ContainsKey(type))
            {
                myType.Json = this._json;
                this._supportedTypes.Add(myType.SupportedType, myType);
                return true;
            }
            return false;
        }

        protected bool TryGetType(Type type, out TFactoryType result)
        {
            if (this._supportedTypes.ContainsKey(type))
            {
                result = this._supportedTypes[type];
                return true;
            }
            result = null;
            return false;
        }
    }
}