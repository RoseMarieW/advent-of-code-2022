using AdventOfCode.Solutions.Utils;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2022, "") { }

    protected override string SolvePartOne()
    {
        //Debug = true;
        //var elves = Input.SplitByParagraph();
        //var maxCalories = 0;
        //var highCalorieElf = 0;
        //foreach (var (calories, elf) in elves.Select((calories, elf) => (calories, elf)))
        //{
        //    var elfCalorie = calories.SplitByNewline().Select(int.Parse).Sum();
        //    if (elfCalorie > maxCalories)
        //    {
        //        maxCalories = elfCalorie;
        //        highCalorieElf = elf;
        //    }
        //}
        //return highCalorieElf.ToString();
        //hehe oops overthinking
        Debug = true;
        var elves = Input.SplitByParagraph();
        var maxCalories = 0;
        foreach (var elf in elves)
        {
            var elfCalorie = elf.SplitByNewline().Select(int.Parse).Sum();
            if (elfCalorie > maxCalories)
            {
                maxCalories = elfCalorie;
            }
        }
        return maxCalories.ToString();
    }

    protected override string SolvePartTwo()
    {
        Debug = true;
        var elves = Input.SplitByParagraph();
        var doneElves = new List<int>();
        foreach (var elf in elves)
        {
            var elfCalorie = elf.SplitByNewline().Select(int.Parse).Sum();
            doneElves.Add(elfCalorie);
        }
        //order the elves
        //take the top 3 elves
        //add their values
        
        return doneElves.OrderDescending().Take(3).Sum().ToString();
    }
}
