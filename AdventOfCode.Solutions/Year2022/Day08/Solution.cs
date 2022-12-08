using System.Reflection.Metadata;

namespace AdventOfCode.Solutions.Year2022.Day08;

class Solution : SolutionBase
{
    public Solution() : base(08, 2022, "") { }

    protected override string SolvePartOne()
    {
        var rows = Input.SplitByNewline();
        var perimeter =  (2*(rows.Length + rows[0].Length))-4;
        var visible = 0;
            //after solving part two, I feel this solution is wrong but it got me a star soooo maybe not?
        for (int i = 1; i < rows.Length - 1; i++)
        {
            for (int j = 1; j < rows[i].Length - 1; j++)
            {
                var isVisible = false;
                //top
                if (int.Parse(rows[i - 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)) && !isVisible)
                {
                    if (i - 1 == 0)
                    {
                        visible++;
                        isVisible = true;
                    }
                    else
                    {
                        for (int k = i - 1; k > 0; k--)
                        {
                            if (int.Parse(rows[k - 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }
                            else if (k == 1)
                            {
                                visible++;
                                isVisible = true;
                            }
                        }
                    }
                }
                //bellow
                if (int.Parse(rows[i + 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)) && !isVisible)
                {
                    if (i + 1 == rows.Length-1)
                    {
                        visible++;
                        isVisible = true;
                    }
                    else
                    {
                        for (int k = i + 1; k < rows.Length - 1; k++)
                        {
                            if (int.Parse(rows[k + 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)) && !isVisible)
                            {
                                break;
                            }
                            else if (k == rows.Length - 2)
                            {
                                visible++;
                                isVisible = true;
                            }
                        }
                    }
                }
                //left
                if (int.Parse(rows[i].Substring(j-1,  1)) < Int128.Parse(rows[i].Substring(j,  1)) && !isVisible)
                {
                    if (j - 1 == 0)
                    {
                        visible++;
                        isVisible = true;
                    }
                    else
                    {
                        for (int k = j - 1; k > 0; k--)
                        {
                            if (int.Parse(rows[i].Substring(k - 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }
                            else if (k == 1)
                            {
                                visible++;
                                isVisible = true;
                            }
                        }
                    }
                }
                //right
                if (int.Parse(rows[i].Substring(j + 1, 1)) < Int128.Parse(rows[i].Substring(j, 1)) && !isVisible)
                {
                    if (j + 1 == rows[i].Length-1)
                    {
                        visible++;
                    }
                    else
                    {
                        for (int k = j + 1; k < rows[i].Length - 1; k++)
                        {
                            if (int.Parse(rows[i].Substring(k + 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }
                            else if (k == rows[i].Length - 2)
                            {
                                visible++;
                            }
                        }
                    }
                }
            }
        }
        return (perimeter + visible).ToString();
    }

    protected override string SolvePartTwo()
    {
        //Debug = true;
        var rows = Input.SplitByNewline();
        var max = 0;
        for (int i = 1; i < rows.Length - 1; i++)
        {
            for (int j = 1; j < rows[i].Length - 1; j++)
            {
                var leftview = 1;
                var rightview = 1;
                var topview = 1;
                var bottomview = 1;
                //if a tree is on the edge, its scenic score will be zero right?
                //top
                if (int.Parse(rows[i - 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (int k = i - 1; k > 0; k--)
                        {
                            topview++;
                        if (int.Parse(rows[k - 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                
                                break;
                            }
                        
                        }
                }
                //bellow
                if (int.Parse(rows[i + 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                    
                        for (int k = i + 1; k < rows.Length - 1; k++)
                        {
                            bottomview++;
                             if (int.Parse(rows[k + 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                
                                break;
                            }
                        
                        }
                }
                //left
                if (int.Parse(rows[i].Substring(j - 1, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (int k = j - 1; k > 0; k--)
                        {
                            leftview++;
                            if (int.Parse(rows[i].Substring(k - 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                               
                                break;
                            }
                        }
                    
                }
                //right
                if (int.Parse(rows[i].Substring(j + 1, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (int k = j + 1; k < rows[i].Length - 1; k++)
                        {
                            rightview++;
                            if (int.Parse(rows[i].Substring(k + 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }
                        }
                    
                }
                
                var scenic = bottomview * rightview * leftview * topview;
                //Console.WriteLine(rightview + " b " + scenic);
                if (max < scenic)
                {
                    max = scenic;
                }
            }
        }
        return (max).ToString();
    }
}
