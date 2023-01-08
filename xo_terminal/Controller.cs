using System;
public class my_control
{
    public string[] index_row_col = new string[3];
    public int n;
    public View terminal_call;
    public game_data data;
    public my_control(int k)
    {
        n = k;
        terminal_call = new View(k);

        // Model
        data = new game_data();
        data.CreateArray(k);
    }

    public void launch_menu()
    {


    }

    public void play_game()
    {

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Current Turn : " + get_turn_string().ToUpper());
            Console.Write("ENTER ROW AND COLUMN like rol,col: ");
            var result = Console.ReadLine();
            if (result == "SAVE")
            {

            }
            else if (result == "LOAD")
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
    public string get_turn_string()
    {
        return data.GetCurrentTurn();
    }

}