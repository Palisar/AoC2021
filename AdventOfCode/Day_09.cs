namespace AdventOfCode;

public class Day_09 : BaseDay
{

    private readonly string[] _input;
    private readonly int[,] _numbers;
    private int _rowLength;

    public Day_09()
    {
        _input = File.ReadLines(InputFilePath).ToArray();
        _numbers = new int[_input[0].Length, _input[0].Length];
        int i = 0, j = 0;
        foreach (var item in _input)
        {
            foreach (var number in item)
            {
                _numbers[j, i] = int.Parse(number.ToString());
                j++;
                if (j == item.Length)
                {
                    j = 0;
                }
            }
            i++;
        }
    }

    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_numbers).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_numbers).ToString());
    }
    public static int Part1(int[,] numbers)
    {
        List<int> output = new();
        for (int y = 0; y < numbers.GetLength(0); y++)
        {
            for (int x = 0; x < numbers.GetLength(1); x++)
            {
                if (x == 0 && y == 0)//top left
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && y == 0)//top right
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (y == 0)//first row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (x == 0)// first in each row
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (x == 0 && y == numbers.GetLength(0) - 1)//bottom left
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && !(y == numbers.GetLength(0) -1))//Last in each row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && y == numbers.GetLength(0) - 1) // bottom right
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else if (y == numbers.GetLength(0) - 1) //last row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        output.Add(numbers[y, x]);
                    }
                }
                else// everythign else 
                {
                    if ((numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x]))
                    {
                        output.Add(numbers[y, x]);
                    }
                }
            }
        }
        return output.Sum()+ output.Count;
    }

    public static int Part2(int[,] numbers)
    {
        return 0;
    }

}
