namespace AdventOfCode.Solutions.Year2022.Day04;

class Solution : SolutionBase
{
    public Solution() : base(04, 2022, "") { }

    protected override string SolvePartOne()
    {
        var pairs = Input.SplitByNewline();
        var count = 0;
        foreach (var pair in pairs)
        {
            var elves = pair.Split(new char[] { ',', '-' })
                .Select(int.Parse)
                .ToArray();
            //elf1 start >= elf2 start and elf1 end <= elf2 end
            //elf1 start <= elf2 start and elf1 end >= elf2 end
            if (elves[0] >= elves[2] && elves[1] <= elves[3] || elves[0] <= elves[2] && elves[1] >= elves[3])
            {
                count++;
            }
        }
        return count.ToString();
    }

    protected override string SolvePartTwo()
    {
        var pairs = Input.SplitByNewline();
        var count = 0;
        foreach (var pair in pairs)
        {
            var elves = pair.Split(new char[] { ',', '-' })
                .Select(int.Parse)
                .ToArray();
            //elf1 start <= elf2 start and elf2 start <= elf1 end
            //elf1 start >= elf2 start and elf1 start <= elf2 end
            if (elves[0] <= elves[2] && elves[2] <= elves[1] 
                || elves[0] >= elves[2] && elves[0] <= elves[3])
            {
                count++;
            }
        }
        return count.ToString();
    }
}
