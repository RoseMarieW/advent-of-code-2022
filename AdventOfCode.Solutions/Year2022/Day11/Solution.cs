using System.Runtime.CompilerServices;

namespace AdventOfCode.Solutions.Year2022.Day11;

class Solution : SolutionBase
{
    public Solution() : base(11, 2022, "") { }

    protected override string SolvePartOne()
    {
        //hardcode monkeys
        // Monkey zero = new Monkey(new Queue<long>(new long[] { 79,98 }),"*",19,23,2,3);
        // Monkey one = new Monkey(new Queue<long>(new long[] { 54,65,75,74 }), "+", 6, 19, 2, 0);
        // Monkey two = new Monkey(new Queue<long>(new long[] { 79, 60,97 }), "*", -1, 13, 1, 3);
        // Monkey three = new Monkey(new Queue<long>(new long[] { 74 }), "+", 3, 17, 0, 1);
        // var monkeys = new List<Monkey> { zero, one, two, three };
        Monkey zero = new Monkey(new Queue<long>(new long[] { 83, 62, 93 }), "*", 17, 2, 1, 6);
        Monkey one = new Monkey(new Queue<long>(new long[] { 90, 55 }), "+", 1, 17, 6, 3);
        Monkey two = new Monkey(new Queue<long>(new long[] { 91, 78, 80, 97, 79, 88 }), "+", 3, 19, 7, 5);
        Monkey three = new Monkey(new Queue<long>(new long[] { 64, 80, 83, 89, 59 }), "+", 5, 3, 7, 2);
        Monkey four = new Monkey(new Queue<long>(new long[] { 98, 92, 99, 51 }), "*", -1, 5, 0, 1);
        Monkey five = new Monkey(new Queue<long>(new long[] { 68, 57, 95, 85, 98, 75, 98, 75 }), "+", 2, 13, 4, 0);
        Monkey six = new Monkey(new Queue<long>(new long[] { 74 }), "+", 4, 7, 3, 2);
        Monkey seven = new Monkey(new Queue<long>(new long[] { 68, 64, 60, 68, 87, 80, 82 }), "*", 19, 11, 4, 5);
        var monkeys = new List<Monkey> { zero, one, two, three, four, five, six, seven };

        //smaller by using lcm
        long lcm = monkeys[0].Test;
        for (int i = 1; i < monkeys.Count; i++)
        {
            lcm = (long)CalculationUtils.FindLCM(lcm, monkeys[i].Test);
        }
        for (var i = 0;i<10000;i++) {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    monkey.Inspections++;
                    var worryIncrease = monkey.OperationValue == -1 ? item : monkey.OperationValue;

                    long worryLevel;
                    if (monkey.Operation.Equals("*"))
                    {
                        worryLevel = item * worryIncrease;
                    }
                    else
                    {
                        worryLevel = item + worryIncrease;
                    }

                    //worryLevel /= 3;
                    worryLevel %= lcm;

                    if (worryLevel % monkey.Test == 0)
                    {
                        monkeys[monkey.ThrowA].Items.Enqueue(worryLevel);
                    }
                    else
                    {
                        monkeys[monkey.ThrowB].Items.Enqueue(worryLevel);
                    }
                }
                
                monkey.Items = new Queue<long>();
            }
        }

        var business = monkeys.OrderByDescending(x => x.Inspections).Take(2).ToArray();
        var monkeyBusiness = business[0].Inspections * business[1].Inspections;
        return monkeyBusiness.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }

    private class Monkey
    {
        public Monkey(Queue<long> items, string operation, int operationValue, long test, int throwA, int throwB)
        {
            Items = items;
            Operation = operation;
            OperationValue = operationValue;
            Test = test;
            ThrowA = throwA;
            ThrowB = throwB;
            Inspections = 0;
        }

        public Queue<long> Items { get; set; }
        public string Operation { get; set; }
        public int OperationValue { get; set; }
        public long Test { get; set; }
        public int ThrowA { get; set; }
        public int ThrowB { get; set; }
        public long Inspections { get; set; }
    }
}
