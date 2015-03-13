using System.Collections.Generic;
using System.Linq;

namespace JapaneseCrossword
{
    public class Crossword
    {
        public List<List<int>> RowInfo { get; private set; }

        public List<List<int>> ColInfo { get; private set; }

        public int ColsNumber { get; private set; }

        public int RowsNumber { get; private set; }

        public Cell[][] SolutionGrid { get; private set; }

        public Crossword(List<List<int>> rows, List<List<int>> cols)
        {
            RowInfo = rows;
            RowsNumber = rows.Count;
            ColInfo = cols;
            ColsNumber = cols.Count;
            SolutionGrid = new Cell[RowsNumber][];
            for (int i = 0; i < RowsNumber; i++)
            {
                SolutionGrid[i] = new Cell[ColsNumber];
            }
        }

        public bool IsValid()
        {
            bool goodCellNumber = CheckTotalNumberOfCells();
            bool goodBlockSizes = CheckBlockSizes();
            return goodCellNumber && goodBlockSizes;
        }

        private bool CheckTotalNumberOfCells()
        {
            int verticalCellsNumber = ColInfo.SelectMany(c => c).Aggregate((acc, i) => acc + i);
            int horixontalCellsNumber = RowInfo.SelectMany(r => r).Aggregate((acc, i) => acc + i);
            return verticalCellsNumber == horixontalCellsNumber;
        }

        private bool CheckBlockSizes()
        {
            int maxVerticalLength = ColInfo.SelectMany(c => c).Max();
            int maxHorizontalLength = RowInfo.SelectMany(r => r).Max();
            return (maxHorizontalLength <= ColsNumber) && (maxVerticalLength <= RowsNumber);
        }
    }
}
