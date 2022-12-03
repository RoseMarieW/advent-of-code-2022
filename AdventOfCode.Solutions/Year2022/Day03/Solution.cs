namespace AdventOfCode.Solutions.Year2022.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2022, "") { }

    protected override string SolvePartOne()
    {
        //get input formatted right
        var rucksacks = Input.SplitByNewline();
        var sumOfPriorities = (from rucksack in rucksacks 
            let firstCompartment = rucksack[..(rucksack.Length / 2)] 
            let secondCompartment = rucksack[(rucksack.Length / 2)..]
            select firstCompartment.Intersect(secondCompartment).First() 
            into duplicateItem 
            select GetAlphaValue(duplicateItem)).Sum();

        return sumOfPriorities.ToString();
    }

    protected override string SolvePartTwo()
    {
        //get input formatted right
        var rucksacks = Input.SplitByNewline();
        var sumOfPriorities = 0;

        //a group is three elves
        for (var group = 0; group <= rucksacks.Length-3; group += 3)
        {
            //find duplicate - there is only ever one duplicate
            var duplicateItem = rucksacks[group].Intersect(rucksacks[group + 1]).Intersect(rucksacks[group + 2]).First();
            //count the duplicate's priority value
            sumOfPriorities += GetAlphaValue(duplicateItem);
        }

        return sumOfPriorities.ToString();
    }

    private static int GetAlphaValue(char item)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return alphabet.IndexOf(item)+1;
    }
}
