public class View
{
    private Model model;

    public View(Model model)
    {
        this.model = model;
    }
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

    public void ShowBoard()
    {
        string value;
        Console.WriteLine("");
        for (int i = 0; i < model.BoardSize; i++)
        {
            for (int j = 0; j < model.BoardSize; j++)
            {
                value = model.GetBoardValue(i, j);
                if (value == "n" || String.IsNullOrEmpty(value))
                {
                    Console.Write(" _ ");
                }
                else if (value == "x")
                {
                    Console.Write(" X ");
                }
                else if (value == "o")
                {
                    Console.Write(" O ");
                }
                
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
}