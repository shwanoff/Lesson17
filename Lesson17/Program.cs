using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson17
{
    class Program
    {
        // Домашнее задание
        // В своей предметно области создать метод со сложными вычислениями
        // Сделать для этого метода обертку в виде async-метода
        // Переписать свой код в асинхронном варианте

        // Создать вручную поток (thread)
        // Сделать для него повышенный приоритет
        // Запустить выполнение и попробовать завершить приложение

        // Использовать lock


        public static object locker = new object();

        public static int i1 = 100;

        static void M1()
        {
            for(int i = 0; i <= i1; i++)
            {

            }
        }

        static void M2()
        {
            for (int i = 0; i >= i1; i--)
            {

            }
        }

        static void Main(string[] args)
        {
            #region thread

            //Thread thread = new Thread(new ThreadStart(DoWork));
            //thread.Start();

            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));
            //thread2.Start(int.MaxValue);

            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;

            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine("Main");
            //    }
            //}
            #endregion

            #region async/await
            //Console.WriteLine("Begin main");
            //DoWorkAsync(1000);
            //Console.WriteLine("Continue Main");

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Main");
            //}
            //Console.WriteLine("End main");
            #endregion

            var result = SaveFileAsync("d:\\test.txt");
            var input = Console.ReadLine();
            Console.WriteLine(result.Result);
            Console.ReadLine();
        }




        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task.Run(() => SaveFile(path));
            return result;
        }

        static bool SaveFile(string path)
        {
            lock (locker)
            {
                var rnd = new Random();
                var text = "";
                for (int i = 0; i < 50000; i++)
                {
                    text += rnd.Next();
                }
            }

            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine();
            }

            return true;
        }

        static async Task DoWorkAsync(int max)
        {
            Console.WriteLine("Begin async");
            await Task.Run(() => DoWork(max));
            Console.WriteLine("End Async");
        }

        static void DoWork(int max)
        {
            int j = 0;
            for(int i = 0; i < max; i++)
            {
                Console.WriteLine("DoWork");
            }
        }

        static void DoWork2(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork 2");
                }
            }
        }
    }
}
