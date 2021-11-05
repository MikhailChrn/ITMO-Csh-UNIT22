using System;
using System.Threading;
using System.Threading.Tasks;

namespace Задание_01
{
    //1.Сформировать массив случайных целых чисел (размер  задается пользователем).
    //Вычислить сумму чисел массива и максимальное число в массиве.
    //Реализовать решение задачи с использованием механизма задач продолжения.
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = 1;
            Console.WriteLine("Здравствуйте!");
        ReadArrayCount:
            Console.WriteLine("Введите размер массива (целое положительное число):");
            try { n = Convert.ToInt16(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadArrayCount; }
            if (n > 999999 || n < 1) { Console.WriteLine("Введено некорректное значение!"); goto ReadArrayCount; }

            //Заполняем массив случайными числами. (Реализовать через отдельный метод не удалось)
            int[] array = new int[n];
            for (int i = 0; i < n; i++) { array[i] = random.Next(0, 1000); }

            //РЕАЛИЗОВАТЬ НЕ ПОЛУЧИЛОСЬ! Метод принимающий на входе массив и отдающий заполгненный массив
            //Func<object> func01 = new Func<object>(ArrayFormation);
            //Объявляем делегат метода 2
            Action<object> action02 = new Action<object>(ArrayMaxElement);
            //Объявляем делегат метода 3
            Action<Task, object> action03 = new Action<Task, object>(ArraySumElement);

            //Формируем цепочку заданий
            Task task02 = new Task(action02, array);
            Task task03 = task02.ContinueWith(action03, array);

            //Стартуем первое задание
            task02.Start();

            Console.WriteLine("Метод 0 MAIN закончил свою работу ");
            Console.ReadKey();
        }

        //РЕАЛИЗОВАТЬ НЕ ПОЛУЧИЛОСЬ! метод генерирует массив случайных чисел
        //public static object ArrayFormation(object n)
        //{
        //    int[] _array = object[] n;
        //    Random random = new Random();
        //    for (int i = 0; i < _array.Length; i++) { _array[i] = random.Next(0, 1000); }
        //    _array = (object)n;
        //    return n;
        //}

        //Объявляем метод находящий максимальное значение в массиве
        public static void ArrayMaxElement(object a)
        {
            int[] array = (int[])a;
            Console.WriteLine("Метод 2 (находящий максимальное значение) стартовал !");
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) { max = array[i]; }
                Thread.Sleep(1);
            }
            Console.WriteLine("Метод 2 закончил свою работу !");
            Console.WriteLine("Максимальный элемент массива: {0}", max);            
        }

        //Объявляем метод находящий сумму элементов в массиве
        public static void ArraySumElement(Task task, object a)
        {
            int[] array = (int[])a;
            Console.WriteLine("Метод 3 (находящий сумму элементов массива) стартовал !");
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
                Thread.Sleep(1);
            }
            Console.WriteLine("Метод 3 закончил свою работу !");
            Console.WriteLine("Сумма элементов массива: {0}", sum);            
        }


    }

}