using System.Collections.Generic;

namespace Puzzles.Day6
{
    public class InputHandlerServiceDay6
    {
        public List<GroupDay6> CreateGroupsFromInput(List<string> input)
        {
            var groups = new List<GroupDay6>();
            foreach (var gr in input)
                groups.Add(new GroupDay6(gr));

            return groups;
        }

        public List<string> ConvertListToGroupDataList(List<string> lines)
        {
            var singlGroupLines = new List<string>();
            var groupsData = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                singlGroupLines.Add(lines[i]);
                if (string.IsNullOrWhiteSpace(lines[i]) || (i + 1 == lines.Count))
                {
                    var data = JoinPassportData(singlGroupLines);
                    groupsData.Add(data);
                    singlGroupLines = new List<string>();
                }
            }
            return groupsData;
        }

        private string JoinPassportData(List<string> list)
        {
            list.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            var data = string.Join("", list);
            return data;
        }

    }
}