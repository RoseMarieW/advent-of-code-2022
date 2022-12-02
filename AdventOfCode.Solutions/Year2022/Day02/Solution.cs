namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2022, "") { }

    protected override string SolvePartOne()
    {
        var rounds = Input.SplitByNewline();
        var totalScore = 0;
        foreach (var round in rounds)
        {
            var score = 0;
            //rock
            if (round[2] == 'X')
            {
                score = 1 + round[0] switch
                {
                    //rock
                    'A' => 3,
                    //paper
                    'B' => 0,
                    //scissors
                    'C' => 6,
                    _ => 0
                };
            }
            //paper
            else if (round[2] == 'Y')
            {
                score = 2 + round[0] switch
                {
                    //rock
                    'A' => 6,
                    //paper
                    'B' => 3,
                    //scissors
                    'C' => 0,
                    _ => 0
                };
            }
            //scissors
            else if (round[2] == 'Z')
            {
                score = 3 + round[0] switch
                {
                    //rock
                    'A' => 0,
                    //paper
                    'B' => 6,
                    //scissors
                    'C' => 3,
                    _ => 0
                };
            }

            totalScore += score;
        }
        return totalScore.ToString();
    }

    protected override string SolvePartTwo()
    {
        var rounds = Input.SplitByNewline();
        var totalScore = 0;
        foreach (var round in rounds)
        {
            var score = 0;
            //loose
            if (round[2] == 'X')
            {
                score = 0 + round[0] switch
                {
                    //rock
                    'A' => 3,
                    //paper
                    'B' => 1,
                    //scissors
                    'C' => 2,
                    _ => 0
                };
            }
            //draw
            else if (round[2] == 'Y')
            {
                score = 3 + round[0] switch
                {
                    //rock
                    'A' => 1,
                    //paper
                    'B' => 2,
                    //scissors
                    'C' => 3,
                    _ => 0
                };
            }
            //win
            else if (round[2] == 'Z')
            {
                score = 6 + round[0] switch
                {
                    //rock
                    'A' => 2,
                    //paper
                    'B' => 3,
                    //scissors
                    'C' => 1,
                    _ => 0
                };
            }

            totalScore += score;
        }
        return totalScore.ToString();
    }

}
