namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2022, "") { }

    protected override string SolvePartOne()
    {
        var rounds = Input.SplitByNewline();
        var totalScore = rounds.Sum(round => round[2] switch
        {
            //rock
            'X' => 1 + round[0] switch
            {
                //rock
                'A' => 3,
                //paper
                'B' => 0,
                //scissors
                'C' => 6,
                _ => 0
            },
            //paper
            'Y' => 2 + round[0] switch
            {
                //rock
                'A' => 6,
                //paper
                'B' => 3,
                //scissors
                'C' => 0,
                _ => 0
            },
            //scissors
            'Z' => 3 + round[0] switch
            {
                //rock
                'A' => 0,
                //paper
                'B' => 6,
                //scissors
                'C' => 3,
                _ => 0
            },
            _ => 0
        });
        return totalScore.ToString();
    }

    protected override string SolvePartTwo()
    {
        var rounds = Input.SplitByNewline();
        var totalScore = rounds.Sum(round => round[2] switch
        {
            //loose
            'X' => 0 + round[0] switch
            {
                //rock
                'A' => 3,
                //paper
                'B' => 1,
                //scissors
                'C' => 2,
                _ => 0
            },
            //draw
            'Y' => 3 + round[0] switch
            {
                //rock
                'A' => 1,
                //paper
                'B' => 2,
                //scissors
                'C' => 3,
                _ => 0
            },
            //win
            'Z' => 6 + round[0] switch
            {
                //rock
                'A' => 2,
                //paper
                'B' => 3,
                //scissors
                'C' => 1,
                _ => 0
            },
            _ => 0
        });
        return totalScore.ToString();
    }

}
