namespace Lesson11.Candidates
{
    class MyComparer : IComparer<Candidate>
    {
        public int Compare(Candidate x, Candidate y) =>
            y.Experience.CompareTo(x.Experience);
    }
}
