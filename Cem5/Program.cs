using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cem5
{
    class Program
    {
        static double Func(double x, double y) => (1 - x) * (1 - x) + 100 * (y - x * x) * (y - x * x);

        static void Main(string[] args)
        {
            double x = 3.0, y = 4.0, l = 0.00001, h = 0.01;
            double xnew, ynew;
            for (int i = 0; i < 82000; i++)
            {
                xnew = x - l * (Func(x + h, y) - Func(x, y)) / h;
                ynew = y - l * (Func(x, y + h) - Func(x, y)) / h;
                x = xnew; y = ynew;
            }
            Console.WriteLine("Градиент\nx={0:f4}   y={1:f4}    Func={2:f4}", x, y, Func(x, y));
            Console.ReadKey();

            x = 3.0; y = 4.0; l = 0.00001; h = 0.01; xnew = 3.0; ynew = 4.0;
            double dx=0.0, dy=0.0;
            bool whee = true;
            for (int i = 0; i < 82000; i++)
            {
                if (Func(x, y) > Func(xnew, ynew))
                {
                    whee = false;
                }
                else
                {
                    whee = true;
                }
                if (whee)
                {
                    dx = l * (Func(x + h, y) - Func(x, y)) / h;
                    dy = l * (Func(x, y + h) - Func(x, y)) / h;
                }
                xnew = x - dx;
                ynew = y - dy;
                
                x = xnew; y = ynew;
            }
            Console.WriteLine("Наискорейший спуск\nx={0:f4}   y={1:f4}    Func={2:f4}", x, y, Func(x, y));
            Console.ReadKey();
        }
    }
}
