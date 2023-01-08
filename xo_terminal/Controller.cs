using System;
public class my_control
{
    public string[] index_row_col = new string[3];
    //public int n;
    public View terminal_call = new View();
    public game_data data = new game_data();
    public void set_up(int k)
    {
        //n = k;
        //terminal_call.n = k;

        // Model
        data.n = k;
        data.CreateArray(data.n);
    }

    public void save_slot_show()
    {
        if (!Directory.Exists(data.save_path))
        {
            Directory.CreateDirectory(data.save_path);
        }
        terminal_call.save_file_write(data.save_path);
        Console.WriteLine("");
        Console.WriteLine("Path From:" + data.save_path);
    }

    public void launch_load()
    {
        Console.WriteLine("SELECT SAVE FILE : ");
        save_slot_show();
        Console.WriteLine("");
        Console.Write("TYPE YOUR SAVE NAME : ");
        string save_name = Console.ReadLine();


        string save_play_path = Path.GetFullPath(Path.Join(data.save_path, save_name));
        FileInfo location = new FileInfo(save_play_path);
        FileStream save_file = location.OpenRead();
        data.LoadGame(save_file);
        terminal_call.field_write(data.GameResultArray, data.n);
        play_game();
    }
    public void play_game()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Current Turn : " + data.GetCurrentTurn().ToUpper());
            Console.Write("ENTER ROW AND COLUMN like rol,col: ");
            var result = Console.ReadLine();
            if (result == "SAVE")
            {

            }
            else if (result == "LOAD")
            {
                launch_load();
            }
            try
            {
                index_row_col = result.Split(",");
                string row_string = index_row_col[0];
                string col_string = index_row_col[1];
                if (move_call(Convert.ToInt32(row_string), Convert.ToInt32(col_string)))
                {
                    break;
                }
            }
            catch (System.Exception)
            {
                terminal_call.detail_input();
                terminal_call.field_write(data.GameResultArray, data.n);
            }
        }
    }

    public void call_first_board(int n)
    {
        terminal_call.first_board_view(data.n);
    }

    public bool move_call(int row, int col)
    {
        if (data.IsAlreadyPlayed(row, col))
        {
            Console.WriteLine("ALREADY FILLED!!");
            return false;
        }

        data.PlayerPlay(row, col);
        int winner_found = data.CheckForWinner(row, col);
        if (winner_found == 0)
        {
            terminal_call.field_write(data.GameResultArray, data.n);
            data.SwitchTurn();
            return false;
        }
        show_winner(winner_found);
        return true;
    }

    public void show_winner(int winner_found)
    {
        terminal_call.winner_field_write(winner_found, data.GetCurrentTurn(), data.GameResultArray, data.n);
    }


}