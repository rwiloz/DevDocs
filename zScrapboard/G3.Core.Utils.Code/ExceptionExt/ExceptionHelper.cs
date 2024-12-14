using System;
using System.Text;

namespace G3.Core.Utils.ExceptionExt
{
    /// <summary>
    /// A static class implementing extension methods for Exception handling.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Generates a formatted string containing detailed information about the given Exception object.
        /// </summary>
        /// <param name="ex">The primary Exception object.</param>
        /// <param name="includeStackTrace">Determines whether stack trace should be included in the output string. Default is false.</param>
        /// <param name="includeExceptionTypeName">Determines whether type of the exception should be included in the output string. Default is true.</param>
        /// <param name="includeInnerExceptions">Determines whether inner exceptions should be included in the output string. Default is true.</param>
        /// <returns>A formatted string containing detailed information about the Exception.</returns>
        public static string ToMessage(this Exception ex, bool includeStackTrace = false, bool includeExceptionTypeName = true, bool includeInnerExceptions = true)
        {
            var message = new StringBuilder();
            while (ex != null)
            {
                if (message.Length > 0)
                    message.Append("\n--------------\n");

                if (includeExceptionTypeName)
                    message.Append(ex.GetType().Name).Append(": ");

                message.Append(ex.Message);

                if (includeStackTrace)
                    message.Append(ex.StackTrace);

                if (!includeInnerExceptions)
                    break;

                ex = ex.InnerException;
            }
            return message.ToString();
        }

        /// <summary>
        /// Generates full stack trace string for given Exception object including all inner exceptions.
        /// </summary>
        /// <param name="ex">The primary Exception object.</param>
        /// <returns>A string containing full stack trace for given Exception object.</returns>
        public static string ToStackTrace(this Exception ex)
        {
            var stackTrace = new StringBuilder();
            while (ex != null)
            {
                if (stackTrace.Length > 0)
                    stackTrace.Append("\n--------------\n");

                stackTrace.Append("Stack trace for ").Append(ex.GetType().Name).Append(":\n").Append(ex.StackTrace);

                ex = ex.InnerException;
            }
            return stackTrace.ToString();
        }
    }
}