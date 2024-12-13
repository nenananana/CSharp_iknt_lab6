using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_lab6
{
    public interface IFraction
    {
        double ToDouble(); 
        void SetNewValues(int numerator, int denominator); 
    }
    public interface ICloneable
    {
        object Clone();
    }
}
