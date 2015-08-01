using System.Collections.Specialized;
using System.Reflection;

namespace Mk.AJAX.Methods
{
    internal interface IMethodCaller
    {
        string Call(MethodInfo method, NameValueCollection requestParams);
    }
}