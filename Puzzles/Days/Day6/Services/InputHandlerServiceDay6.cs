using System;
using System.Collections.Generic;

namespace Puzzles.Day6
{
    public class InputHandlerServiceDay6
    {
        public List<IGroupDay6> CreateGroup6aFromInput(List<string> input)
        {
            var groups = new List<IGroupDay6>();
            foreach (var gr in input)
                groups.Add(new GroupDay6a(gr));

            return groups;
        }
        public List<IGroupDay6> CreateGroup6bFromInput(List<Tuple<string,int>> input)
        {
            var groups = new List<IGroupDay6>();
            foreach (var gr in input)
                groups.Add(new GroupDay6b(gr.Item1, gr.Item2));

            return groups;
        }
        public List<Tuple<string,int>> ConvertListToGroupDataList(List<string> lines)
        {
            var singlGroupLines = new List<string>();
            var groupsData = new List<Tuple<string, int>>();

            for (int i = 0; i < lines.Count; i++)
            {
                singlGroupLines.Add(lines[i]);
                if (string.IsNullOrWhiteSpace(lines[i]) || (i + 1 == lines.Count))
                {
                    var data = JoinPassportData(singlGroupLines);
                    groupsData.Add(new Tuple<string,int>(data, singlGroupLines.Count));
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