using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static int[,] board = new int[4, 4];
        static bool gameOver = false;

        static void Main(string[] args)
        {
            AddRandom();

            while (!gameOver)
            {
                DrawBoard();
                System.Threading.Thread.Sleep(10);
                Move("down");
                DrawBoard();
                System.Threading.Thread.Sleep(10);
                Move("left");
                DrawBoard();
                System.Threading.Thread.Sleep(10);


                ////AddRandom();
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);
                //Move("up");
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);

                //AddRandom();
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);
                //Move("right");
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);

                ////AddRandom();
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);
                //Move("down");
                //DrawBoard();
                //System.Threading.Thread.Sleep(1000);
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
                    Console.Write(Space(space/2) + board[r, c] + Space(space - (space/2)));
                }
                Console.WriteLine("\n\n");
            }
        }

        static void Move(string dir)
        {
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

            AddRandom();
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

            else
            {
                gameOver = true;
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
