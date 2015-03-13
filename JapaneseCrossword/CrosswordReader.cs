using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JapaneseCrossword
{
    public static class CrosswordReader
    {
        public static Crossword ReadCrossword(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                var rowsInfo = GetNextData(stream).ToList();
                var colsInfo = GetNextData(stream).ToList();
                var cross = new Crossword(rowsInfo, colsInfo);
                return cross;
            }
        }

        private static IEnumerable<List<int>> GetNextData(TextReader stream)
        {
            var blockInfo = stream.ReadLine();
            var blockNumber = int.Parse(Regex.Match(blockInfo, @"\w+:(\d+)").Groups[1].Value);
            for (int i = 0; i < blockNumber; i++)
            {
                yield return stream.ReadLine().Split(' ').Select(int.Parse).ToList();
            }
        }
    }
}
