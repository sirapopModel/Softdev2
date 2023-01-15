using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

public class Model
{
    public string SavePath { get;}    
    public int BoardSize { get; protected set; }
    public int TurnCount { get; protected set; }

    private string[,] boardArray = new string[3, 3];
    private int turnCheck = 0;

    public Model()
    {
        this.SavePath = Path.GetFullPath(Path.Join(Directory.GetCurrentDirectory(), "Save"));
        this.TurnCount = 0;
    }
    public string GetBoardValue(int row,int column)
    {
        return boardArray[row,column];
    }

    public void ChangeBoardSize(int size)
    {
        // Change BoardSize, Create new array,
        // reset Turncount to 0.
        BoardSize = size;
        boardArray = new string[size, size];
        TurnCount = 0;
    }

    public void SwitchTurn()
    {
        // Switch player's turn.
        turnCheck++;
        turnCheck %= 2;
    }

    public string GetCurrentTurn()
    {
        // Return string current turn.
        if (turnCheck == 0)
        {
            return "x";
        }
        return "o";
    }

    public bool PlayerPlay(int row, int column)
    {
        // If that row,column was played already, then return.
        if (!String.IsNullOrWhiteSpace(boardArray[row, column]))
        { 
            return false; 
        }

        // Insert "x" or "o" into boardArray and switch turn.
        boardArray[row, column] = GetCurrentTurn();
        TurnCount++;
        SwitchTurn();
        return true;
    }

    public int CheckEndGame(int row, int column)
    {
        // Return 0 if the game not end yet.
        // Return 1 if win by horizontal.
        // Return 2 if win by vertical.
        // Return 3 if win by diagonal from top left to bottom right \.
        // Return 4 if win by diagonal form top right to bottom left /.
        // Return -1 if tie.

        // Check win for horizontal.
        for (int i = 1; i < BoardSize; i++)
        {
            if (boardArray[row, 0] != boardArray[row, i] || String.IsNullOrEmpty(boardArray[row, i]))
            {
                break;
            }
            if (i == BoardSize - 1)
            {
                return 1;
            }
        }
        // Check win for vertical.
        for (int i = 1; i < BoardSize; i++)
        {
            if (boardArray[0, column] != boardArray[i, column] || String.IsNullOrEmpty(boardArray[i, column]))
            {
                break;
            }
            if (i == BoardSize - 1)
            {
                return 2;
            }
        }
        // Check win for diagonal 1.
        if (row == column)
        {
            for (int i = 1; i < BoardSize; i++)
            {
                if (boardArray[0, 0] != boardArray[i, i] || String.IsNullOrEmpty(boardArray[i, i]))
                {
                    break;
                }
                if (i == BoardSize - 1)
                {
                    return 3;
                }
            }
        }
        // Check win for diagonal 2.
        if (row + column == BoardSize - 1)
        {
            for (int i = 1; i < BoardSize; i++)
            {
                if (boardArray[0, BoardSize - 1] != boardArray[i, BoardSize - 1 - i] || String.IsNullOrEmpty(boardArray[i, BoardSize - 1 - i]))
                {
                    break;
                }
                if (i == BoardSize - 1)
                {
                    return 4;
                }
            }
        }
        // Check for tie.
        if (TurnCount == (BoardSize * BoardSize))
        {
            return -1;
        }
        return 0;
    }

    public void SaveGame(string saveName)
    {
        // Save in .txt file
        if (saveName.Substring(saveName.Length - 4) != ".txt")
        {
            saveName += ".txt";
        }

        // Replace file if saveName exist.
        string fullPath = Path.Join(SavePath, saveName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        StreamWriter streamWriter = new StreamWriter(fullPath);
        streamWriter.WriteLine(BoardSize);
        streamWriter.WriteLine(GetBoardArrayToString());
        streamWriter.WriteLine(GetCurrentTurn());
        streamWriter.Write(TurnCount);
        streamWriter.Close();

    }

    public bool LoadGame(string saveName)
    {
        // Return false if the loading not complete.
        // Return true if the loading is complete.

        string fullPath = Path.Join(SavePath, saveName);
        if (!File.Exists(fullPath)) 
        {
            return false;
        }

        string[] allLines = File.ReadAllLines(fullPath);
        try
        {
            BoardSize = Int32.Parse(allLines[0]);
            ChangeBoardSize(BoardSize);

            string boardArray = allLines[1];
            UpdateArray(boardArray);

            string currentTurn = allLines[2];
            SetTurn(currentTurn);

            TurnCount = Int32.Parse(allLines[3]);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Wrong save file format.");
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }

    private void UpdateArray(string resultText)
    {
        int indexText = 0;
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                if (resultText[indexText] == 'n')
                {
                    boardArray[row, col] = "";
                }
                else
                {
                    boardArray[row, col] = resultText[indexText].ToString();
                }
                indexText++;
            }
        }
    }

    private void SetTurn(string turn)
    {
        // Set current turn from string.
        if (turn == "x")
        {
            turnCheck = 0;
        }
        else
        {
            turnCheck = 1;
        }
    }

    private string GetBoardArrayToString()
    {
        // Return a string that contains all values in boardArray.
        string result = "";
        foreach (string Text in boardArray)
        {
            if (String.IsNullOrEmpty(Text))
            {
                result += "n";
            }
            else
            {
                result += Text;
            }
        }
        return result;
    }
}