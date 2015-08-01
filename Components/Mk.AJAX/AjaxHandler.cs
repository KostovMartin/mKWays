using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Web;
using Mk.AJAX.Exceptions;
using Mk.AJAX.Methods;

namespace Mk.AJAX
{
    /// <summary>
    ///     The base class for the webapi.
    ///     This handler will generate the necessary JavaScript. Every class which is marked with AjaxClassAttribute
    ///     will be included in the output JavaScript. In the marked classes only methods which are marked with the
    ///     AjaxMethodAttribute are going to be included. The AjaxHandler is IHttpHandler, so it is important not to
    ///     overload ProcessRequest and IsReusable in the child classes, which are used as webapi.
    /// </summary>
    public abstract class AjaxHandler : IHttpHandler
    {
        private readonly IMethodCaller _methodCaller;
        private readonly IMethodsGenerator _methodGenerator;
        private readonly Dictionary<string, MethodInfo> _methodsCache;
        private readonly object _methodsLock;

        protected AjaxHandler(IMkJson json)
        {
            this._methodsLock = new object();
            this._methodsCache = new Dictionary<string, MethodInfo>(31);
            this.InitMethods();
            this._methodCaller = new MethodCaller(this, json);
            this._methodGenerator = new MethodsGenerator(this.GetType(), this.GetMethods());
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            bool isMethodCall = context.Request.Headers["RequestTarget"] == "MethodCall";
            context.Response.ContentType = isMethodCall ? "application/json" : "text/javascript";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Expires = -1; // Disable caching of the page

            if (isMethodCall)
            {
                this.CallMethod(context);
            }
            else
            {
                this.GenerateMethods(context);
            }
        }

        private void CallMethod(HttpContext context)
        {
            string methodName = context.Request.PathInfo.Replace("/", string.Empty);
            try
            {
                MethodInfo method = this.GetMethod(methodName);
                if (method == null)
                {
                    throw new KeyNotFoundException(string.Format("Bad method name - {0}.", methodName));
                }

                NameValueCollection requestParams = context.Request.RequestType == "POST"
                    ? context.Request.Form
                    : context.Request.QueryString;

                context.Response.Output.Write(this._methodCaller.Call(method, requestParams));
            }
            catch (KeyNotFoundException ex)
            {
                WriteError(ex.Message, context.Response);
            }
            catch (MissingAjaxMethodException ex)
            {
                WriteError(ex.Message, context.Response);
            }
            catch (TargetInvocationException ex)
            {
                WriteError(ex.InnerException.Message, context.Response);
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, context.Response);
            }
        }

        private void GenerateMethods(HttpContext context)
        {
            try
            {
                context.Response.Output.Write(this._methodGenerator.Generate(context.Request.Url.AbsolutePath));
            }
            catch (MissingAjaxServiceException ex)
            {
                WriteError(ex.Message, context.Response);
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, context.Response);
            }
        }

        private MethodInfo GetMethod(string methodName)
        {
            lock (this._methodsLock)
            {
                return this._methodsCache[methodName];
            }
        }

        private IEnumerable<MethodInfo> GetMethods()
        {
            // happens once per ajax handler
            lock (this._methodsLock)
            {
                return this._methodsCache.Values;
            }
        }

        private void InitMethods()
        {
            // happens once per ajax handler
            lock (this._methodsLock)
            {
                Type type = this.GetType();

                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (MethodInfo info in methods)
                {
                    object[] attrs = info.GetCustomAttributes(typeof (AjaxMethodAttribute), false);
                    if (attrs.Length != 0)
                    {
                        this._methodsCache.Add(info.Name, info);
                    }
                }

                while (type != null && type != typeof (AjaxHandler))
                {
                    methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
                    foreach (MethodInfo info in methods)
                    {
                        object[] attrs = info.GetCustomAttributes(typeof (AjaxMethodAttribute), false);
                        if (attrs.Length != 0)
                        {
                            this._methodsCache.Add(info.Name, info);
                        }
                    }

                    type = type.BaseType;
                }
            }
        }

        private static void WriteError(string error, HttpResponse response)
        {
            response.Clear();
            response.Status = "Internal Server Error";
            response.StatusCode = 500;
            response.Output.WriteLine(error);
        }
    }
}