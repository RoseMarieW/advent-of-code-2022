namespace AdventOfCode.Solutions.Year2022.Day10;

class Solution : SolutionBase
{
    public Solution() : base(10, 2022, "") { }

    protected override string SolvePartOne()
    {
        //Debug = true;
        var program = Input.SplitByNewline();
        var cycle = 0;
        var x = 1;
        var strengths = 0;
        foreach (var instruction in program)
        {
            var args = instruction.Split(" ");
            if (args[0].Equals("noop"))
            {
                cycle++;
                if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                {
                    strengths += cycle * x;
                }
            }
            else
            {
                for (var i = 0; i < 2; i++)
                {
                    cycle++;
                    if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                    {
                        strengths += cycle * x;
                    }
                    if (i == 1)
                    {
                        x += int.Parse(args[1]);
                    }
                }
            }
        }

        return strengths.ToString();
    }

    protected override string SolvePartTwo()
    {
        var program = Input.SplitByNewline();
        var cycle = 0;
        var x = 1;
        var output = "\n";
        foreach (var instruction in program)
        {
            var args = instruction.Split(" ");
            if (args[0].Equals("noop"))
            {
                
                if (cycle == x || cycle == x - 1 || cycle == x + 1)
                {
                    output += "#";
                }
                else
                {
                    output += ".";
                }
                cycle++;
                if (cycle == 40)
                {
                    output += "\n";
                    cycle = 0;
                }
            }
            else
            {
                for (var i = 0; i < 2; i++)
                {
                    
                    if (cycle == x || cycle == x - 1 || cycle == x + 1)
                    {
                        output += "#";
                    }
                    else
                    {
                        output += ".";
                    }
                    cycle++;
                    if (cycle == 40)
                    {
                        output += "\n";
                        cycle = 0;
                    }
                    if (i == 1)
                    {
                        x += int.Parse(args[1]);
                    }
                }
            }
        }

        return output;
    }
}
