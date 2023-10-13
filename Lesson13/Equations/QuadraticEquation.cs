using Lesson13.Exceptions;

namespace Lesson13.Equations
{
    static class QuadraticEquation
    {
        private static Random random = new();

        public static string CalculateQuadraticEquation(double a, double b, double c)
        {
            Task.Delay(random.Next(10, 1000)).Wait();

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

        public static string CalculateQuadraticEquationVieta(double a, double b, double c)
        {
            Task.Delay(random.Next(10, 1000)).Wait();

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

            throw new RootException("x not found");
        }
    }
}
