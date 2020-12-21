using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day16
{
    public class PuzzleSolverDay16
    {
        public ulong GetInvalidNumbers(List<RuleDay16> rules, List<List<int>> ticketsData)
        {
            ulong errorRate = 0;

            foreach (var ticket in ticketsData)
                errorRate += GetErrorRateForTicket(rules, ticket);

            return errorRate;
        }
        public ulong GetErrorRateForTicket(List<RuleDay16> rules, List<int> ticket)
        {
            return (ulong)ticket.Where(n => !rules.Any(r => r.IsNumberValid(n))).Sum();
        }

        public bool IsTicketValid(List<RuleDay16> rules, List<int> ticket)
        {
            return ticket.All(number => rules.Any(r => r.IsNumberValid(number)));
        }
        public List<string> GetValidRulesForNumber(List<RuleDay16> rules, int number)
        {
            return rules.Where(r => r.IsNumberValid(number)).Select(r => r.Name).ToList();
        }
        public List<string>[] GetValidRulesPerField(List<RuleDay16> rules, List<List<int>> validTickets)
        {
            var rulesPerField = new List<string>[rules.Count];
            for (int i = 0; i < rules.Count; i++)
            {
                for (int j = 0; j < validTickets.Count; j++)
                {
                    var validRules = GetValidRulesForNumber(rules, validTickets[j][i]);
                    if (rulesPerField[i] == null)
                        rulesPerField[i] = validRules;
                    else
                        rulesPerField[i] = rulesPerField[i].Intersect(validRules).ToList();
                }
            }
            return rulesPerField;
        }
        public List<string> GetRulesOrder(List<string>[] rulesPerField)
        {
            var determinedFields = new List<string>();
            while (true)
            {
                var foundRule = rulesPerField.FirstOrDefault(e => e.Except(determinedFields).Count() == 1);

                if (foundRule == null)
                    break;

                determinedFields.Add(foundRule.First());

                for (int i = 0; i < rulesPerField.Length; i++)
                {
                    if (rulesPerField[i].Count == 1)
                        continue;

                    rulesPerField[i] = rulesPerField[i].Except(foundRule).ToList();
                }
            }

            return rulesPerField.Select(e => e.First()).ToList();
        }
    }
}