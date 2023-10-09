namespace Lesson11.QuadraticEquation
{
    static class QuadraticEquationSolver
    {
        public static string GetResult(int a, int b, int c)
        {
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

            return $"x not found";
        }
    }
}
