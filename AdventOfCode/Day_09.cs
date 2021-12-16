namespace AdventOfCode;

public class Day_09 : BaseDay
{

    private readonly string[] _input;
    private readonly int[,] _numbers;

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
        var lowPoints = FindLowPoints(numbers);

        var result = 0;
        foreach (var item in lowPoints)
        {
            result += item.value;
        }
        return result + lowPoints.Count;
    }

    public static List<(int value, Point pos)> FindLowPoints(int[,] numbers)
    {
        var output = new List<(int, Point)>();
        for (int y = 0; y < numbers.GetLength(0); y++)
        {
            for (int x = 0; x < numbers.GetLength(1); x++)
            {
                if (x == 0 && y == 0)//top left
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && y == 0)//top right
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (y == 0)//first row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (x == 0)// first in each row
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (x == 0 && y == numbers.GetLength(0) - 1)//bottom left
                {
                    if (numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && !(y == numbers.GetLength(0) - 1))//Last in each row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (x == numbers.GetLength(1) - 1 && y == numbers.GetLength(0) - 1) // bottom right
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else if (y == numbers.GetLength(0) - 1) //last row
                {
                    if (numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x])
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
                else// everythign else 
                {
                    if ((numbers[y, x - 1] > numbers[y, x] && numbers[y, x + 1] > numbers[y, x] && numbers[y - 1, x] > numbers[y, x] && numbers[y + 1, x] > numbers[y, x]))
                    {
                        var add = (numbers[y, x], new Point(x, y));
                        output.Add(add);
                    }
                }
            }
        }
        return output;
    }
    public static int Part2(int[,] numbers)
    {
        var lowPoints = FindLowPoints(numbers);
        var basins = new List<List<Point>>();

        foreach (var point in lowPoints)
        {
            basins.Add(BreathFirstSearch(point, numbers));
        }

        var top3 = basins.Select(x => x).OrderByDescending(x => x.Count).Take(3).ToList();
        var result = 1;
        foreach (var item in top3)
        {
            result *= item.Count;
        }

        return result;
    }

    public static List<Point> BreathFirstSearch((int value, Point pos) point, int[,] numbers)
    {
        var basin = new HashSet<Point>();
        Queue<Point> points = new Queue<Point>();
        basin.Add(point.pos);
        points.Enqueue(point.pos);
        while (points.Count > 0 )
        {
            var current = points.Dequeue();
            if (current.Y != 0)
            {
                if (point.value < numbers[current.Y - 1, current.X] && numbers[current.Y - 1, current.X] < 9 && !basin.Contains(current))
                {
                    var nextPoint = new Point(current.X, current.Y - 1);
                    points.Enqueue(nextPoint);
                    basin.Add(nextPoint);
                }
            }
            if (current.Y < numbers.GetLength(0) - 1)
            {
                if (point.value < numbers[current.Y + 1, current.X] && numbers[current.Y + 1, current.X] < 9 && !basin.Contains(current))
                {
                    var nextPoint = new Point(current.X, current.Y + 1);
                    points.Enqueue(nextPoint);
                    basin.Add(nextPoint);
                }
            }
            if (current.X != 0)
            {
                if (point.value < numbers[current.Y, current.X - 1] && numbers[current.Y, current.X - 1] < 9 && !basin.Contains(current))
                {
                    var nextPoint = new Point(current.X - 1, current.Y);
                    points.Enqueue(nextPoint);
                    basin.Add(nextPoint);
                }
            }
            if (current.X < numbers.GetLength(1) - 1)
            {
                if (point.value < numbers[current.Y, current.X + 1] && numbers[current.Y, current.X + 1] < 9 && !basin.Contains(current))
                {
                    var nextPoint = new Point(current.X + 1, current.Y);
                    points.Enqueue(nextPoint);
                    basin.Add(nextPoint);
                }
            }
        }
        return basin.ToList();
    }


    public record struct Point(int X, int Y);

}
