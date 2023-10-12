using Lesson13.Equations;

namespace Lesson13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();

            double a = 1;

            for (int j = 0; j < 50; j++)
            {
                double b = random.Next(-20, 20);
                double c = random.Next(-20, 20);

                Task<string> task1 = Task.Run(() => QuadraticEquation.CalculateQuadraticEquation(a, b, c));
                Task<string> task2 = Task.Run(() => QuadraticEquationVieta.CalculateQuadraticEquationVieta(a, b, c));

                var taskCompletedId = Task.WaitAny(task1, task2);

                if (taskCompletedId == 0)
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
    }
}