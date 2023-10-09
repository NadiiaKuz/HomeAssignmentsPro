namespace Lesson11.Candidates
{
    static class EmployeeDepartment
    {
        public static SortedDictionary<Candidate, bool> ApproveApplication(int quota, IEnumerable<Candidate> candidates)
        {
            var sortedCandidates = new SortedDictionary<Candidate, bool>(new MyComparer());

            int i = 0;
            foreach (var candidate in candidates.OrderByDescending(c => c.Experience))
            {
                sortedCandidates.Add(candidate, i < quota && candidate.Experience > 2 && candidate.YearOfBirth < 2005);
                i++;
            }

            return sortedCandidates;
        }
    }
}
