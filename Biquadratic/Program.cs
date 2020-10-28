using System;

namespace Lab1
{
    class Biquadratic
    {
        public static void Read(double[] coeff)
        {
            Console.WriteLine("Enter coefficients splitted by spaces");

            string line = Console.ReadLine();
            string[] split_line = line.Split(' ');

            while (split_line.Length != 3)
            {
                Console.WriteLine("Your input is incorrect, try again.");

                line = Console.ReadLine();
                split_line = line.Split(' ');
            }

            while (!double.TryParse(split_line[0], out coeff[0]))
            {
                Console.Write("First coefficient is incorrect, try again.");
                line = Console.ReadLine();
                split_line[0] = line.Split(' ')[0];
            }

            while (!double.TryParse(split_line[1], out coeff[1]))
            {
                Console.Write("Second coefficient is incorrect, try again.");
                line = Console.ReadLine();
                split_line[1] = line.Split(' ')[0];
            }

            while (!double.TryParse(split_line[2], out coeff[2]))
            {
                Console.Write("Third coefficient is incorrect, try again.");
                line = Console.ReadLine();
                split_line[2] = line.Split(' ')[0];
            }
        }

        public static double[] Solution(in double[] coeff)
        {
            if (coeff[0] == 0)
            {
                if ((-coeff[2]) * coeff[1] >= 0 && coeff[1] != 0)
                {
                    double sol = Math.Sqrt(-coeff[2] / coeff[1]);
                    return sol is 0 ? new double[1] { sol } :
                                      new double[2] { sol, -sol };
                }

                if (coeff[1] is 0 && coeff[2] is 0)
                {
                    return new double[1] { double.PositiveInfinity };
                }
                return new double[0];
            }

            double dis = coeff[1] * coeff[1] - 4 * coeff[0] * coeff[2];

            if (dis < 0)
            {
                return new double[0];
            }

            double[] roots;
            double res1 = (-coeff[1] + Math.Sqrt(dis)) / (2.0 * coeff[0]);

            if (res1 >= 0)
            {
                double sol = Math.Sqrt(res1);
                roots = sol is 0 ? new double[1] { sol } :
                                   new double[2] { sol, -sol };
            }
            else
            {
                roots = new double[0];
            }

            if (dis is 0)
            {
                return roots;
            }

            double res2 = (-coeff[1] - Math.Sqrt(dis)) / (2.0 * coeff[0]);

            if (res2 >= 0)
            {
                double sol = Math.Sqrt(res2);
                if (sol is 0)
                {
                    Array.Resize(ref roots, roots.Length + 1);
                    roots[roots.Length - 1] = sol;
                }
                else
                {
                    Array.Resize(ref roots, roots.Length + 2);
                    roots[roots.Length - 2] = sol;
                    roots[roots.Length - 1] = -sol;
                }
            }

            return roots;
        }
        public static void ColorWrite(in double[] roots)
        {
            if (roots.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This biquadratic doesn't have solutions");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;

            if (double.IsInfinity(roots[0]))
            {
                Console.WriteLine("Biquadratic has infinity solutions");
            }
            else
            {
                for (int i = 0; i < roots.Length; ++i)
                {
                    Console.WriteLine("x" + i + " = " + roots[i]);
                }
            }
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Дудник Максим, ИУ5-33Б");

            double[] coeff = new double [3];

            if (args.Length == 3)
            {
                if (!double.TryParse(args[0], out coeff[0])
                    || !double.TryParse(args[1], out coeff[1])
                    || !double.TryParse(args[2], out coeff[2]))
                {
                    Console.WriteLine("Incorrect coefficients from comand line");
                    Biquadratic.Read(coeff);
                }
            }
            else
            {
                Biquadratic.Read(coeff);
            }

            double[] roots = Biquadratic.Solution(in coeff);
            Biquadratic.ColorWrite(in roots);
        }
    }
}

