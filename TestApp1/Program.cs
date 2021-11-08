using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace TestApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

            Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), 
                «Название товара» (строка), «Цена товара» (вещественное число).
            Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
            Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/

            int n = 5;
            string path = "Products.json";
            Product[] product = new Product[n];
          
            for (int i = 0; i < n; i++) //Заводим Позиции (Не русифицировал - для считывания назад в программе 2 некритично)
            {
                product[i] = new Product(); //Нужно определять каждый раз, иначе исключение
                Console.Write("Создайте код {0} товара: ", i + 1);
                product[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Заполните наименование товара: ");
                product[i].Name = Console.ReadLine();
                Console.Write("Введите стоимость товара: ");
                product[i].Price = Convert.ToDouble(Console.ReadLine());
                Console.Write("\a");
                Console.Clear();

            }
         
            using (StreamWriter sw = new StreamWriter(path,false)) //Перезаписываем файл, если есть
            {
                for (int k = 0; k < n; k++)
                {
                        string jsonstring = JsonSerializer.Serialize(product[k]);
                    if (k==n-1) // Проверка чтобы не ставил пустую последнюю строку в файле, которая дает исключение в программе 2
                    {
                        sw.Write(jsonstring);
                    }
                    else
                    {
                        sw.WriteLine(jsonstring);
                    }
                        
                }
                sw.Close();
            }
           
            Console.Write("Данные сохранены в файл {0}", path);
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
