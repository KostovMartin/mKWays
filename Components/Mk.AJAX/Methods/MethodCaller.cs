using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using Mk.AJAX.Exceptions;
using Mk.AJAX.Methods.SupportedTypes.Factories;

namespace Mk.AJAX.Methods
{
    internal class MethodCaller : IMethodCaller
    {
        private readonly AjaxHandler _executionContext;
        private readonly ParametersFactory _parametersFactory;
        private readonly ResultsFactory _resultsFactory;

        public MethodCaller(AjaxHandler executionContext, IMkJson json)
        {
            this._executionContext = executionContext;
            this._resultsFactory = new ResultsFactory(json);
            this._parametersFactory = new ParametersFactory(json);
        }

        public string Call(MethodInfo method, NameValueCollection requestParams)
        {
            object[] methodAttributes = method.GetCustomAttributes(typeof (AjaxMethodAttribute), true);
            if (methodAttributes.Length == 0)
            {
                throw new MissingAjaxMethodException(string.Format("{0} does not have AjaxMethod attribute.",
                    method.Name));
            }

            var parameters = method.GetParameters();
            var resultParams = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                resultParams[i] = this._parametersFactory.Parse(param.ParameterType, requestParams[param.Name]);
            }

            var methodResult = method.Invoke(method.IsStatic ? null : this._executionContext, resultParams);
            return this.GetResult(method.ReturnType, methodResult);
        }

        private string GetResult(Type returnType, object result)
        {
            return this._resultsFactory.Parse(returnType, result);
        }
    }
}