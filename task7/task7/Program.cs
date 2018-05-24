using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class Program
    {
        private static readonly Dictionary<int, Action> Dictionary = new Dictionary<int, Action>() { { 1, MatrixAction }, { 2, PolynomAction } };

        private static void Main()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1] Матрицы\n2]Полиномы\n-1] Выход");
                    Console.Write("Введите индекс: ");

                    var resultParse = int.TryParse(Console.ReadLine(), out var resultNumber);

                    if (!resultParse)
                        throw new Exception("Неверный ввод");

                    if (resultNumber == -1)
                        break;

                    if (Dictionary.ContainsKey(resultNumber))
                    {
                        var inv= Dictionary[resultNumber];
                        inv.Invoke();
                    }
                    else Console.WriteLine("Невверный индекс");

                    Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Нажмите любую кнопку чтобы выйти...");
            Console.ReadKey();
        }

        private static void MatrixAction()
        {
            var matrixFirst = new Matrix(new double[] { 1, 2, 3,2 });
            var matrixSecond = new Matrix(new double[] { 2, 4, 3,3 });

            var newMatrix = (Matrix)matrixFirst.Clone();

            Console.WriteLine(string.Format($"Первая матрица:\n{matrixFirst}"));
            Console.WriteLine(string.Format($"Вторая матрица:\n{matrixSecond}"));
            Console.WriteLine($"Клон первой матрицы:\n{newMatrix}");

            Console.WriteLine(string.Format($"operator '+' \n{matrixFirst + matrixSecond}"));
            Console.WriteLine(string.Format($"operator '-' \n{matrixFirst - matrixSecond}"));
            Console.WriteLine(string.Format($"operator '*' \n{matrixFirst * matrixSecond}"));
            Console.WriteLine(string.Format($"operator '/' \n{matrixFirst / matrixSecond}"));

            Console.WriteLine("Работа с элементами в цикле foreach");
            foreach (var item in newMatrix)
                Console.WriteLine(item);
        }

        private static void PolynomAction()
        {
            var marixFirst = new Matrix(new double[] { 1, 2, 3, 4 });
            var marixSecond = new Matrix(new double[] { 2, 4, 3,7 });


            var polynomFirst = new Polynom<Matrix>
                (new KeyValuePair<int, Matrix>(2, marixFirst), new KeyValuePair<int, Matrix>(3, marixSecond));

            var polynomSecond = new Polynom<Matrix>
                (new KeyValuePair<int, Matrix>(2, marixSecond), new KeyValuePair<int, Matrix>(3, marixFirst));

            Console.WriteLine(string.Format($"Первый полином: {polynomFirst}"));
            Console.WriteLine(string.Format($"Второй полином: {polynomSecond}"));
            Console.WriteLine(string.Format($"operator '+' {polynomFirst + polynomSecond}"));
            Console.WriteLine(string.Format($"operator '-' {polynomFirst - polynomSecond}"));
            Console.WriteLine(string.Format($"operator '*' {polynomFirst * polynomSecond}"));
            Console.WriteLine(string.Format($"operator '/' {polynomFirst / polynomSecond}"));
        }
    }
}

