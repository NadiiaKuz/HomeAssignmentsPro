namespace Lesson13
{
    internal class Program
    {
        private static readonly Random random = new();

        static void Main(string[] args)
        {
            double a = 1;

            for (int j = 0; j < 50; j++)
            {
                double b = random.Next(-20, 20);
                double c = random.Next(-20, 20);

                Task<string> task1 = Task.Run(() => CalculateQuadraticEquation(a, b, c));
                Task<string> task2 = Task.Run(() => CalculateQuadraticEquationVieta(a, b, c));

                Task.WhenAny(task1, task2).Wait();

                if (task1.IsCompleted)
                {
                    Console.WriteLine("Standard method: ");
                    Console.WriteLine(task1.Result);
                }
                else
                {
                    Console.WriteLine("Method according to Vieta's theorem:");
                    Console.WriteLine(task2.Result);
                }

                Console.WriteLine();
            }
        }

        static string CalculateQuadraticEquation(double a, double b, double c)
        {
            WaitRandomTime();

            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
                double x2 = (-b - Math.Sqrt(discriminant)) / 2 * a;
                return $"x1={x1} and x2={x2}";
            }

            if (discriminant == 0)
            {
                double x = -b / 2 * a;
                return $"x={x}";
            }

            return "x not found";
        }

        static string CalculateQuadraticEquationVieta(double a, double b, double c)
        {
            WaitRandomTime();

            double sumOfRoots = -b / a;
            double productOfRoots = c / a;

            if (productOfRoots > 0)
            {
                double sqrtProduct = Math.Sqrt(productOfRoots);

                double x1 = (sumOfRoots + sqrtProduct);
                double x2 = (sumOfRoots - sqrtProduct);
                return $"x1={x1} and x2={x2}";
            }
            
            if (productOfRoots == 0)
            {
                double x = sumOfRoots;
                return $"x={x}";
            }

            return "x not found";
        }

        static void WaitRandomTime() =>
            Task.Delay(random.Next(10, 1000)).Wait();
    }
}