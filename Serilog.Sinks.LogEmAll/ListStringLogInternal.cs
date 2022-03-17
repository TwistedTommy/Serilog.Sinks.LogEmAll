using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// ListStringLogInternal class
    /// </summary>
    public class ListStringLogInternal : ILogEventSink
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
        public ListStringLogInternal(ITextFormatter textFormatter)
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
    /// ListStringLogSink class.
    /// </summary>
    public static class ListStringLogSink
    {
        /// 
        private static ListStringLogInternal _listStringSink = new ListStringLogInternal(new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message} {Exception}"));
        /// 
        public static ListStringLogInternal ListStringSink => _listStringSink;

        /// <summary>
        /// MakeListStringSink
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static ListStringLogInternal MakeListStringSink(ITextFormatter formatter = null)
        {
            if (formatter == null) { formatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message} {Exception}"); }

            _listStringSink = new ListStringLogInternal(formatter);

            return _listStringSink;
        }
    }
}
