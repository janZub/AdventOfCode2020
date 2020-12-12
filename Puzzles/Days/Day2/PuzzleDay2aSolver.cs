using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PuzzleDay2aSolver
    {
        public int GetNumberOfValidPasswords(List<PasswordPolicy> policies)
        {
            int result = 0;
            foreach (var policy in policies)
            {
                if (ChekIfPolicyWorks(policy))
                    result +=1;
            }
            return result;
        }
        private bool ChekIfPolicyWorks(PasswordPolicy policy)
        {
            var result = Regex.Matches(policy.Password, policy.Letter);
            var checkResult = CheckResult(result, policy);

            return checkResult;
        }
        private bool CheckResult(MatchCollection matches, PasswordPolicy policy)
        {
            return matches.Count <= policy.MaxOccurances
                && matches.Count >= policy.MinOccurances;
        }
    }
}