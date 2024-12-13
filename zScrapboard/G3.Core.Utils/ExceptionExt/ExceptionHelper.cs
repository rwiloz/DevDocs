using System;
using System.Text;

namespace G3.Core.Utils.ExceptionExt
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Generate full details based on exception object
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <param name="includeStackTrace">Should stack trace be included into the result?</param>
        /// <returns></returns>
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
        /// Generate full stack trace
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <returns></returns>
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
