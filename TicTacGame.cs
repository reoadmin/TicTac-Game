
using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; // Player 1 starts
    static bool gameOver = false;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        Console.WriteLine("Player 1: X  Player 2: O");
        Console.WriteLine("Press Enter to start the game...");
        Console.ReadLine();

        do
        {
            // Display the current board
            DisplayBoard();

            // Get the current player's move
            int move = GetPlayerMove();

            // Update the board with the player's move
            UpdateBoard(move);

            // Check if the game is over
            gameOver = CheckForWinner() || CheckForDraw();

            // Switch players
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        } while (!gameOver);

        // Display the final board and outcome
        DisplayBoard();
        if (CheckForWinner())
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static int GetPlayerMove()
    {
        int move = 0;
        bool validMove = false;

        do
        {
            Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
            if (int.TryParse(Console.ReadLine(), out move))
            {
                if (move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move. Please choose an empty position.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
            }
        } while (!validMove);

        return move - 1; // Adjust for 0-based indexing
    }

    static void UpdateBoard(int move)
    {
        board[move] = (currentPlayer == 1) ? 'X' : 'O';
    }

    static bool CheckForWinner()
    {
        // Check rows, columns, and diagonals for a winning combination
        return (board[0] == board[1] && board[1] == board[2]) ||
               (board[3] == board[4] && board[4] == board[5]) ||
               (board[6] == board[7] && board[7] == board[8]) ||
               (board[0] == board[3] && board[3] == board[6]) ||
               (board[1] == board[4] && board[4] == board[7]) ||
               (board[2] == board[5] && board[5] == board[8]) ||
               (board[0] == board[4] && board[4] == board[8]) ||
               (board[2] == board[4] && board[4] == board[6]);
    }

    static bool CheckForDraw()
    {
        // Check if the board is full
        foreach (char position in board)
        {
            if (position != 'X' && position != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
