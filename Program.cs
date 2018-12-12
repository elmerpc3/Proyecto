using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            List<Store> stores3 = QrApi.GetStores();

            //List<String> stores = QrApi.GetFilesFrom();
            //List<Store> stores1 = new List<Store>();
            //foreach(String i in stores)
            //{
            //    stores1.Add(new Store(i));
            //}

            Application.Run(new Form1(stores3));
        }
    }
}
