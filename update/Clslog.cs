using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace update
{
    class Clslog
    {
        // Fields
        private bool doconsoleoutput;
        private string logfile = (Path.GetDirectoryName(Application.ExecutablePath) + @"\update.log");

        // Methods
        [DebuggerStepThrough]
        public Clslog()
        {
            this.doconsoleoutput = true;
        }
        [DebuggerStepThrough]
        public Clslog(bool consoleoutput )
        {
            this.doconsoleoutput = consoleoutput;
        }

        [DebuggerStepThrough]
        public void ClearLog()
        {
            if (File.Exists(this.logfile))
            {
                File.Delete(this.logfile);
            }
        }

        ~Clslog()
        {
        }
        [DebuggerStepThrough]
        public void Write(string Value)
        {
            StreamWriter writer = File.AppendText(this.logfile);
            writer.Write(Value);
            writer.Close();
            if (this.doconsoleoutput)
            {
                Console.Write(Value);
            }
        }

        [DebuggerStepThrough]
        public void WriteLine(string Value)
        {
            StreamWriter writer = File.AppendText(this.logfile);
            writer.WriteLine(StringType.FromDate(DateTime.Now) + " -- " + Value);
            writer.Close();
            if (this.doconsoleoutput)
            {
                Console.WriteLine(Value);
            }
        }
    }
}
