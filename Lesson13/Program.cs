using Lesson13.Equations;
using Lesson13.Exceptions;

namespace Lesson13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();

            double a = 1;

            Task<string>[] tasks = new Task<string>[2];

            for (int j = 0; j < 50; j++)
            {
                double b = random.Next(-20, 20);
                double c = random.Next(-20, 20);

                try
                {
                    Task<string> task1 = Task.Run(() => QuadraticEquation.CalculateQuadraticEquation(a, b, c));
                    Task<string> task2 = Task.Run(() => QuadraticEquation.CalculateQuadraticEquationVieta(a, b, c));

                    tasks[0] = task1;
                    tasks[1] = task2;

                    var taskCompletedId = Task.WaitAny(tasks);
                    Console.WriteLine(tasks[taskCompletedId].Result);
                }

                catch (RootException e)
                {
                    Console.WriteLine(tasks[0].Result);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}