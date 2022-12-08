namespace AdventOfCode.Solutions.Year2022.Day05;

class Solution : SolutionBase
{
    public Solution() : base(05, 2022, "") { }

    protected override string SolvePartOne()
    {
        var parts = Input.SplitByParagraph();
        //first paragraph is current stacks of crates
        var crates = ParseStacks(parts[0]);
        string message = "";

        //paragraph two are the instructions
        foreach (var instruction in parts[1].SplitByNewline())
        {
            //get rid of unneeded move from to
            var parsedInstruction = instruction
                .Replace("move ", "")
                .Replace("from ", "")
                .Replace("to ", "")
                .Split(" ").Select(int.Parse).ToArray();
            //instruction 0 is move, 1 is from, 2 is to
            //offset by one because arrays start at 0 but instructions start at 1
            for (var i = 0; i < parsedInstruction[0]; i++)
            {
                var crate = crates[parsedInstruction[1]-1].Pop();
                crates[parsedInstruction[2]-1].Push(crate);
            }
        }
        foreach(var stack in crates)
        {
            message += stack.Peek();
        }
        return message;
    }

    protected override string SolvePartTwo()
    {
        var parts = Input.SplitByParagraph();
        var crates = ParseStacks(parts[0]);
        string message = "";

        foreach (var instruction in parts[1].SplitByNewline())
        {
            var parsedInstruction = instruction
                .Replace("move ", "")
                .Replace("from ", "")
                .Replace("to ", "")
                .Split(" ").Select(int.Parse).ToArray();
            var liftedCrates = new Stack<char>();
            for (var i = 0; i < parsedInstruction[0]; i++)
            {
                var crate = crates[parsedInstruction[1] - 1].Pop();
                liftedCrates.Push(crate);
                
            }
            //need to maintain order so duplicate the pops
            for (var i = 0; i < parsedInstruction[0]; i++)
            {
                var dropCrate = liftedCrates.Pop();
                crates[parsedInstruction[2] - 1].Push(dropCrate);

            }
            
        }
        foreach (var stack in crates)
        {
            message += stack.Peek();
        }
        return message;
    }

    private List<Stack<char>> ParseStacks(string input)
    {
        var crates = input.SplitByNewline();
        var stacks = new List<Stack<char>>();
        var first = true;
        foreach (var row in crates.Reverse())
        {
            if (first)
            {
                //first row is the index
                for (var i =0; i < row.Length/4+1; i ++)
                {
                    var stack = new Stack<char>();
                    stacks.Add(stack);
                }
                first = false;
                   
            }
            else
            {
                var index = 0;
                //crates are in consistent intervals of 4
                for (var column=1; column < row.Length; column+=4)
                {
                    char crate = row[column];
                    if (crate != ' ')
                    {
                        stacks[index].Push(crate);
                    }

                    index++;
                }
            }
        }

        return stacks;
    }
}
