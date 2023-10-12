namespace Lesson13.Equations
{
    static class QuadraticEquation
    {
        public static string CalculateQuadraticEquation(double a, double b, double c)
        {
            Random random = new();
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
    }
}
