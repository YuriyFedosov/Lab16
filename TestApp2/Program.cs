using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace TestApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*2.    Необходимо разработать программу для получения информации о товаре из json-файла.
                    Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/


            
            string path = "C:\\Users\\Yuri Fedosov\\Desktop\\ITMO-BIM\\C#\\Projects\\Lab16\\TestApp1\\bin\\Debug\\Products.json"; //Тут путь в каталог с 1 программой
            int n = 0;
            double mPrice = 0;
            string mName = "";
            string[] jsString;
            using (StreamReader sRead = new StreamReader(path))
            {
                jsString = sRead.ReadToEnd().Split('\n');

            }
            n = jsString.Length; // считаем строки
            Product[] product = new Product[n];
            for (int i = 0; i < n; i++)
            {
                
                    product[i] = JsonSerializer.Deserialize<Product>(jsString[i]);// Считываем из файла
               
            }
            foreach (Product a in product) //Выбираем максимальную
            {
                if (mPrice < a.Price)
                {
                    mPrice = a.Price;
                    mName = a.Name;
                }
            }

            Console.WriteLine("Самый дорогой товар \"{0}\" по цене {1}", mName, mPrice);
            Console.ReadKey();
        }
    }
    class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
