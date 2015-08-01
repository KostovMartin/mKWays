namespace Mk.AJAX
{
    /// <summary>
    ///     Used to specify the JavaScript execution as blocking or async.
    /// </summary>
    public enum ExecutionType
    {
        /// <summary>
        ///     When used the JavaScript execution is async.
        /// </summary>
        Async = 0,

        /// <summary>
        ///     When used the JavaScript execution is blocking.
        /// </summary>
        Blocking = 1
    }
}