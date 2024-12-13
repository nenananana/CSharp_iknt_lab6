using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_lab6
{
    public class BigCat : IMeowable
    {
        private string Name { get; }

        public BigCat(string name)
        {
            Name = name;
        }

        public void Meow()
        {
            Console.WriteLine($"{Name}: МЯЯЯЯУ");
        }
        public void Meow(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine($"{Name}: Кот не может мяукать {count} раз(а).");
                return;
            }

            string meows = ($"{string.Join(" ", Enumerable.Repeat("МЯЯЯЯУ", count))}");
            Console.WriteLine($"{Name}: {meows}");
        }
        public override string ToString()
        {
            return $"большой кот: {Name}";
        }
    }
}
