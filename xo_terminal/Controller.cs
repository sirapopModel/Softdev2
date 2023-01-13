using System;
public class Controller
{
    public string[] index_row_col = new string[3];
    public View View;
    public Model Model;
    private FileInfo fileInfo;
    private string result_input;

    public Controller(Model Model,View View) 
    {
        this.Model = Model;
        this.View = View;
    }
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
        Model.n = k;
        Model.CreateArray(Model.n);
    }

    public void save_slot_show()
    {
        Save_Folder_Check();
        View.save_file_write(Model.save_path);
        Console.WriteLine("");
        Console.WriteLine("Path From:" + Model.save_path);
    }

    public void Save_Folder_Check()
    {
        if (!Directory.Exists(Model.save_path))
        {
            Directory.CreateDirectory(Model.save_path);
        }
    }

    public void launch_load()
    {
        Console.WriteLine("SELECT SAVE FILE : ");
        save_slot_show();
        Console.WriteLine("");
        Console.Write("TYPE YOUR SAVE NAME : ");
        string save_name = Console.ReadLine();


        string save_play_path = Path.GetFullPath(Path.Join(Model.save_path, save_name));
        fileInfo = new FileInfo(save_play_path);
        FileStream save_file = fileInfo.OpenRead();
        Model.LoadGame(save_file);
        View.field_write(Model.GameResultArray, Model.n);
        //play_game();
    }

    private void launch_save()
    {
        Save_Folder_Check();
        Console.Write("ENTER FILENAME : ");
        string name = Console.ReadLine();

        string save_play_path = Path.GetFullPath(Path.Join(Model.save_path, name));
        fileInfo = new FileInfo(save_play_path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
        FileStream fileStream = File.Create(save_play_path);
        Model.SaveGame(fileStream);
        View.save_file_write(Model.save_path);
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
            Console.WriteLine("Current Turn : " + Model.GetCurrentTurn().ToUpper());
            Ask_Input();
            if (result_input == "SAVE")
            {
                launch_save();
                Ask_Input();
            }
            if (result_input == "LOAD")
            {
                launch_load();
                Console.WriteLine("Current Turn : " + Model.GetCurrentTurn().ToUpper());
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
                View.detail_input();
                View.field_write(Model.GameResultArray, Model.n);
            }
        }
    }

    public void call_first_board(int n)
    {
        View.first_board_view(Model.n);
    }

    public bool move_call(int row, int col)
    {
        if (Model.IsAlreadyPlayed(row, col))
        {
            Console.WriteLine("ALREADY FILLED!!");
            return false;
        }

        Model.PlayerPlay(row, col);
        int winner_found = Model.CheckForWinner(row, col);
        if (winner_found == 0)
        {
            View.field_write(Model.GameResultArray, Model.n);
            Model.SwitchTurn();
            return false;
        }
        show_winner(winner_found);
        return true;
    }

    public void show_winner(int winner_found)
    {
        View.field_write(Model.GameResultArray, Model.n);
        View.winner_field_write(winner_found, Model.GetCurrentTurn());
    }


}