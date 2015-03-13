using System;
using System.IO;

namespace JapaneseCrossword
{
    public class SimpeCrosswordSolver : CrosswordSolver
    {
        public override SolutionStatus Solve(string inputFilePath, string outputFilePath)
        {
            var correctInputPath = ValidateInputPath(inputFilePath);
            if (!correctInputPath)
                return SolutionStatus.BadInputFilePath;
            var correctCrossword = cross.IsValid();
            if (!correctCrossword)
                return SolutionStatus.IncorrectCrossword;
            return SolutionStatus.PartiallySolved;
        }
    }
}