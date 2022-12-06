using System.Linq;

namespace AdventOfCode.Solutions.Year2022.Day06;

class Solution : SolutionBase
{
    public Solution() : base(06, 2022, "") { }

    protected override string SolvePartOne()
    {
        var dataStreamBuffer = Input;
        var marker = "";
        for (var i = 0; i < dataStreamBuffer.Length; i++)
        {
            if (i < 3)
            {
                marker += (dataStreamBuffer[i]);
            }
            else
            {
                if (marker.Contains(dataStreamBuffer[i]) || marker.Distinct().Count() < 3)
                {
                    marker = marker.Remove(0,1);
                    marker+=(dataStreamBuffer[i]);
                }
                else
                {
                    return (i+1).ToString();
                }
            }
        }

        return "There were no complete markers";
    }

    protected override string SolvePartTwo()
    {
        var dataStreamBuffer = Input;
        var marker = "";
        for (var i = 0; i < dataStreamBuffer.Length; i++)
        {
            if (i < 13)
            {
                marker += (dataStreamBuffer[i]);
            }
            else
            {
                if (marker.Contains(dataStreamBuffer[i]) || marker.Distinct().Count()<13)
                {
                    marker = marker.Remove(0, 1);
                    marker += (dataStreamBuffer[i]);
                }
                else
                {
                    return (i + 1).ToString();
                }
            }
        }

        return "There were no complete markers";
    }
}
