using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class Program
    {
        private static readonly Dictionary<int, Action> DictionaryOfFoo = new Dictionary<int, Action>() { { 1, RunComplex }, { 2, RunVector } };

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1] Комплексное число\n2] Вектор\n3] Выход");
                    Console.Write("Введите номер: ");
                    var resultParse = int.TryParse(Console.ReadLine(), out var resultNumber);
                    if (!resultParse)
                        throw new Exception("Неверный ввод");

                    if (resultNumber == 3)
                        break;

                    if (!DictionaryOfFoo.ContainsKey(resultNumber))
                        throw new Exception("Неверный номер");

                    DictionaryOfFoo[resultNumber].Invoke();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                Console.WriteLine("Нажмите кнопку чтобы продолжить..");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Нажмите любую кнопку чтобы выйти...");
            Console.ReadKey();
        }

        private static void RunComplex()
        {
            var number1 = new Complex(4, 4);
            var number2 = new Complex(0, 0);

            Console.WriteLine($"Первое число: {number1}\nВторое число: {number2}");

            Console.WriteLine($"Сложение: {number1 + number2}");
            Console.WriteLine($"Вычитание: {number1 - number2}");
            Console.WriteLine($"Деление: {number1 / number2}");
            Console.WriteLine($"Умножение: {number1 * number2}");

            Console.WriteLine($"Возмедение в степень: {Complex.Pow(number1, number2)}");
            Console.WriteLine($"Abs: {Complex.Abs(number1)}");
        }

        private static void RunVector()
        {
            var listComplex1 = new List<Complex>() { new Complex(1, 2), new Complex(2, 4), new Complex(-1, 9), new Complex(-9, 5) };
            var listComplex2 = new List<Complex>() { new Complex(-1, 6), new Complex(-3, 4), new Complex(5, -9), new Complex(9, -5) };

            var vector1 = new Vector<Complex>(listComplex1);
            var vector2 = new Vector<Complex>(listComplex2);

            Console.WriteLine($"Первый вектор: {vector1}\nВторой вектор: {vector2}");

            Console.WriteLine($"Сложение: {vector1 + vector2}");
            Console.WriteLine($"Вычитание: {vector1 - vector2}");
            Console.WriteLine($"Умножение на число: {vector1 * new Complex(1, 5)}");
            Console.WriteLine($"Скалярное произведение: {Vector<Complex>.ScalarMultiplication(vector1, vector2)}");
            var result = Vector<Complex>.Orthogonalization(new List<Vector<Complex>>() { vector1, vector2 });
            Console.WriteLine($"Ортогонализация:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    
    }
}
