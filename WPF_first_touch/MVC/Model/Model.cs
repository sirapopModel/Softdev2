using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;


public class Model
{
    private string _savePath = Path.GetFullPath(Path.Join(Directory.GetCurrentDirectory(), "Save"));
    public string SavePath
    {
        get { return _savePath; }
    }

    private int _turnsPassed = 0;
    public int TurnsPassed
    {
        get { return _turnsPassed; }
    }

    private int boardSize;
    private string[,] boardArray = new string[3, 3];
    private int turnCheck = 0;

    public int GetBoardSize()
    {
        return boardSize;
    }
    public string GetBoardValue(int row, int column)
    {
        return boardArray[row, column];
    }

    public void NewGame(int size)
    {
        // Change BoardSize, Create new array,
        // reset Turncount to 0.
        boardSize = size;
        boardArray = new string[size, size];
        _turnsPassed = 0;
    }

    public string GetCurrentTurn()
    {
        // Return string current turn.
        if (turnCheck == 0)
        {
            return "X";
        }
        return "O";
    }

    public void SetValue(int row, int column)
    {
        // Insert "x" or "o" into boardArray and switch turn.
        boardArray[row, column] = GetCurrentTurn();
        _turnsPassed++;
        if (CheckWin(row,column) == 0)
        {
            SwitchTurn();
        }
    }

    public int CheckWin(int row, int column)
    {
        // Return 0 if the game not end yet.
        // Return 1 if win by horizontal.
        // Return 2 if win by vertical.
        // Return 3 if win by diagonal from top left to bottom right \.
        // Return 4 if win by diagonal form top right to bottom left /.
        // Return -1 if tie.

        // Check win for horizontal.
        for (int i = 1; i < boardSize; i++)
        {
            if (boardArray[row, 0] != boardArray[row, i] || String.IsNullOrEmpty(boardArray[row, i]))
            {
                break;
            }
            if (i == boardSize - 1)
            {
                return 1;
            }
        }
        // Check win for vertical.
        for (int i = 1; i < boardSize; i++)
        {
            if (boardArray[0, column] != boardArray[i, column] || String.IsNullOrEmpty(boardArray[i, column]))
            {
                break;
            }
            if (i == boardSize - 1)
            {
                return 2;
            }
        }
        // Check win for diagonal 1.
        if (row == column)
        {
            for (int i = 1; i < boardSize; i++)
            {
                if (boardArray[0, 0] != boardArray[i, i] || String.IsNullOrEmpty(boardArray[i, i]))
                {
                    break;
                }
                if (i == boardSize - 1)
                {
                    return 3;
                }
            }
        }
        // Check win for diagonal 2.
        if (row + column == boardSize - 1)
        {
            for (int i = 1; i < boardSize; i++)
            {
                if (boardArray[0, boardSize - 1] != boardArray[i, boardSize - 1 - i] || String.IsNullOrEmpty(boardArray[i, boardSize - 1 - i]))
                {
                    break;
                }
                if (i == boardSize - 1)
                {
                    return 4;
                }
            }
        }
        // Check for tie.
        if (TurnsPassed == (boardSize * boardSize))
        {
            return -1;
        }
        return 0;
    }

    public void SaveGame(string fullPath)
    {
        // Save in .txt file
        if (fullPath.Substring(fullPath.Length - 4) != ".txt")
        {
            fullPath += ".txt";
        }

        // Replace file if saveName exist.
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        StreamWriter streamWriter = new StreamWriter(fullPath);
        streamWriter.WriteLine(boardSize);
        streamWriter.WriteLine(GetBoardArrayToString());
        streamWriter.WriteLine(GetCurrentTurn());
        streamWriter.Write(TurnsPassed);
        streamWriter.Close();

    }

    public void LoadGame(string fullPath)
    {
        if (!File.Exists(fullPath))
        {
            return;
        }

        string[] allLines = File.ReadAllLines(fullPath);
        try
        {
            boardSize = Int32.Parse(allLines[0]);
            NewGame(boardSize);

            string boardArray = allLines[1];
            UpdateArray(boardArray);

            string currentTurn = allLines[2];
            SetTurn(currentTurn);

            _turnsPassed = Int32.Parse(allLines[3]);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Wrong save file format.");
            Console.WriteLine(e.Message);
            return;
        }
        return;
    }

    private void UpdateArray(string resultText)
    {
        int indexText = 0;
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (resultText[indexText] == 'n')
                {
                    boardArray[row, col] = "";
                }
                else
                {
                    boardArray[row, col] = resultText[indexText].ToString().ToUpper();
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
                result += Text.ToLower();
            }
        }
        return result;
    }
    private void SwitchTurn()
    {
        // Switch player's turn.
        turnCheck++;
        turnCheck %= 2;
    }
}