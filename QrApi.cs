using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;

namespace Proyecto
{
    public static class QrApi
    {
        public static HttpClient client = new HttpClient();
        public static WebClient web = new WebClient();
        public static string url = "http(s)://api.qrserver.com/v1/create-qr-code/?data=";
        public static string readurl = "http://api.qrserver.com/v1/read-qr-code";
        public static List<Store> stores = new List<Store>();
        public static QRresponse a;
        //public static QRDecoder QrCodeDecoder = new QRDecoder();

        public static void GenerateImage(string text, string name)
        {
            string fileName = name + ".png";
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile("https://api.qrserver.com/v1/create-qr-code/?data=Example", fileName);
        }

        //public static async Task<QRresponse> ReadImage(Bitmap file)
        //{
        //    QRCodeDecoder dec = new QRCodeDecoder();
        //    string res = (dec.decode(new QRCodeBitmapImage(file as Bitmap)));
        //    res = res.Replace("[", "");
        //    res = res.Replace("]", "");
        //    return JsonConvert.DeserializeObject<QRresponse>(res);
        //}


        public static void ReadImages()
        {
            List<string> filenames = GetFilesFrom();
            List<Bitmap> files = new List<Bitmap>();
            foreach (string i in filenames)
            {
                Bitmap image = new Bitmap(i);
                files.Add(image);
            }

            GenerateStores(files);
        }

        public static List<String> GetFilesFrom()
        {
            DirectoryInfo d = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] files = d.GetFiles("*.png");
            List<String> list = new List<string>();

            foreach(FileInfo file in files)
            {
                list.Add(file.Name);
            }
            return list;
        }

        public static async void GenerateStores(List<Bitmap> files)
        {
            foreach(Bitmap i in files)
            {
               // a = await ReadImage(i);
                //Store aux;
                //stores.Add(aux);
            }
        }

        public static List<Store> GetStores()
        {
            ReadImages();
            return stores;
        }
    }
}
