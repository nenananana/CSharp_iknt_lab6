using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_lab6
{
    class Program
    {
        static bool IsValidString(string input)
        {
            // Проверяем, что все символы в строке являются буквами
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
        }
        static bool TryParseFraction(string input, out int numerator, out int denominator)
        {
            numerator = 0;
            denominator = 0;

            if (!input.Contains("/"))
            {
                return false;
            }
            string[] parts = input.Split('/');
            if (parts.Length != 2)
            {
                return false;
            }
            if (!int.TryParse(parts[0], out numerator) || !int.TryParse(parts[1], out denominator))
            {
                return false;
            }
            return true;
        }
        static void Main()
        {
            string ex;

            Console.WriteLine("Выберете номер задания: \n\n" +
                "1.  Задание \"Кот\".\n" +
                "2.  Задание \"Дроби\".\n");
            ex = Console.ReadLine();
            switch (ex)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("Введите имя котика: ");
                        string strcat = "";
                        bool proverochka = true;
                        while (proverochka)
                        {
                            strcat = Console.ReadLine();
                            if (IsValidString(strcat))
                            {
                                proverochka = false;
                            }
                            else
                            {
                                Console.WriteLine("Имя котика должно содержать только буквы");

                            }
                        }


                        Cat cat1 = new Cat(strcat);


                        Cat cat2 = new Cat("Хрюшик");
                        Cat cat3 = new Cat("Невдупленыш");

                        BigCat bigcat1 = new BigCat("Тыковка");
                        BigCat bigcat2 = new BigCat("Плюша");

                        MeowCounterDecorator counter1 = new MeowCounterDecorator(cat1);
                        MeowCounterDecorator counter2 = new MeowCounterDecorator(cat2);
                        MeowCounterDecorator counter3 = new MeowCounterDecorator(cat3);
                        MeowCounterDecorator counter4 = new MeowCounterDecorator(bigcat1);
                        MeowCounterDecorator counter5 = new MeowCounterDecorator(bigcat2);

                        counter1.Meow();
                        Console.WriteLine("Сколько раз он мяукнет?");
                        int intmeow = Convert.ToInt32(Console.ReadLine());
                        counter1.Meow(intmeow);

                        Console.WriteLine("\nВызов массового мяукания:");


                        // задание 1.3
                        List<IMeowable> meowables2 = new List<IMeowable>
                    {
                        counter1,
                        counter2,
                        counter3,
                        counter4,
                        counter5
                    };

                        MeowManager.MakeAllMeow(meowables2);

                        Console.WriteLine($"{cat1.ToString()} мяукнул {counter1.GetMeowCount()} раз(а).");
                        Console.WriteLine($"{cat2.ToString()} мяукнул {counter2.GetMeowCount()} раз(а).");
                        Console.WriteLine($"{cat3.ToString()} мяукнул {counter3.GetMeowCount()} раз(а).");
                        Console.WriteLine($"{bigcat1.ToString()} мяукнул {counter4.GetMeowCount()} раз(а).");
                        Console.WriteLine($"{bigcat2.ToString()} мяукнул {counter5.GetMeowCount()} раз(а).");

                    }
                    catch
                    {
                        Console.WriteLine("Некорректный ввод");
                    }

                    break;
                case "2":

                    try
                    {
                        Console.WriteLine("Введите 1 дробь в формате n/d ");
                        string dr = Console.ReadLine();
                        TryParseFraction(dr, out int n1, out int d1);
                        Console.WriteLine("Введите 2 дробь в формате n/d ");
                        string dr2 = Console.ReadLine();
                        TryParseFraction(dr2, out int n2, out int d2);
                        Console.WriteLine("Введите 3 дробь в формате n/d ");
                        string dr3 = Console.ReadLine();
                        TryParseFraction(dr3, out int n3, out int d3);
                        
                        Fraction f1 = new Fraction(n1, d1);
                        Fraction f2 = new Fraction(n2, d2);
                        Fraction f3 = new Fraction(n3, d3);
                        if ((d1 == 0) || (d2 == 0) || (d3 == 0))
                        {
                            Console.WriteLine("Знаменатель не должен быть равен нулю. Проверьте корректность ввода.");
                            Environment.Exit(0);
                        }

                        Console.WriteLine("Введите целое число: ");
                        int intnumber = Convert.ToInt32(Console.ReadLine());

                        // Примеры использования методов
                        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
                        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
                        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
                        Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
                        Console.WriteLine($"{f1} + {intnumber} = {f1 + intnumber}");
                        Console.WriteLine($"{f1} - {intnumber} = {f1 - intnumber}");
                        Console.WriteLine($"{f1} * {intnumber} = {f1 * intnumber}");
                        Console.WriteLine($"{f1} / {intnumber} = {f1 / intnumber}");

                        // f1.sum(f2).div(f3).minus(5)
                        Fraction result = (f1 + f2) / f3 - 5;
                        Console.WriteLine($"({f1} + {f2}) / {f3} - 5 = {result}");

                        // Сравнение дробей
                        Console.WriteLine("Введите 4 дробь в формате n/d ");
                        string dr4 = Console.ReadLine();
                        TryParseFraction(dr4, out int n4, out int d4);
                        Fraction f4 = new Fraction(n4, d4);
                        Console.WriteLine($"{f1} == {f4}: {f1.Equals(f4)}");

                        // Клонирование дроби
                        Fraction f5 = (Fraction)f1.Clone();
                        Console.WriteLine($"Клон {f1}: {f5}");

                        // Вещественное значение дроби
                        Console.WriteLine($"Вещественное значение {f1}: {f1.ToDouble()}");

                        Console.WriteLine("\nВведите новое значение для 1 дроби в формате n/d ");
                        string dr5 = Console.ReadLine();
                        TryParseFraction(dr5, out int n5, out int d5);
                        if ((d5 == 0))
                        {
                            Console.WriteLine("Знаменатель не должен быть равен нулю. Проверьте корректность ввода.");
                            Environment.Exit(0);
                        }
                        f1.SetNewValues(n5, d5);
                        Console.WriteLine($"Новое вещественное значение {f1}: {f1.ToDouble()}");
                        Console.WriteLine("\nВведите новое значение для 1 дроби в формате n/d ");
                        string dr6 = Console.ReadLine();
                        TryParseFraction(dr6, out int n6, out int d6);
                        if ((d6 == 0))
                        {
                            Console.WriteLine("Знаменатель не должен быть равен нулю. Проверьте корректность ввода.");
                            Environment.Exit(0);
                        }
                        f1.SetNewValues(n6, d6);
                        Console.WriteLine($"Новое вещественное значение {f1}: {f1.ToDouble()}");

                    }
                    catch
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                    break;
                default:
                    Console.WriteLine("Такого номера нет или вы нажали лишний раз на пробел.");
                    break;
            }
        }
    }
}
          