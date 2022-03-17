using Serilog;
using Serilog.Formatting;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// ListStringLogExtensions class
    /// </summary>
    public static class ListStringLogExtensions
    {
        /// <summary>
        /// Write the simple formatted text logs directly to the List String. This List String control can be used from the toolbox.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToListString(this LoggerConfiguration configuration, ITextFormatter formatter = null)
        {
            return configuration.WriteTo.Sink(ListStringLogSink.MakeListStringSink(formatter));
        }
    }
}
