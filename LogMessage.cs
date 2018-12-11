using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class LogMessage
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public LogMessage(string text)
        {
            this.Message = text;
            this.Timestamp = DateTime.Now;
        }
    }
}
