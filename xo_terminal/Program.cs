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
            Console.Write("ENTER SIZE : ");
            int n = Convert.ToInt32(Console.ReadLine());
            controller_call.set_up(n);
            controller_call.call_first_board(n);
            controller_call.play_game();
        }
        else if (ANS == "LOAD")
        {
            controller_call.launch_load();
            controller_call.play_game();
        }
        else
        {
            Console.WriteLine("     !!JUST TYPE PLAY OR LOAD!!      ");
        }


    }


}