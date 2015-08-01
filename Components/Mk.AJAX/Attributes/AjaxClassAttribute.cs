using System;

namespace Mk.AJAX
{
    /// <summary>
    ///     The class marked with this attribute will be included in the generated JavaScript output.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AjaxClassAttribute : Attribute
    {
        /// <summary>
        ///     Optional. Specifies different name for the client JavaScript function.
        ///     By default the output client JavaScript name is the same as the server name.
        /// </summary>
        public string Name { get; set; }
    }
}