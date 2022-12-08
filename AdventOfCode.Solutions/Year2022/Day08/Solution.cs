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
        for (var i = 1; i < rows.Length - 1; i++)
        {
            for (var j = 1; j < rows[i].Length - 1; j++)
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
                        for (var k = i - 1; k > 0; k--)
                        {
                            if (int.Parse(rows[k - 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }

                            if (k != 1) continue;
                            visible++;
                            isVisible = true;
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
                        for (var k = i + 1; k < rows.Length - 1; k++)
                        {
                            if (int.Parse(rows[k + 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)) && !isVisible)
                            {
                                break;
                            }

                            if (k != rows.Length - 2) continue;
                            visible++;
                            isVisible = true;
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
                        for (var k = j - 1; k > 0; k--)
                        {
                            if (int.Parse(rows[i].Substring(k - 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }

                            if (k != 1) continue;
                            visible++;
                            isVisible = true;
                        }
                    }
                }
                //right
                if (int.Parse(rows[i].Substring(j + 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)) ||
                    isVisible) continue;
                {
                    if (j + 1 == rows[i].Length-1)
                    {
                        visible++;
                    }
                    else
                    {
                        for (var k = j + 1; k < rows[i].Length - 1; k++)
                        {
                            if (int.Parse(rows[i].Substring(k + 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }

                            if (k == rows[i].Length - 2)
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
        for (var i = 1; i < rows.Length - 1; i++)
        {
            for (var j = 1; j < rows[i].Length - 1; j++)
            {
                var leftView = 1;
                var rightView = 1;
                var topView = 1;
                var bottomView = 1;
                //if a tree is on the edge, its scenic score will be zero right?
                //top
                if (int.Parse(rows[i - 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (var k = i - 1; k > 0; k--)
                        {
                            topView++;
                        if (int.Parse(rows[k - 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                
                                break;
                            }
                        
                        }
                }
                //bellow
                if (int.Parse(rows[i + 1].Substring(j, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                    
                        for (var k = i + 1; k < rows.Length - 1; k++)
                        {
                            bottomView++;
                             if (int.Parse(rows[k + 1].Substring(j, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                
                                break;
                            }
                        
                        }
                }
                //left
                if (int.Parse(rows[i].Substring(j - 1, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (var k = j - 1; k > 0; k--)
                        {
                            leftView++;
                            if (int.Parse(rows[i].Substring(k - 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                               
                                break;
                            }
                        }
                    
                }
                //right
                if (int.Parse(rows[i].Substring(j + 1, 1)) < Int128.Parse(rows[i].Substring(j, 1)))
                {
                   
                        for (var k = j + 1; k < rows[i].Length - 1; k++)
                        {
                            rightView++;
                            if (int.Parse(rows[i].Substring(k + 1, 1)) >= Int128.Parse(rows[i].Substring(j, 1)))
                            {
                                break;
                            }
                        }
                    
                }
                
                var scenic = bottomView * rightView * leftView * topView;
                //Console.WriteLine(rightView + " b " + scenic);
                if (max < scenic)
                {
                    max = scenic;
                }
            }
        }
        return (max).ToString();
    }
}
