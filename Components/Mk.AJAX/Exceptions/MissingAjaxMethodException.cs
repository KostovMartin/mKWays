using System;

namespace Mk.AJAX.Exceptions
{
    public class MissingAjaxMethodException : ArgumentException
    {
        public MissingAjaxMethodException(string message) : base(message) {}
    }
}