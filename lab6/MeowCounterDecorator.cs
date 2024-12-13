using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_lab6
{
    public class MeowCounterDecorator : IMeowable
    {
        private readonly IMeowable _meowable;
        private int _meowCount;

        public MeowCounterDecorator(IMeowable meowable)
        {
            _meowable = meowable;
            _meowCount = 0;
        }

        public void Meow()
        {
            _meowable.Meow();
            _meowCount++;
        }

        public void Meow(int n)
        {
            _meowable.Meow(n);
            _meowCount = _meowCount + n;
        }

        public int GetMeowCount()
        {
            return _meowCount;
        }
    }

}
