using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sharp_lab6
{
    public class Cat : IMeowable
    {
        // Имя кота
        private string Name;

        // Конструктор для создания кота с указанием имени
        public Cat(string name)
        {
            Name = name;
        }

        // Переопределение метода ToString для представления кота в текстовой форме
        public override string ToString()
        {
            return $"кот: {Name}";
        }

        // Метод для мяуканья один раз
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу");
        }

        // Метод для мяуканья N раз
        public void Meow(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine($"{Name}: Кот не может мяукать {count} раз(а).");
                return;
            }

            string meows = ($"{string.Join(" ", Enumerable.Repeat("мяу", count))}");
            Console.WriteLine($"{Name}: {meows}");
        }
    }
}
