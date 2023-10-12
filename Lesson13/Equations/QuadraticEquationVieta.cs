namespace Lesson13.Equations
{
    static class QuadraticEquationVieta
    {
        public static string CalculateQuadraticEquationVieta(double a, double b, double c)
        {
            Random random = new();
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

            return "x not found";
        }
    }
}
