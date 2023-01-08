using System;
class Program
{
    public static void Main(string[] args)
    {
        my_control controller_call = new my_control();

        Console.WriteLine("PLAY or LOAD");
        var ANS = Console.ReadLine();
        if (ANS == "PLAY")
        {
            Console.WriteLine("ENTER SIZE ");
            int n = Convert.ToInt32(Console.ReadLine());
            controller_call.n = n;
            controller_call.call_first_board(n);
            controller_call.play_game();
        }
        else if (ANS == "LOAD")
        {
            Console.WriteLine("SELECT SAVE FILE : ");
            controller_call.save_slot_show();
            Console.WriteLine("");
            Console.Write("TYPE YOUR SAVE NAME : ");
            string save_name = Console.ReadLine();
            controller_call.launch_load(save_name);
        }
        else
        {
            Console.WriteLine("     !!JUST TYPE PLAY OR LOAD!!      ");
        }


    }


}