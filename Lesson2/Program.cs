namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
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
                if (candidate.Value)
                    MailSender.SendMessageConfirmation(candidate.Key, 200000);
                else
                    MailSender.SendMessageDecline(candidate.Key);
            }
        }
    }
}