using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day2
{
    public class PuzzleSolverDay2a
    {
        public int GetNumberOfValidPasswords(List<PasswordPolicyDay2a> policies)
        {
            int result = 0;
            foreach (var policy in policies)
            {
                if (ChekIfPolicyWorks(policy))
                    result +=1;
            }
            return result;
        }
        private bool ChekIfPolicyWorks(PasswordPolicyDay2a policy)
        {
            var result = Regex.Matches(policy.Password, policy.Letter);
            var checkResult = CheckResult(result, policy);

            return checkResult;
        }
        private bool CheckResult(MatchCollection matches, PasswordPolicyDay2a policy)
        {
            return matches.Count <= policy.MaxOccurences
                && matches.Count >= policy.MinOccurences;
        }
    }
}