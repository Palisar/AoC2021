using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_04 : BaseDay
    {

        private readonly int[] _numbersCalled;
        private readonly List<int?[,]> _BingoBoards;
        
        public Day_04()
        {
            var lines = File.ReadAllLines(InputFilePath);
            _numbersCalled = lines[0].Split(',').Select(int.Parse).ToArray();
            var allLines = lines.Skip(2).Select(s => s.Split('\n')).ToList();
            allLines.Add(new string[] {""});
            _BingoBoards = MakeBoards(allLines);
        }

        public override ValueTask<string> Solve_1()
        {
            return ValueTask.FromResult(Part1(_numbersCalled, _BingoBoards).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            return ValueTask.FromResult(Part2().ToString());
        }

        public static int? Part1(int[] input, List<int?[,]> boards)
        {
            
            for (int i = 0; i < input.Length; i++)
            {
                for (var currentBoard = 0; currentBoard < boards.Count; currentBoard++)
                {
                    boards[currentBoard] = CheckNumber(boards[currentBoard], input[i]);
                    if (CheckBingo(boards[currentBoard]))
                    {
                        var output = SumOfBoard(boards[currentBoard]) * input[i];
                        return output;
                    }
                }                                    
            }
           
            return 1;
        }
        public static int Part2()
        {
            return 0;
        }

        public static int?[,] MakeBoard(List<string> list)
        {
            int?[,] board = new int?[5, 5];
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var row = list[counter].Split(' ').ToList();
                    while (row.Contains(""))
                    {
                        row.Remove("");
                    }
                    board[i, j] = int.Parse(row[j]);
                }
                counter++;
            }
            return board;
        }

        public static List<int?[,]> MakeBoards(IEnumerable<string[]> allLines)
        {
            List<string> oneBoard = new();
            List<int?[,]> boards = new();
            foreach (var item in allLines)
            {
                if(oneBoard.Count == 5)
                {
                    boards.Add(MakeBoard(oneBoard));
                    oneBoard = new();
                }
                else
                {
                   oneBoard.Add(item[0]);
                }
            }
            return boards;
        }
        public static bool CheckBingo(int?[,] board)
        {
            if (CheckHorizontal(board))
                return true;
            else if (CheckVertical(board))
                return true;
            else 
                return false;
        }

        private static bool CheckHorizontal(int?[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == null)
                    {
                        if (j == 4)
                        {
                            return true;
                        }
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        private static bool CheckVertical(int?[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[j, i] == null)
                    {
                        if (j == 4)
                        {
                            return true;
                        }
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        public static int?[,] CheckNumber(int?[,] board, int number)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == number)
                    {
                        board[i,j] = null;
                        //return board;
                    }
                }
            }
            return board;
        }

        public static int? SumOfBoard(int?[,] board)
        {
            int? sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i,j] != null)
                    {
                        sum += board[i, j];
                    }
                }
            }
            return sum;
        }
    }
}
