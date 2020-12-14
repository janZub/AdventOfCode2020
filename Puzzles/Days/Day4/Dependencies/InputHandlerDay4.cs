using System.Collections.Generic;

namespace Puzzles.Day4
{
    public class InputHandlerDay4
    {
        public List<IPassportDay4> CreatePassports4aFromInput(List<string> passportData)
        {
            var passportList = new List<IPassportDay4>();
            foreach (var data in passportData)
                passportList.Add(new PassportDay4a(data));

            return passportList;
        }
        public List<IPassportDay4> CreatePassports4bFromInput(List<string> passportData)
        {
            var passportList = new List<IPassportDay4>();
            foreach (var data in passportData)
                passportList.Add(new PassportDay4b(data, new PassportPropertyValidator()));

            return passportList;
        }
        public List<string> ConvertListToPassportDataList(List<string> lines)
        {
            var singlePassportLines = new List<string>();
            var passportData = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                singlePassportLines.Add(lines[i]);
                if (string.IsNullOrWhiteSpace(lines[i]) || (i + 1 == lines.Count))
                {
                    var data = JoinPassportData(singlePassportLines);
                    passportData.Add(data);
                    singlePassportLines = new List<string>();
                }

            }
            return passportData;
        }
        private string JoinPassportData(List<string> list)
        {
            list.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            var data = string.Join(" ", list);
            return data;
        }

    }
}