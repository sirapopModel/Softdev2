using System;
using System.Drawing;

public class Controller
{
    public string[] index_row_col = new string[3];
    private View view;
    private Model model;
    private string result_input;

    public Controller(Model Model,View View) 
    {
        this.model = Model;
        this.view = View;
        this.result_input = "";
    }

    public void StartUp()
    {
        Console.WriteLine("Welcome to Group 1's TicTacToe Game! Please select your input.");

        while (true)
        {
            view.ShowMenuInput();
            InputDialog("Enter input: ");
            if (result_input == "1")
            {
                StartNewGame();
            }
            else if (result_input == "2")
            {
                CallLoadGame();
            }
        }
    }

    private void InputDialog(string question)
    {
        // Ask for input and store it to result_input
        while (true)
        {
            Console.Write(question);
            try
            {
                result_input = Console.ReadLine();
                break;
            }
            catch (System.Exception)
            {
                Console.Write("Wrong input. Please try again.");
            }
        }
    }

    private bool ConfirmInput(string question)
    {
        while (true)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            if (input == "y")
            {
                break;
            }
            else if (input == "n")
            {
                return false;
            }
            Console.WriteLine("Wrong input. Please try again.");
        }
        return true;
    }

    private void StartNewGame()
    {
        // Ask for board size and then play game.
        int size;
        while(true)
        {
            Console.Write("Please enter board size: ");
            try
            { 
                size = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (System.Exception)
            {
                Console.Write("Please enter only an integer.");
            }
        }

        model.ChangeBoardSize(size);
        PlayGame();
    }

    private void CallLoadGame()
    {
        // Load game and then play game.
        if (!ConfirmInput("Do you want to load game? (y/n): "))
        {
            return;
        }
        FileInfo[] Files_in_Folder = GetAllSaveFile();
        if (Files_in_Folder.Length == 0)
        {
            Console.WriteLine("No save file available.");
            return;
        }
        
        int saveSlot;
        string saveName;
        while (true)
        {
            Console.Write("\nPlease select your save file : ");
            try
            {
                saveSlot = Convert.ToInt32(Console.ReadLine());
                saveName = Files_in_Folder[saveSlot-1].Name;
                break;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Wrong input. Please enter number again.");
            }
        }
        model.LoadGame(saveName);
        PlayGame();
    }

    private void CallSaveGame()
    {
        if (!ConfirmInput("Do you want to save game? (y/n): "))
        {
            return;
        }

        GetAllSaveFile();
        Console.Write("Please enter your save name: ");
        string saveName;
        while (true)
        {
            try
            {
                saveName = Console.ReadLine();
                break;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Wrong input.");
            }
        }

        if (saveName.Substring(saveName.Length - 4) != ".txt")
        {
            saveName += ".txt";
        }

        string fullPath = Path.GetFullPath(Path.Join(model.SavePath, saveName));
        if (File.Exists(fullPath))
        {
            if (!ConfirmInput("This save is already exist. Do you want to replace? (y/n): "))
            {
                return;
            }
        }
        model.SaveGame(saveName);
        Console.WriteLine("Your game has been saved.");
    }
    private void PlayGame()
    {
        while (true)
        {
            view.ShowInput();
            view.ShowBoard(model.GetBoardArrayToString());
            Console.WriteLine("Current Turn : " + model.GetCurrentTurn().ToUpper());
            InputDialog("Enter input: ");
            if (result_input == "exit")
            {
                break;
            }
            else if (result_input == "save")
            {
                CallSaveGame();
            }
            else
            {
                try
                {
                    index_row_col = result_input.Split(",");
                    string row_string = index_row_col[0];
                    string col_string = index_row_col[1];
                    if (PlayMove(Convert.ToInt32(row_string), Convert.ToInt32(col_string)))
                    {
                        break;
                    }
                }
                catch (System.Exception)
                {
                    view.detail_input();
                }
            }
        }
    }

    private bool PlayMove(int row, int col)
    {
        string currentTurn = model.GetCurrentTurn();
        if (!model.PlayerPlay(row, col))
        {
            Console.WriteLine("ALREADY FILLED!!");
            return false;
        }

        int winner_found = model.CheckEndGame(row, col);
        if (winner_found == 0)
        {
            return false;
        }
        view.ShowBoard(model.GetBoardArrayToString());
        view.winner_field_write(winner_found, currentTurn);
        return true;
    }

    private FileInfo[] GetAllSaveFile() 
    {
        if (!Directory.Exists(model.SavePath))
        {
            Directory.CreateDirectory(model.SavePath);
        }

        DirectoryInfo save_folder = new DirectoryInfo(model.SavePath);
        FileInfo[] Files_in_Folder = save_folder.GetFiles("*.txt");

        Console.WriteLine("\nSave folder contains:");
        int index = 1;
        foreach (FileInfo file in Files_in_Folder)
        {
            Console.WriteLine(index + ". " + file.Name);
            index++;
        }

        return Files_in_Folder;
    }
}