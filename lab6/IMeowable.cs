using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_lab6
{
    public interface IMeowable
    {
        void Meow();
        void Meow(int n);
    }
    public class MeowManager
    {
        public static void MakeAllMeow(IEnumerable<IMeowable> meowables)
        {
            foreach (var meowable in meowables)
            {
                meowable.Meow();
            }
        }
    }
}
