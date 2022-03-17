using System.Collections.Generic;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// ListStringLog class
    /// </summary>
    public partial class ListStringLog : List<string>
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ListStringLog()
        {
            ListStringLogSink.ListStringSink.OnLogReceived += ListStringSinkOnLogReceived;
        }

        #endregion

        #region ListStringSink

        /// <summary>
        /// Outputs a text string to the List String Sink log.
        /// </summary>
        /// <param name="strMsg"></param>
        private void ListStringSinkOnLogReceived(string strMsg)
        {
            // Add the line of text to the log.
            this.Add(strMsg);
        }

        #endregion
    }
}
