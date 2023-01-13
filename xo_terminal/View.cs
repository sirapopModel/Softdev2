public class View
{
    //public int n;
    public void ShowMenuInput()
    {
        Console.WriteLine("");
        Console.WriteLine("============== Main Menu ==============");
        Console.WriteLine("Type \"1\" to start a new game.");
        Console.WriteLine("Type \"2\" to load game from save folder.");
        Console.WriteLine("");
    }
    public void ShowInput()
    {
        Console.WriteLine("");
        Console.WriteLine("===========================================");
        Console.WriteLine(" -> Type \"exit\" to go back to main menu.");
        Console.WriteLine(" -> Type \"save\" to save game (Only while playing the game).");
        Console.WriteLine(" -> Type \"(row),(column)\" to play in the board (For example \"0,0\").");
    }

    public void ShowBoard(string board)
    {
        int n = Convert.ToInt32(Math.Sqrt(board.Length));
        int pointer = 0;
        Console.WriteLine("");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {

                if (board[pointer] == 'n')
                {
                    Console.Write(" _ ");
                }
                else if (board[pointer] == 'x')
                {
                    Console.Write(" X ");
                }
                else if (board[pointer] == 'o')
                {
                    Console.Write(" O ");
                }
                pointer++;
                
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------");
    }

    public void winner_field_write(int winner_found, string winner_turn)
    {
        if (winner_found == 1)
        {
            Console.WriteLine("winner is " + winner_turn.ToUpper() + " (horizontal line)");
        }
        else if (winner_found == 2)
        {
            Console.WriteLine("winner is " + winner_turn.ToUpper() + " (vertical line)");
        }
        else
        {
            Console.WriteLine("winner is " + winner_turn.ToUpper() + " (diagonal line)");
        }

    }

    public void detail_input()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("    !!SOMETHING WRONG ABOUT YOU INPUT TRY AGAIN LIKE!!");
        Console.WriteLine("");
        Console.WriteLine("      1. row num , col num to fill in field");
        Console.WriteLine("      2. type SAVE for save game");
        Console.WriteLine("      3. type LOAD for LOAD game");
        Console.WriteLine("");
        Console.WriteLine("Your current board:");
        Console.WriteLine("");
    }
}