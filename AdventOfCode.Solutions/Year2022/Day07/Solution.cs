namespace AdventOfCode.Solutions.Year2022.Day07;

class Solution : SolutionBase
{
    public Solution() : base(07, 2022, "") { }

    protected override string SolvePartOne()
    {
        var terminal = Input.SplitByNewline();
        var directory = new Dictionary<string, int>();
        var path = "";
        foreach (var (line,index) in terminal.Select((line, index) => (line, index)))
        {
            var instructions  = line.Split();
            if (instructions[0].Equals("$"))
            {
                var command = instructions[1];
                var args = instructions.Length > 2 ? instructions[2] : "";
                switch (command)
                {
                    case "cd":
                        //Path is nice path makes me not have to think about structure thanks https://zetcode.com/csharp/path/
                        path = Path.GetFullPath(Path.Combine(path, args));
                        break;
                    case "ls":
                    {
                        //the following files until the next instruction
                            var files = terminal
                            .Skip(index + 1)
                            .TakeWhile(file => file[0] != '$');
                        var sum = 0;
                        //only count size of the files not the directory
                        foreach (var file in files)
                        {
                            var size = file.Split(' ')[0];
                            if (size.All(char.IsDigit))
                            {
                                sum += int.Parse(size);
                            }
                        }
                        directory.TryAdd(path, sum);
                        break;
                    }
                }
            }
        }
        //sum the subfile values
        foreach (var root in directory)
        foreach (var child in directory
                     .Where(child => root.Key != child.Key)
                     .Where(child => child.Key.StartsWith(root.Key)))
            directory[root.Key] += child.Value;
        return directory.Where(file => file.Value <= 100000)
            .Sum(file => file.Value).ToString();
    }

    protected override string SolvePartTwo()
    {
        var terminal = Input.SplitByNewline();
        var directory = new Dictionary<string, int>();
        var path = "";
        foreach (var (line, index) in terminal.Select((line, index) => (line, index)))
        {
            var instructions = line.Split();
            if (instructions[0].Equals("$"))
            {
                var command = instructions[1];
                var args = instructions.Length > 2 ? instructions[2] : "";
                switch (command)
                {
                    case "cd":
                        path = Path.GetFullPath(Path.Combine(path, args));
                        break;
                    case "ls":
                    {
                        var files = terminal
                            .Skip(index + 1)
                            .TakeWhile(file => file[0] != '$');
                        var sum = 0;
                        foreach (var file in files)
                        {
                            var size = file.Split(' ')[0];
                            if (size.All(char.IsDigit))
                            {
                                sum += int.Parse(size);
                            }
                        }
                        directory.TryAdd(path, sum);
                        break;
                    }
                }
            }
        }
        //sum the subfile values
        foreach (var root in directory)
        foreach (var child in directory
                     .Where(child => root.Key != child.Key)
                     .Where(child => child.Key.StartsWith(root.Key)))
            directory[root.Key] += child.Value;

        //total used spaced "/" is root
        var total = directory["C:\\"];
        var moreSpaceNeeded = 30000000 - (70000000 - total);

        //smallest directory that gets desired space
        return directory.Where(file => file.Value >= moreSpaceNeeded)
            .Min(file => file.Value).ToString();
    }
}
