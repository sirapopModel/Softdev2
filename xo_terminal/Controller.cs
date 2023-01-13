using System;
public class my_control
{
    public string[] index_row_col = new string[3];
    //public int n;
    public View terminal_call = new View();
    public game_data data = new game_data();
    private FileInfo fileInfo;
    private string result_input;

    public void StartUp()
    {
        Console.WriteLine("PLAY or LOAD");
        var ANS = Console.ReadLine();
        if (ANS == "PLAY")
        {
            Console.Write("ENTER SIZE : ");
            int n = Convert.ToInt32(Console.ReadLine());
            set_up(n);
            call_first_board(n);
            play_game();
        }
        else if (ANS == "LOAD")
        {
            launch_load();
            play_game();
        }
        else
        {
            Console.WriteLine("     !!JUST TYPE PLAY OR LOAD!!      ");
        }
    }
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
        Save_Folder_Check();
        terminal_call.save_file_write(data.save_path);
        Console.WriteLine("");
        Console.WriteLine("Path From:" + data.save_path);
    }

    public void Save_Folder_Check()
    {
        if (!Directory.Exists(data.save_path))
        {
            Directory.CreateDirectory(data.save_path);
        }
    }

    public void launch_load()
    {
        Console.WriteLine("SELECT SAVE FILE : ");
        save_slot_show();
        Console.WriteLine("");
        Console.Write("TYPE YOUR SAVE NAME : ");
        string save_name = Console.ReadLine();


        string save_play_path = Path.GetFullPath(Path.Join(data.save_path, save_name));
        fileInfo = new FileInfo(save_play_path);
        FileStream save_file = fileInfo.OpenRead();
        data.LoadGame(save_file);
        terminal_call.field_write(data.GameResultArray, data.n);
        //play_game();
    }

    private void launch_save()
    {
        Save_Folder_Check();
        Console.Write("ENTER FILENAME : ");
        string name = Console.ReadLine();

        string save_play_path = Path.GetFullPath(Path.Join(data.save_path, name));
        fileInfo = new FileInfo(save_play_path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
        FileStream fileStream = File.Create(save_play_path);
        data.SaveGame(fileStream);
        terminal_call.save_file_write(data.save_path);
    } 
    public void Ask_Input()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        
        Console.Write("ENTER INPUT : ");
        result_input = Console.ReadLine();
    }
    public void play_game()
    {
        while (true)
        {
            Console.WriteLine("Current Turn : " + data.GetCurrentTurn().ToUpper());
            Ask_Input();
            if (result_input == "SAVE")
            {
                launch_save();
                Ask_Input();
            }
            if (result_input == "LOAD")
            {
                launch_load();
                Console.WriteLine("Current Turn : " + data.GetCurrentTurn().ToUpper());
                Ask_Input();
            }
            try
            {
                index_row_col = result_input.Split(",");
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
        terminal_call.field_write(data.GameResultArray, data.n);
        terminal_call.winner_field_write(winner_found, data.GetCurrentTurn());
    }


}