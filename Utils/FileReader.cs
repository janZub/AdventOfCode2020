using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utils
{
    //should not be static, but injectable
    public static class FileReader
    {
        /* ReadFile should be made public and tested
         * 
         * All methods of this method would be public and tested,
         * But we still would write another unit test for this method,
         * with mock of StreamReader.
         */
        public static List<string> ReadFile(string path, string fileName, FileExtensionEnum fileExt)
        {
            var fileNameWithExt = AddExtensionToFileName(fileName, fileExt);
            var fullPath = GetFullPath(path, fileNameWithExt);
            var lines = ReadFile(fullPath);

            return lines;
        }
        public static string AddExtensionToFileName(string fileName, FileExtensionEnum extEnum)
        {
            return string.Format("{0}.{1}", fileName, extEnum.GetDescription());
        }

        public static string GetFullPath(string path, string fileName)
        {
            return string.Format("{0}/{1}", path, fileName);
        }

        /* Should 
         * - make it public
         * - inject StreamReader as dependency to mock it
         * - make unit test
         */
        private static List<string> ReadFile(string fullPath)
        {
            List<string> lines = new List<string>();

            using (var sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                    lines.Add(sr.ReadLine());
            }
            return lines;
        }

    }
}