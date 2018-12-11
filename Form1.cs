using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        Logger logger;
        List<LogMessage> gridlist;
        List<Store> stores;
        public Form1(List<Store> stores)  
            {
            InitializeComponent();
            this.logger = Logger.Instance;
            gridlist = new List<LogMessage>();
            logger.SetForm(this);
            LoggerListBox.DataSource = logger.activated;
            LoggerGrid.DataSource = gridlist;
            this.stores = stores;
            StoresListBox.DataSource = stores;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoggerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void UpdateTextBox(string text)
        {
            string newtext;
            newtext = LoggerTextBox.Text + Environment.NewLine + text;

            LoggerTextBox.Text = newtext;
            //UpdateLogs();
        }

        public void UpdateGrid(string text)
        {
            LogMessage message = new LogMessage(text);
            gridlist.Add(message);
            UpdateLogs();
        }

        private void GridLogButton_Click(object sender, EventArgs e)
        {
            logger.Add("Grid");
            logger.Log("Testing hola");
            UpdateLogs();
        }

        private void LogFileButton_Click(object sender, EventArgs e)
        {
            logger.Add("Logfile");
            UpdateLogs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logger.Add("TextBox");
            UpdateLogs();
        }

        private void UpdateLogs()
        {
            LoggerListBox.DataSource = null;
            LoggerListBox.DataSource = logger.activated;
            LoggerGrid.DataSource = null;
            LoggerGrid.DataSource = gridlist;
            LoggerGrid.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Remove(LoggerListBox.SelectedIndex);
            UpdateLogs();
        }
    }
}
