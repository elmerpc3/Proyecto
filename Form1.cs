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
        int maxbread, maxveg, maxsoda;
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
            this.maxveg = 0;
            this.maxbread = 0;
            this.maxsoda = 0;
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

        private void StoresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Store aux = stores[StoresListBox.SelectedIndex];
            textBox1.Text = (aux.products[0].quantity).ToString();
            textBox2.Text = (aux.products[1].quantity).ToString();
            textBox3.Text = (aux.products[2].quantity).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string test = Testingbox.Text;
            QrApi.CreateImage(test, "Testing2");
        }

        private void StoresButton1_Click(object sender, EventArgs e)
        {
            Store aux = stores[StoresListBox.SelectedIndex];
            aux.products[0].quantity = Int32.Parse(textBox1.Text);
            aux.products[1].quantity = Int32.Parse(textBox2.Text);
            aux.products[2].quantity = Int32.Parse(textBox3.Text);
            aux.GenerateImage();
            logger.Log("Imagen generada de nuevo pedido de tienda " + aux.storeName);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            maxveg = Decimal.ToInt32(numericUpDown1.Value * 95);
            label14.Text = (maxveg).ToString() + " vegetable bags.";
            logger.Log("Delivery trucks modified");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            maxbread = Decimal.ToInt32(numericUpDown2.Value * 270);
            label15.Text = (maxbread).ToString() + " bread pieces.";
            logger.Log("Delivery trucks modified");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            maxsoda = Decimal.ToInt32(numericUpDown3.Value * 120);
            label16.Text = (maxsoda).ToString() + " sodas.";
            logger.Log("Delivery trucks modified");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            logger.Log("Route Simulation started");
            float aux = stores[0].GetTotal();
            List<Store> newlist = stores.OrderByDescending(o=>o.GetTotal()).ToList();
            StoresListBox.DataSource = newlist;
            logger.Log("Route Simulation finished");
        }

        private void SimulButton_Click(object sender, EventArgs e)
        {
            logger.Log("Truck Simulation started");
            int totalveg = 0;
            int totalsoda = 0;
            int totalbread = 0;
            string text = "";
            int leftovers = 0;
            int total;
            int max = maxbread + maxveg + maxsoda;
            foreach(Store i in stores)
            {
                totalveg += i.products[0].quantity;
                totalbread += i.products[1].quantity;
                totalsoda += i.products[2].quantity;
            }
            total =totalveg + totalbread + totalsoda;

            if((numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value) > 5)
            {
                text += "    Max truck limit excedeed.";
            }
            if(totalveg < maxveg)
            {
                if(totalbread < maxbread)
                {
                    if(totalsoda < maxsoda)
                    {
                        text += "Enough products available " + (max - total) + " products left over";
                    }
                    else
                    {
                        text += "  Not enough soda available.";
                    }
                }
                else
                {
                    text += "   Not enough bread available";
                }
            }
            else
            {
                text += "   Not enough vegetables available. ";
            }

            ResultLabel.Text = text;
            logger.Log("Truck Simulation finished");
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
