using Serilog;
using Serilog.Formatting;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// RichTextBoxSinkExtensions class
    /// </summary>
    public static class RichTextBoxSinkExtensions
    {
        /// <summary>
        /// Write the simple formatted text logs directly to the RichTextBox. This simple RichTextBox control can be used from the toolbox.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToRichTextBox(this LoggerConfiguration configuration, ITextFormatter formatter = null)
        {
            return configuration.WriteTo.Sink(RichTextBoxLogSink.MakeRichTextBoxSink(formatter));
        }
    }
}
