using System;

namespace sergeantTheyDunHitThePentagon
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //cool game card thing
            Console.WriteLine(" ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                          *********************************************");
            Console.WriteLine(" ");
            Console.Write("                          *"); Console.ForegroundColor = ConsoleColor.White; Console.Write("    Welcome to The Battleship Game!!!     "); Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine(" *");

            //all of this is me copying my tictactoe 
            string[,] gameBoard = new string[10, 10];
            string[,] aiGameBoard = new string[10, 10];
            string currentPlayer = "X";
            int rowMove = 0;
            int columnMove = 0;
            bool gameOver = false;
            bool winOrDraw = false;
            char playAgain = ' ';
            Random random = new Random();
            IntitialiseGameBoard(gameBoard, aiGameBoard);
            DisplayBoard(gameBoard, aiGameBoard);

            while (!gameOver)
            {
                takeTurn(gameBoard, ref currentPlayer, ref rowMove, ref columnMove, ref random);
                DisplayBoard(gameBoard, aiGameBoard);
                winOrDraw = checkForWin(gameBoard);

                if (winOrDraw)
                {
                    Console.WriteLine("Do you want to play again? Y for yes and any other to exit.");
                    playAgain = Convert.ToChar(Console.ReadLine());

                    if (playAgain != 'Y')
                    {
                        gameOver = true;
                    }
                    else
                    {
                        IntitialiseGameBoard(gameBoard, aiGameBoard);
                        DisplayBoard(gameBoard, aiGameBoard);
                    }
                }
            }

        }
       

        private static void IntitialiseGameBoard(string[,] gameBoard, string[,] aiGameBoard)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard[i, j] = " ";
                }

            }

        }

        //my little battleship thing
        private static void DisplayBoard(string[,] gameBoard, string[,] aiGameBoard)
        {
            for (int i = 0; i < 1; i++)
            {
                //cool game card thing

                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                          *********************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");

                Console.WriteLine("                YOUR BOAT'S                                         OPPS BOAT'S             ");
                Console.WriteLine("     1   2   3   4   5   6   7   8   9  10                1   2   3   4   5   6   7   8   9  10");
                Console.WriteLine(" 1 | " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2] + " | " + gameBoard[0, 3] + " | " + gameBoard[0, 4] + " | " + gameBoard[0, 5] + " | " + gameBoard[0, 6] + " | " + gameBoard[0, 7] + " | " + gameBoard[0, 8] + " | " + gameBoard[0, 9] + " |          1 |  " + aiGameBoard[0, 0] + " |  " + aiGameBoard[0, 1] + " |  " + aiGameBoard[0, 2] + " |  " + aiGameBoard[0, 3] + " |  " + aiGameBoard[0, 4] + " |  " + aiGameBoard[0, 5] + " |  " + aiGameBoard[0, 6] + " |  " + aiGameBoard[0, 7] + " |  " + aiGameBoard[0, 8] + " |  " + aiGameBoard[0, 9] + " |");
                Console.WriteLine(" 2 | " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2] + " | " + gameBoard[1, 3] + " | " + gameBoard[1, 4] + " | " + gameBoard[1, 5] + " | " + gameBoard[1, 6] + " | " + gameBoard[1, 7] + " | " + gameBoard[1, 8] + " | " + gameBoard[1, 9] + " |          2 |  " + aiGameBoard[1, 0] + " |  " + aiGameBoard[1, 1] + " |  " + aiGameBoard[1, 2] + " |  " + aiGameBoard[1, 3] + " |  " + aiGameBoard[1, 4] + " |  " + aiGameBoard[1, 5] + " |  " + aiGameBoard[1, 6] + " |  " + aiGameBoard[1, 7] + " |  " + aiGameBoard[1, 8] + " |  " + aiGameBoard[1, 9] + " |");
                Console.WriteLine(" 3 | " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + " | " + gameBoard[2, 3] + " | " + gameBoard[2, 4] + " | " + gameBoard[2, 5] + " | " + gameBoard[2, 6] + " | " + gameBoard[2, 7] + " | " + gameBoard[2, 8] + " | " + gameBoard[2, 9] + " |          3 |  " + aiGameBoard[2, 0] + " |  " + aiGameBoard[2, 1] + " |  " + aiGameBoard[2, 2] + " |  " + aiGameBoard[2, 3] + " |  " + aiGameBoard[2, 4] + " |  " + aiGameBoard[2, 5] + " |  " + aiGameBoard[2, 6] + " |  " + aiGameBoard[2, 7] + " |  " + aiGameBoard[2, 8] + " |  " + aiGameBoard[2, 9] + " |");
                Console.WriteLine(" 4 | " + gameBoard[3, 0] + " | " + gameBoard[3, 1] + " | " + gameBoard[3, 2] + " | " + gameBoard[3, 3] + " | " + gameBoard[3, 4] + " | " + gameBoard[3, 5] + " | " + gameBoard[3, 6] + " | " + gameBoard[3, 7] + " | " + gameBoard[3, 8] + " | " + gameBoard[3, 9] + " |          4 |  " + aiGameBoard[3, 0] + " |  " + aiGameBoard[3, 1] + " |  " + aiGameBoard[3, 2] + " |  " + aiGameBoard[3, 3] + " |  " + aiGameBoard[3, 4] + " |  " + aiGameBoard[3, 5] + " |  " + aiGameBoard[3, 6] + " |  " + aiGameBoard[3, 7] + " |  " + aiGameBoard[3, 8] + " |  " + aiGameBoard[3, 9] + " |");
                Console.WriteLine(" 5 | " + gameBoard[4, 0] + " | " + gameBoard[4, 1] + " | " + gameBoard[4, 2] + " | " + gameBoard[4, 3] + " | " + gameBoard[4, 4] + " | " + gameBoard[4, 5] + " | " + gameBoard[4, 6] + " | " + gameBoard[4, 7] + " | " + gameBoard[4, 8] + " | " + gameBoard[4, 9] + " |          5 |  " + aiGameBoard[4, 0] + " |  " + aiGameBoard[4, 1] + " |  " + aiGameBoard[4, 2] + " |  " + aiGameBoard[4, 3] + " |  " + aiGameBoard[4, 4] + " |  " + aiGameBoard[4, 5] + " |  " + aiGameBoard[4, 6] + " |  " + aiGameBoard[4, 7] + " |  " + aiGameBoard[4, 8] + " |  " + aiGameBoard[4, 9] + " |");
                Console.WriteLine(" 6 | " + gameBoard[5, 0] + " | " + gameBoard[5, 1] + " | " + gameBoard[5, 2] + " | " + gameBoard[5, 3] + " | " + gameBoard[5, 4] + " | " + gameBoard[5, 5] + " | " + gameBoard[5, 6] + " | " + gameBoard[5, 7] + " | " + gameBoard[5, 8] + " | " + gameBoard[5, 9] + " |          6 |  " + aiGameBoard[5, 0] + " |  " + aiGameBoard[5, 1] + " |  " + aiGameBoard[5, 2] + " |  " + aiGameBoard[5, 3] + " |  " + aiGameBoard[5, 4] + " |  " + aiGameBoard[5, 5] + " |  " + aiGameBoard[5, 6] + " |  " + aiGameBoard[5, 7] + " |  " + aiGameBoard[5, 8] + " |  " + aiGameBoard[5, 9] + " |");
                Console.WriteLine(" 7 | " + gameBoard[6, 0] + " | " + gameBoard[6, 1] + " | " + gameBoard[6, 2] + " | " + gameBoard[6, 3] + " | " + gameBoard[6, 4] + " | " + gameBoard[6, 5] + " | " + gameBoard[6, 6] + " | " + gameBoard[6, 7] + " | " + gameBoard[6, 8] + " | " + gameBoard[6, 9] + " |          7 |  " + aiGameBoard[6, 0] + " |  " + aiGameBoard[6, 1] + " |  " + aiGameBoard[6, 2] + " |  " + aiGameBoard[6, 3] + " |  " + aiGameBoard[6, 4] + " |  " + aiGameBoard[6, 5] + " |  " + aiGameBoard[6, 6] + " |  " + aiGameBoard[6, 7] + " |  " + aiGameBoard[6, 8] + " |  " + aiGameBoard[6, 9] + " |");
                Console.WriteLine(" 8 | " + gameBoard[7, 0] + " | " + gameBoard[7, 1] + " | " + gameBoard[7, 2] + " | " + gameBoard[7, 3] + " | " + gameBoard[7, 4] + " | " + gameBoard[7, 5] + " | " + gameBoard[7, 6] + " | " + gameBoard[7, 7] + " | " + gameBoard[7, 8] + " | " + gameBoard[7, 9] + " |          8 |  " + aiGameBoard[7, 0] + " |  " + aiGameBoard[7, 1] + " |  " + aiGameBoard[7, 2] + " |  " + aiGameBoard[7, 3] + " |  " + aiGameBoard[7, 4] + " |  " + aiGameBoard[7, 5] + " |  " + aiGameBoard[7, 6] + " |  " + aiGameBoard[7, 7] + " |  " + aiGameBoard[7, 8] + " |  " + aiGameBoard[7, 9] + " |");
                Console.WriteLine(" 9 | " + gameBoard[8, 0] + " | " + gameBoard[8, 1] + " | " + gameBoard[8, 2] + " | " + gameBoard[8, 3] + " | " + gameBoard[8, 4] + " | " + gameBoard[8, 5] + " | " + gameBoard[8, 6] + " | " + gameBoard[8, 7] + " | " + gameBoard[8, 8] + " | " + gameBoard[8, 9] + " |          9 |  " + aiGameBoard[8, 0] + " |  " + aiGameBoard[8, 1] + " |  " + aiGameBoard[8, 2] + " |  " + aiGameBoard[8, 3] + " |  " + aiGameBoard[8, 4] + " |  " + aiGameBoard[8, 5] + " |  " + aiGameBoard[8, 6] + " |  " + aiGameBoard[8, 7] + " |  " + aiGameBoard[8, 8] + " |  " + aiGameBoard[8, 9] + " |");
                Console.WriteLine(" 10| " + gameBoard[9, 0] + " | " + gameBoard[9, 1] + " | " + gameBoard[9, 2] + " | " + gameBoard[9, 3] + " | " + gameBoard[9, 4] + " | " + gameBoard[9, 5] + " | " + gameBoard[9, 6] + " | " + gameBoard[9, 7] + " | " + gameBoard[9, 8] + " | " + gameBoard[9, 9] + " |          10|  " + aiGameBoard[9, 0] + " |  " + aiGameBoard[9, 1] + " |  " + aiGameBoard[9, 2] + " |  " + aiGameBoard[9, 3] + " |  " + aiGameBoard[9, 4] + " |  " + aiGameBoard[9, 5] + " |  " + aiGameBoard[9, 6] + " |  " + aiGameBoard[9, 7] + " |  " + aiGameBoard[9, 8] + " |  " + aiGameBoard[9, 9] + " |");

            }


        }

        //just my gameover from the tictactoe
        private static void takeTurn( string[,] aiGameBoard, ref string currentPlayer, ref int rowMove, ref int columnMove, ref Random random)
        {
            Console.Write("Enter row number 1 to 10:");
            rowMove = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column number from 1 to 10:");
            columnMove = Convert.ToInt32(Console.ReadLine());
            if (currentPlayer == "X")
            {
                if (aiGameBoard[rowMove - 1, columnMove - 1] == " ")
                {
                    aiGameBoard[rowMove - 1, columnMove - 1] = currentPlayer;
                    if (currentPlayer == "*")
                    {
                        currentPlayer = "X";
                    }
                    else
                    {
                        currentPlayer = "*";
                    }
                }
                else
                {
                    Console.WriteLine("POSITION ALREADY TAKEN. TRY AGAIN");
                    takeTurn(aiGameBoard, ref currentPlayer, ref rowMove, ref columnMove, ref random);
                }
            }
            else
            {
                rowMove = random.Next(10);
                columnMove = random.Next(10);
                if (aiGameBoard[rowMove, columnMove] == " ")
                {
                    aiGameBoard[rowMove, columnMove] = currentPlayer;
                    if (currentPlayer == "X")
                    {
                        currentPlayer = "*";
                    }
                    else
                    {
                        currentPlayer = "X";
                    }
                }
                else
                {
                    Console.WriteLine("POSITION ALREADY TAKEN. TRY AGAIN");
                    takeTurn(aiGameBoard, ref currentPlayer, ref rowMove, ref columnMove, ref random);
                }

            }

        }

        private static bool checkForWin(string[,] gameBoard)
        {
            bool result = false;

            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[0, i] != " " && gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                {
                    Console.WriteLine("WE HAVE A WINNER");
                    result = true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] != " " && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                {
                    Console.WriteLine("WE HAVE A WINNER");
                    result = true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] != " " && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                {
                    Console.WriteLine("WE HAVE A WINNER");
                    result = true;
                }
            }
            if (gameBoard[0, 0] != " " && gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
            {
                Console.WriteLine("WE HAVE A WINNER");
                result = true;
            }
            if (gameBoard[0, 2] != " " && gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
            {
                Console.WriteLine("WE HAVE A WINNER");
                result = true;
            }

            return result;

        }

    }
}
