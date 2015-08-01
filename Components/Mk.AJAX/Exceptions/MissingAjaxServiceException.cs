using System;

namespace Mk.AJAX.Exceptions
{
    public class MissingAjaxServiceException : ArgumentException
    {
        public MissingAjaxServiceException(string message) : base(message) {}
    }
}