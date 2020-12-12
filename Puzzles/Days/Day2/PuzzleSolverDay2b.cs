using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PuzzleSolverDay2b
    {
        public int GetNumberOfValidPasswords(List<PasswordPolicyDay2b> policies)
        {
            int result = 0;
            foreach (var policy in policies)
            {
                if (ChekIfPolicyWorks(policy))
                    result += 1;
            }
            return result;
        }
        private bool ChekIfPolicyWorks(PasswordPolicyDay2b policy)
        {
            var occurrences = GetNumberOfOccurrence(policy);
            return occurrences == 1;
        }
        private int GetNumberOfOccurrence(PasswordPolicyDay2b policy)
        {
            var numberOfOccurrencesAtPositions = 0;
            foreach (var occ in policy.Occurrences)
            {
                if (policy.Password.ElementAt(occ - 1).ToString() == policy.Letter)
                    numberOfOccurrencesAtPositions += 1;
            }
            return numberOfOccurrencesAtPositions;
        }
    }
}