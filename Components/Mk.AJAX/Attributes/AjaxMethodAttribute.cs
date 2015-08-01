using System;

namespace Mk.AJAX
{
    /// <summary>
    ///     The method marked with this attribute will be included in the generated JavaScript output,
    ///     but only if the class is also included.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxMethodAttribute : Attribute
    {
        /// <summary>
        ///     Default values are:
        ///     RequestType = RequestType.Post;
        ///     ExecutionType = ExecutionType.Async;
        ///     UseJavaScriptNamingConvention = true;
        /// </summary>
        public AjaxMethodAttribute()
        {
            this.RequestType = RequestType.Post;
            this.ExecutionType = ExecutionType.Async;
            this.UseJavaScriptNamingConvention = true;
        }

        /// <summary>
        ///     Optional. Specifies different name for the client JavaScript function.
        ///     By default the output client JavaScript name is the same as the server name,
        ///     but the first letter is lower case.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Optional. Specifies the Http data transfer method which is going to be used.
        ///     By default it is RequestType.Post.
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        ///     Optional. Specifies the execution type used by the client which is going to be used.
        ///     By default it is ExecutionType.Async.
        /// </summary>
        public ExecutionType ExecutionType { get; set; }

        /// <summary>
        ///     Optional. Specifies the convention used when the JavaScript function is generated.
        ///     By default client side name starts with lower case.
        /// </summary>
        public bool UseJavaScriptNamingConvention { get; set; }
    }
}