namespace Lesson2
{
    class Candidate
    {
        public string Name { get; }
        public ushort YearOfBirth { get; }
        public double Experience { get; }

        public Candidate(string name, ushort yearOfBirth, double experience)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Experience = experience;
        }
    }
}
