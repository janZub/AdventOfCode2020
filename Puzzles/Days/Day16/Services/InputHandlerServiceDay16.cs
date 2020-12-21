using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Puzzles.Day16
{
    public class InputHandlerServiceDay16
    {
        public RuleDay16 GetNewRule(string rule)
        {
            var pattern = @"([a-z]+\s?[a-z]*)\:\s([\d]+)-([\d]+)\sor\s([\d]+)-([\d]+)";

            var result = Regex.Match(rule, pattern);
            var newRule = new RuleDay16(result.Groups[1].Value);

            newRule.AddRange(int.Parse(result.Groups[2].Value), int.Parse(result.Groups[3].Value));
            newRule.AddRange(int.Parse(result.Groups[4].Value), int.Parse(result.Groups[5].Value));

            return newRule;
        }

        public List<int> GetNewTicketValues(string ticket)
        {
            var newTicket = ticket.Split(',').Select(c => int.Parse(c)).ToList();
            return newTicket;
        }
    }
}