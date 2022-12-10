namespace AdventOfCode.Solutions.Year2022.Day09;

class Solution : SolutionBase
{
    public Solution() : base(09, 2022, "") { }

    protected override string SolvePartOne()
    {
        //Debug = true;
        var instructions = Input.SplitByNewline();
        //a list that doesnt duplicate when adds are made
        HashSet<(int x, int y)> tail = new();
        List<(int x, int y)> rope = new()
        {
            (0, 0),
            (0, 0)
        };

        foreach (var instruction in instructions)
        {
            var args = instruction.Split(" ");
            var totalDistance = int.Parse(args[1]);
            for (var move = totalDistance; move > 0; move--)
            {
                if (args[0] == "R")
                {
                    rope[0] = (rope[0].x + 1, rope[0].y);
                    if (Math.Abs(rope[1].x - rope[0].x) > 1 || Math.Abs(rope[1].y - rope[0].y) > 1)
                    {
                        rope[1] = (rope[1].x + Math.Sign(rope[0].x - rope[1].x), rope[1].y + Math.Sign(rope[0].y - rope[1].y));
                    }
                }
                if (args[0] == "L")
                {
                    rope[0] = (rope[0].x - 1, rope[0].y);
                    if (Math.Abs(rope[1].x - rope[0].x) > 1 || Math.Abs(rope[1].y - rope[0].y) > 1)
                    {
                        rope[1] = (rope[1].x + Math.Sign(rope[0].x - rope[1].x), rope[1].y + Math.Sign(rope[0].y - rope[1].y));
                    }
                }
                if (args[0] == "U")
                {
                    rope[0] = (rope[0].x, rope[0].y +1);
                    if (Math.Abs(rope[1].x - rope[0].x) > 1 || Math.Abs(rope[1].y - rope[0].y) > 1)
                    {
                        rope[1] = (rope[1].x + Math.Sign(rope[0].x - rope[1].x), rope[1].y + Math.Sign(rope[0].y - rope[1].y));
                    }
                }
                if (args[0] == "D")
                {
                    rope[0] = (rope[0].x, rope[0].y -1);
                    if (Math.Abs(rope[1].x - rope[0].x) > 1 || Math.Abs(rope[1].y - rope[0].y) > 1)
                    {
                        rope[1] = (rope[1].x + Math.Sign(rope[0].x - rope[1].x), rope[1].y + Math.Sign(rope[0].y - rope[1].y));
                    }
                }

                tail.Add(rope[1]);
            }
        }
        return tail.Count.ToString();
    }

    protected override string SolvePartTwo()
    {
        //Debug = true;
        var instructions = Input.SplitByNewline();
        //a list that doesnt duplicate when adds are made
        HashSet<(int x, int y)> tail = new();
        List<(int x, int y)> rope = new()
        {
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
        };

        foreach (var instruction in instructions)
        {
            var args = instruction.Split(" ");
            var totalDistance = int.Parse(args[1]);
            for (var move = totalDistance; move > 0; move--)
            {
                if (args[0] == "R")
                {
                    rope[0] = (rope[0].x + 1, rope[0].y);

                    for (var i = 1; i < 10; i++)
                    {
                        if (Math.Abs(rope[i].x - rope[i - 1].x) > 1 || Math.Abs(rope[i].y - rope[i - 1].y) > 1)
                        {
                            rope[i] = (rope[i].x + Math.Sign(rope[i - 1].x - rope[i].x), rope[i].y + Math.Sign(rope[i - 1].y - rope[i].y));
                        }
                    }
                }
                if (args[0] == "L")
                {
                    rope[0] = (rope[0].x - 1, rope[0].y);
                    for (var i = 1; i < 10; i++)
                    {
                        if (Math.Abs(rope[i].x - rope[i - 1].x) > 1 || Math.Abs(rope[i].y - rope[i - 1].y) > 1)
                        {
                            rope[i] = (rope[i].x + Math.Sign(rope[i - 1].x - rope[i].x), rope[i].y + Math.Sign(rope[i - 1].y - rope[i].y));
                        }
                    }
                }
                if (args[0] == "U")
                {
                    rope[0] = (rope[0].x, rope[0].y + 1);
                    for (var i = 1; i < 10; i++)
                    {
                        if (Math.Abs(rope[i].x - rope[i - 1].x) > 1 || Math.Abs(rope[i].y - rope[i - 1].y) > 1)
                        {
                            rope[i] = (rope[i].x + Math.Sign(rope[i - 1].x - rope[i].x), rope[i].y + Math.Sign(rope[i - 1].y - rope[i].y));
                        }
                    }
                }
                if (args[0] == "D")
                {
                    rope[0] = (rope[0].x, rope[0].y - 1);
                    for (var i = 1; i < 10; i++)
                    {
                        if (Math.Abs(rope[i].x - rope[i - 1].x) > 1 || Math.Abs(rope[i].y - rope[i - 1].y) > 1)
                        {
                            rope[i] = (rope[i].x + Math.Sign(rope[i - 1].x - rope[i].x), rope[i].y + Math.Sign(rope[i - 1].y - rope[i].y));
                        }
                    }
                }

                tail.Add(rope.Last());
            }
        }
        return tail.Count.ToString();
    }
}
