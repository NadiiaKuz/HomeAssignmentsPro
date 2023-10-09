using Lesson11.Candidates;
using Lesson11.QuadraticEquation;

namespace Lesson11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(ProcessEquations);
            thread.Start();

            ProcessCandidates();

            Console.WriteLine("All letters have been sent");
        }

        static void ProcessCandidates()
        {
            var candidates = new List<Candidate>()
            {
                new Candidate("Maria", 2006, 2.1),
                new Candidate("Paul", 2000, 3.2),
                new Candidate("Mark", 1997, 0.3),
                new Candidate("Sarah", 1999, 5.6),
                new Candidate("Sonya", 2000, 7),
                new Candidate("John", 1977, 15.2),
                new Candidate("Mona", 1967, 15),
                new Candidate("Connor", 1999, 5)
            };

            var result = EmployeeDepartment.ApproveApplication(2, candidates);

            foreach (var candidate in result)
            {
                Thread thread = candidate.Value ? new Thread(() => MailSender.SendMessageConfirmation(candidate.Key, 200000)) :
                    new Thread(() => MailSender.SendMessageDecline(candidate.Key));

                thread.IsBackground = true;
                thread.Start();
                thread.Join();
                Thread.Sleep(500);
            }
        }

        static void ProcessEquations()
        {
            Random random = new();

            for (int j = 0; j < 100; j++)
            {
                int a = random.Next(-20, 20);
                int b = random.Next(-20, 20);
                int c = random.Next(-20, 20);

                Console.WriteLine(QuadraticEquationSolver.GetResult(a, b, c));

                Thread.Sleep(5);
            }
        }
    }
}