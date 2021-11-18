using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика5
{
    class Program
    {
        public static double Func(double x1, double x2)
        {

            return 132 * x1 * x1 - 256 * x1 * x2 + 132 * x2 * x2 - 51 * x1 - 140 * x2 - 27;
        }

        public static double[] Gradient(double x1, double x2)
        {
            double[] result = new double[2];

            result[0] = 132 * 2 * x1 - 256 * x2 - 51;
            result[1] = 132 * 2 * x2 - 256 * x1 - 140;
            
            return result;
        }

        public static double GradientSum(double[] gradient)
        {
            return Math.Sqrt(gradient[0] * gradient[0] + gradient[1] * gradient[1]);
        }

        static void Main(string[] args)
        {
            double E = 0.001;
            double alpha = 12;//ответ не зависит от начальных значений alpha x1 x2 от них зависит только число итераций цикла
            double x1 = 11;
            double x2 = 11;
            double Fx = Func(x1, x2);
            double y1;
            double y2;
            double Fy;
            double[] gradientF = Gradient(x1, x2);
            int k = 0;

            while(Math.Abs(GradientSum(gradientF)) > E)
            {
                y1 = x1 - alpha * gradientF[0];
                y2 = x2 - alpha * gradientF[1];
                
                Fy = Func(y1, y2);

                if(Fy < Fx)
                {
                    x1 = y1;
                    x2 = y2;
                    Fx = Fy;
                    gradientF = Gradient(x1, x2);
                }
                else
                {
                    alpha /= 2;
                }
                k++;
            }

            Console.WriteLine("метод градиентного спуска");
            Console.WriteLine($"x1 = {x1}\tx2 = {x2}\ty = {Fx}\tk = {k}");
        }
    }
}
