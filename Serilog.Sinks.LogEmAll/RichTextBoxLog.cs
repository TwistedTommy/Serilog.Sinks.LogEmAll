using System.Windows.Forms;

namespace Serilog.Sinks.LogEmAll
{
    /// <summary>
    /// RichTextBoxLog class
    /// </summary>
    public partial class RichTextBoxLog : RichTextBox
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RichTextBoxLog()
        {
            InitializeComponent();
            RichTextBoxLogSink.RichTextBoxSink.OnLogReceived += RichTextBoxSinkOnLogReceived;
        }

        #endregion

        #region RichTextBoxSink

        /// <summary>
        /// Outputs a text string to the RichTextBox Sink log.
        /// </summary>
        /// <param name="strMsg"></param>
        private void RichTextBoxSinkOnLogReceived(string strMsg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    (MethodInvoker)delegate
                    {
                        this.AppendText(strMsg);
                        this.ScrollToCaret();
                    });
            }
            else
            {
                this.AppendText(strMsg);
                this.ScrollToCaret();
            }

            Application.DoEvents();
        }

        #endregion
    }
}
