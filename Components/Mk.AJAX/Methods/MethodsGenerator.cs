using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Mk.AJAX.Exceptions;

namespace Mk.AJAX.Methods
{
    internal class MethodsGenerator : IMethodsGenerator
    {
        private readonly Type _type;
        private readonly IEnumerable<MethodInfo> _typeMethods;

        public MethodsGenerator(Type type, IEnumerable<MethodInfo> typeMethods)
        {
            this._type = type;
            this._typeMethods = typeMethods;
        }

        public string Generate(string uri)
        {
            // FORMAT : 
            // var <jsClassName>={
            // <Method1>,
            // ,...,
            // <Methodn>};
            var result = new StringBuilder();
            object[] attrs = this._type.GetCustomAttributes(typeof (AjaxClassAttribute), true);
            if (attrs.Length == 0)
            {
                throw new MissingAjaxServiceException(string.Format("{0} has no AJAXService attribute",
                    this._type.FullName));
            }

            var attr = (AjaxClassAttribute) attrs[0];
            string className = attr.Name ?? this._type.Name;
            result.AppendFormat("var {0}={{", className);
            bool isFirst = true;
            foreach (MethodInfo method in this._typeMethods)
            {
                attrs = method.GetCustomAttributes(typeof (AjaxMethodAttribute), true);
                if (attrs.Length != 0)
                {
                    if (!isFirst)
                    {
                        result.Append(",");
                    }
                    result.Append(GenerateMethod(method, (AjaxMethodAttribute) attrs[0], uri));
                    isFirst = false;
                }
            }
            result.Append("};");
            return result.ToString();
        }

        private static string GenerateMethod(MethodBase method, AjaxMethodAttribute attribute, string url)
        {
            // FORMAT:
            // 1. Async:
            // <MethodName>:function(<Parameters: pi>,sc,ec) {var p={<Parameters: pi:pi>};MkAJAX.callAsync(<URL>,<RequestType>,p,sc,ec);}
            // 2. Blocking:
            // <MethodName>:function(<Parameters: pi>) {var p={<Parameters: pi:pi>};return MkAJAX.callBlock(<URL>,<RequestType>,p);}
            ParameterInfo[] methodParams = method.GetParameters();
            string name = attribute.Name ?? method.Name;
            bool isAsync = attribute.ExecutionType == ExecutionType.Async;
            return string.Format("{0}{1}:function({2}{3}){{var p={{{4}}};{5}(\"{6}/{7}\",{8},p{9}{3});}}",
                /*0*/Environment.NewLine,
                /*1*/attribute.UseJavaScriptNamingConvention ? FirstCharacterToLower(name) : name,
                /*2*/string.Format("{0}{1}", string.Join(",", Array.ConvertAll(methodParams, p => p.Name)),
                    methodParams.Length > 0 && isAsync ? "," : string.Empty),
                /*3*/isAsync ? "cb" : string.Empty,
                /*4*/methodParams.Length > 0
                    ? string.Join(",", Array.ConvertAll(methodParams, p => string.Format("{0}:{0}", p.Name)))
                    : string.Empty,
                /*5*/isAsync ? "MkAjax.callAsync" : "return MkAjax.callBlock",
                /*6*/url,
                /*7*/method.Name,
                /*8*/attribute.RequestType == RequestType.Post ? "true" : "false", // false for now mean GET
                /*9*/isAsync ? "," : string.Empty);
        }

        private static string FirstCharacterToLower(string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
            {
                return str;
            }
            return string.Format("{0}{1}", char.ToLowerInvariant(str[0]), str.Substring(1));
        }
    }
}