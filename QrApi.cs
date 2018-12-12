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
using QRCodeEncoderDecoderLibrary;
using System.Drawing.Imaging;

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
        public static QRDecoder QrCodeDecoder = new QRDecoder();

        public static void CreateImage(string text, string name)
        {
            MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeVersion = 0;
            Bitmap bmp = encoder.Encode(text);
            bmp.Save(name+".png");

        }


        public static Store ReadImage(Bitmap file)
        {
            using (file)
            {
                MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                string res = decoder.decode(new QRCodeBitmapImage(file));
                return JsonConvert.DeserializeObject<Store>(res);
            }
                
        }

        public static void ReadImages()
        {
            List<string> filenames = GetFilesFrom();
            List<Bitmap> files = new List<Bitmap>();
            List<Store> storeslista = new List<Store>();
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

        public static void GenerateStores(List<Bitmap> files)
        {
            Store aux;
            foreach(Bitmap i in files)
            {
                aux = ReadImage(i);
                aux.CheckEmpty();
                stores.Add(aux);
            }
        }

        public static List<Store> GetStores()
        {
            ReadImages();
            return stores;
        }
    }
}
