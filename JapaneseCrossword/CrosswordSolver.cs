using System;
using System.IO;

namespace JapaneseCrossword
{
    public abstract class CrosswordSolver : ICrosswordSolver
    {
        protected Crossword cross;

        protected bool ValidateInputPath(string inputFilePath)
        {
            try
            {
                cross = CrosswordReader.ReadCrossword(inputFilePath);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is IOException || e is ArgumentNullException)
                    return false;
                throw;
            }
            return true;
        }

        public abstract SolutionStatus Solve(string inputFilePath, string outputFilePath);
    }
}