using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static int[,] board = new int[4, 4], oldBoard;
        static bool gameOver = false;

        static void Main(string[] args)
        {
            AddRandom();

            while (!gameOver)
            {
                DrawBoard();

                oldBoard = board.Clone() as int[,];

                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        Move("left");
                        break;
                    case ConsoleKey.UpArrow:
                        Move("up");
                        break;
                    case ConsoleKey.DownArrow:
                        Move("down");
                        break;
                    case ConsoleKey.RightArrow:
                        Move("right");
                        break;
                }

                if (board != oldBoard)
                {
                    AddRandom();
                }
                if (!CanMove())
                {
                    gameOver = true;
                }
            }

            Console.WriteLine("GAME OVER");
        }

        //clears console, then redraws board
        static void DrawBoard()
        {
            Console.SetCursorPosition(0, 0);

            for (int r = 0; r < board.GetLength(0); r++)
            {   
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    int space = 7 - board[r, c].ToString().Length;
                    ChangeColor(board[r, c]);
                    Console.Write(Space(space/2) + board[r, c] + Space(space - (space/2)));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\n\n");
            }
        }

        static void ChangeColor(int i)
        {
            if (i == 2)     { Console.ForegroundColor = ConsoleColor.Yellow; }
            if (i == 4)     { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            if (i == 8)     { Console.ForegroundColor = ConsoleColor.Red; }
            if (i == 16)    { Console.ForegroundColor = ConsoleColor.DarkRed; }
            if (i == 32)    { Console.ForegroundColor = ConsoleColor.Magenta; }
            if (i == 64)    { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            if (i == 128)   { Console.ForegroundColor = ConsoleColor.Green; }
            if (i == 256)   { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            if (i == 512)   { Console.ForegroundColor = ConsoleColor.Blue; }
            if (i == 1024)  { Console.ForegroundColor = ConsoleColor.DarkBlue; }
            if (i == 2048)  { Console.ForegroundColor = ConsoleColor.DarkCyan; }
            
        }

        static void Move(string dir)
        {
            oldBoard = board.Clone() as int[,];

            if (dir == "left")
            {
                for (int r = 0; r < board.GetLength(0); r++)
                {
                    int moveTo = 0;

                    for (int c = 0; c < board.GetLength(1); c++)
                    {
                        if (board[r, c] != 0 && c != moveTo)
                        {
                            if (board[r, c] == board[r, moveTo])
                            {
                                board[r, moveTo] *= 2;
                                board[r, c] = 0;
                            }

                            else if (board[r, moveTo] == 0)
                            {
                                board[r, moveTo] = board[r, c];
                                board[r, c] = 0;
                            }

                            else if (moveTo + 1 != c)
                            {
                                moveTo++;
                                board[r, moveTo] = board[r, c];
                                board[r, c] = 0;
                            }

                            else
                            {
                                moveTo++;
                            }
                        }
                    }
                }
            }

            if (dir == "right")
            {
                for (int r = 0; r < board.GetLength(0); r++)
                {
                    int moveTo = board.GetLength(1)-1;

                    for (int c = board.GetLength(1)-1; c >= 0; c--)
                    {
                        if (board[r, c] != 0 && c != moveTo)
                        {
                            if (board[r, c] == board[r, moveTo])
                            {
                                board[r, moveTo] *= 2;
                                board[r, c] = 0;
                            }

                            else if (board[r, moveTo] == 0)
                            {
                                board[r, moveTo] = board[r, c];
                                board[r, c] = 0;
                            }

                            else if (moveTo - 1 != c)
                            {
                                moveTo--;
                                board[r, moveTo] = board[r, c];
                                board[r, c] = 0;
                            }

                            else
                            {
                                moveTo--;
                            }
                        }
                    }
                }
            }

            if (dir == "up")
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    int moveTo = 0;

                    for (int r = 0; r < board.GetLength(0); r++)
                    {
                        if (board[r, c] != 0 && r != moveTo)
                        {
                            if (board[r, c] == board[moveTo, c])
                            {
                                board[moveTo, c] *= 2;
                                board[r, c] = 0;
                            }

                            else if (board[moveTo, c] == 0)
                            {
                                board[moveTo, c] = board[r, c];
                                board[r, c] = 0;
                            }

                            else if (moveTo + 1 != r)
                            {
                                moveTo++;
                                board[moveTo, c] = board[r, c];
                                board[r, c] = 0;
                            }

                            else
                            {
                                moveTo++;
                            }
                        }
                    }
                }
            }

            if (dir == "down")
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    int moveTo = board.GetLength(0)-1;

                    for (int r = board.GetLength(0)-1; r >= 0; r--)
                    {
                        if (board[r, c] != 0 && r != moveTo)
                        {
                            if (board[r, c] == board[moveTo, c])
                            {
                                board[moveTo, c] *= 2;
                                board[r, c] = 0;
                            }

                            else if (board[moveTo, c] == 0)
                            {
                                board[moveTo, c] = board[r, c];
                                board[r, c] = 0;
                            }

                            else if (moveTo - 1 != r)
                            {
                                moveTo--;
                                board[moveTo, c] = board[r, c];
                                board[r, c] = 0;
                            }

                            else
                            {
                                moveTo--;
                            }
                        }
                    }
                }
            }
        }

        static bool CanMove()
        {
            Move("right");
            if (board != oldBoard)
            {
                board = oldBoard;
                return true;
            }
            Move("left");
            if (board != oldBoard)
            {
                board = oldBoard;
                return true;
            }
            Move("up");
            if (board != oldBoard)
            {
                board = oldBoard;
                return true;
            }
            Move("down");
            if (board != oldBoard)
            {
                board = oldBoard;
                return true;
            }
            return false;
        }

        static void AddRandom()
        {
            //list to store the locations of all empty elements in the board
            List<Tuple<int, int>> empty = new List<Tuple<int, int>>();
            Random rnd = new Random();

            //gives a 10% chance of spawning a 4
            int twoFour = rnd.Next(10);
            int num = 2;

            if (twoFour == 0)
            {
                num = 4;
            }

            //finds all empty elemtents in the board
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r, c] == 0)
                    {
                        empty.Add(Tuple.Create(r, c));
                    }
                }
            }

            //randomly adds a 2 or 4 into an empty element in the board
            if (empty.Count > 0)
            {
                int ind = rnd.Next(empty.Count);
                board[empty[ind].Item1, empty[ind].Item2] = num;
            }
        }

        static string Space(int spaceCount)
        {
            string spaces = "";

            for (int i = 0; i < spaceCount; i++)
            {
                spaces += " ";
            }

            return spaces;
        }
    }
}
