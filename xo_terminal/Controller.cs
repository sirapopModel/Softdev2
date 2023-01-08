using System;
public class my_control
{
    public string[] index_row_col = new string[3];
    public int n;
    public View terminal_call;
    public game_data data;
    public my_control()
    {
        //n = k;
        terminal_call = new View(n);

        // Model
        data = new game_data();
        data.CreateArray(n);
    }

    public void save_slot_show()
    {
        Console.WriteLine(data.save_path);
        if (!Directory.Exists(data.save_path))
        {
            Directory.CreateDirectory(data.save_path);
        }
        terminal_call.save_file_write(data.save_path);
    }

    public void launch_load(string file_name)
    {

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
            if (result == "1")
            {

            }
            else if (result == "2")
            {

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
                terminal_call.field_write(data.GameResultArray);
            }
        }
    }

    public void call_first_board(int n)
    {
        terminal_call.first_board_view();
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
            terminal_call.field_write(data.GameResultArray);
            data.SwitchTurn();
            return false;
        }
        show_winner(winner_found);
        return true;
    }

    public void show_winner(int winner_found)
    {
        terminal_call.winner_field_write(winner_found, data.GetCurrentTurn(), data.GameResultArray);
    }


}