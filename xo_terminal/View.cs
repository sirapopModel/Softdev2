public class View
{
    int n;
    public View(int k)
    {
        n = k;
    }
    public void first_board_view()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(" _ ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------");
    }

    public void save_file_write(string folder_path)
    {
        DirectoryInfo save_folder = new DirectoryInfo(folder_path);
        FileInfo[] save_name_list = save_folder.GetFiles("*.txt");

        foreach (FileInfo file in save_name_list)
        {
            Console.WriteLine(file.Name);
        }
    }

    public void field_write(string[,] field_array)
    {
        Console.WriteLine("");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (field_array[i, j] == "n" || field_array[i, j] == null)
                {
                    Console.Write(" _ ");
                }
                else if (field_array[i, j] == "x")
                {
                    Console.Write(" X ");
                }
                else if (field_array[i, j] == "o")
                {
                    Console.Write(" O ");
                }
                else if (field_array[i, j] == "l")
                {
                    Console.Write(" l ");
                }
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------");


    }

    public void winner_field_write(int winner_found, string winner_turn, string[,] field_array)
    {
        field_write(field_array);
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
        Console.WriteLine("      2. type 1 for save game");
        Console.WriteLine("      3. type 2 for LOAD game");
        Console.WriteLine("");
        Console.WriteLine("Your current board:");
        Console.WriteLine("");
    }
}