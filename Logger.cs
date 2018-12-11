using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Logger
    {
        private static Logger _instance;

        //private static object _handle
        private StreamWriter StreamWriter = null;
        //private Stream logStream;
        private Form1 form;
        public List<String> activated;

        protected Logger()
        {
            //logStream = File.Open("logfile.log", FileMode.Create);
            //  StreamWriter = new StreamWriter(logStream);

            using (StreamWriter writetext = new StreamWriter("logfile.log"))
            {
                writetext.Write("");
            }
            activated = new List<string>();
        }

        public void Log(string message)
        {
            for(int i = 0;i<activated.Count; i++)
            {
                switch(activated.ElementAt(i))
                {
                    case ("Logfile"):
                        LogFile(message);
                        break;
                    case ("TextBox"):
                        TextBoxLog(message);
                        break;
                    case ("Grid"):
                        GridLog(message);
                        break;
                }
            }
        }


        private void LogFile(string message)
        {
            string datedmessage = DateMessage(message);
            using (StreamWriter writetext = new StreamWriter("logfile.log", true))
            {
                writetext.WriteLine(datedmessage);
            }
        }

        private void TextBoxLog(string message)
        {
            string datedmessage = DateMessage(message);
            form.UpdateTextBox(datedmessage);
        }

        private void GridLog(string message)
        {
            form.UpdateGrid(message);
        }

        public void Add(string mode)
        {
            activated.Add(mode);
        }

        public void Remove(int index)
        {
            activated.RemoveAt(index);
        }

        public void SetForm(Form1 form)
        {
            this.form = form;
        }

        public string DateMessage(string message)
        {
            return string.Format("{0}      {1}", message, DateTime.Now);
        }

        public static Logger Instance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        ~Logger()
        {
            try
            {
                StreamWriter.Close();
                StreamWriter.Dispose();
            }
            catch (Exception)
            {

            }
        }
    }
}
