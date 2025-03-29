using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba2
{


    internal class Program
    {

        static string syncZapros(string url)
        {

            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result;
                    client.Dispose();
                    return resultStr;
                    // Console.WriteLine(resultStr);
                }
                else
                {
                    Console.WriteLine($"Ошибка запроса:{response.StatusCode}");
                    client.Dispose();
                    return null;
                }


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка запроса: {e.Message}");
                client.Dispose();
                return null;

            }
            catch (AggregateException e) // возникают при работе с .Result();
            {
                foreach (var i in e.InnerExceptions)
                {
                    Console.WriteLine($"Исключение: {i.InnerException}\n {i.Message}\n {i.GetType()}  \n ");
                }
                client.Dispose();
                return null;
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine($"Указан неверный адрес {e.InnerException}");
                client.Dispose();
                return null;
            }
        }
        static void Zad1()

        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            syncZapros("https://www.google.com/");
            syncZapros("https://edu.stankin.ru/");
            syncZapros("https://nonexistentdomain12345.com");  //https://nonexistentdomain12345.com
            sw.Stop();
            Console.WriteLine($"время выполенния 3 запросов синхронным методом: {sw.ElapsedMilliseconds}");
        }
        static async Task Zad2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await asyncZapros("https://www.google.com/");
            await asyncZapros("https://edu.stankin.ru/");
            await asyncZapros("https://vk.com/feed");  //
            sw.Stop();
            Console.WriteLine($"время выполенния 3 запросов Асинхронным методом: {sw.ElapsedMilliseconds}");
        }
        static async Task<string> asyncZapros(string url)
        {
            HttpClient client = new HttpClient();
            try
            {

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string resultStr = await response.Content.ReadAsStringAsync();
                    client.Dispose();
                    return resultStr;
                    // Console.WriteLine(resultStr);
                }
                else
                {
                    Console.WriteLine($"Ошибка запроса:{response.StatusCode}");
                    client.Dispose();
                    return null;
                }


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка запроса: {e.Message}");
                client.Dispose();
                return null;

            }

            catch (System.InvalidOperationException e)
            {
                Console.WriteLine($"Указан неверный адрес {e.InnerException}");
                client.Dispose();
                return null;


            }
        }
        static void Main(string[] args)
        {
            Zad2().Wait();
            Zad1();

        }
    }
}