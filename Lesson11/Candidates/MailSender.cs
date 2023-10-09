namespace Lesson11.Candidates
{
    static class MailSender
    {
        public static void SendMessageConfirmation(Candidate candidate, double salary)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"MESSAGE SENT: Congratulations {candidate.Name}, you've been hired with salary: {salary}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void SendMessageDecline(Candidate candidate)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"MESSAGE SENT: Sorry {candidate.Name}, you did not get a job");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
