namespace Lesson2
{
    class MyComparer : IComparer<Candidate>
    {
        public int Compare(Candidate x, Candidate y) =>
            y.Experience.CompareTo(x.Experience);
    }
}
