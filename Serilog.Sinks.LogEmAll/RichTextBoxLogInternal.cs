using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// RichTextBoxLogInternal class
    /// </summary>
    public class RichTextBoxLogInternal : ILogEventSink
    {
        /// Private member variable
        private ITextFormatter _textFormatter;

        /// 
        public delegate void LogHandler(string str);

        /// 
        public event LogHandler OnLogReceived;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textFormatter"></param>
        public RichTextBoxLogInternal(ITextFormatter textFormatter)
        {
            _textFormatter = textFormatter;
        }

        /// <summary>
        /// Emit
        /// </summary>
        /// <param name="logEvent"></param>
        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            if (_textFormatter == null) { throw new ArgumentNullException("Missing Log Formatter"); }

            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);

            FireEvent(renderSpace.ToString());
        }

        /// <summary>
        /// Fire Event
        /// </summary>
        /// <param name="str"></param>
        private void FireEvent(string str)
        {
            OnLogReceived?.Invoke(str);
        }
    }

    /// <summary>
    /// RichTextBoxLogSink class.
    /// </summary>
    public static class RichTextBoxLogSink
    {
        /// 
        private static RichTextBoxLogInternal _richTextBoxSink = new RichTextBoxLogInternal(new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message} {Exception}"));
        /// 
        public static RichTextBoxLogInternal RichTextBoxSink => _richTextBoxSink;

        /// <summary>
        /// MakeRichTextBoxSink
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static RichTextBoxLogInternal MakeRichTextBoxSink(ITextFormatter formatter = null)
        {
            if (formatter == null) { formatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message} {Exception}"); }

            _richTextBoxSink = new RichTextBoxLogInternal(formatter);

            return _richTextBoxSink;
        }
    }
}
