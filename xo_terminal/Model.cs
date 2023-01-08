using System;


public class game_data
{
    public string save_path = Path.GetFullPath(Path.Join(Directory.GetCurrentDirectory(), "Save"));
    public int n;
    private int _turnCheck = 0;
    public string[,] GameResultArray = new string[3, 3];
    public int TurnCount = 0;

    public void ClearAllArray() => Array.Clear(GameResultArray, 0, GameResultArray.Length);
    public void CreateArray(int size)
    {
        // Set n = size. Clear all array and create new string.
        n = size;
        ClearAllArray();
        GameResultArray = new string[size, size];
        TurnCount = 0;
    }
    public int check_turn()
    {
        // Return true if it's Player_x's turn, otherwise false.
        return _turnCheck;
    }


    public void SwitchTurn()
    {
        // Switch player's turn.
        if (_turnCheck == 2)
        {
            _turnCheck = 0;
        }
        else
        {
            _turnCheck++;
        }
    }

    public void PlayerPlay(int row, int column)
    {
        // If already played, return
        if (IsAlreadyPlayed(row, column)) { return; }

        // Insert "x" or "o" into GameResultArray when player plays.
        //GameResultArray[row, column] = (Is_X_turn()) ? "x" : "o";
        if (_turnCheck == 0)
        {
            GameResultArray[row, column] = "x";
        }
        else if (_turnCheck == 1)
        {
            GameResultArray[row, column] = "o";
        }
        else if (_turnCheck == 2)
        {
            GameResultArray[row, column] = "l";
        }
        TurnCount++;
    }

    public Boolean IsAlreadyPlayed(int row, int column)
    {
        // Return ture if that row and column is already played.
        return !String.IsNullOrWhiteSpace(GameResultArray[row, column]);
    }

    public int CheckForWinner(int row, int column)
    {
        // Check win for horizontal.
        for (int i = 1; i < n; i++)
        {
            if (GameResultArray[row, 0] != GameResultArray[row, i] || String.IsNullOrEmpty(GameResultArray[row, i]))
            {
                break;
            }
            if (i == n - 1)
            {
                return 1;
            }
        }
        // Check win for vertical.
        for (int i = 1; i < n; i++)
        {
            if (GameResultArray[0, column] != GameResultArray[i, column] || String.IsNullOrEmpty(GameResultArray[i, column]))
            {
                break;
            }
            if (i == n - 1)
            {
                return 2;
            }
        }
        // Check win for diagonal 1.
        if (row == column)
        {
            for (int i = 1; i < n; i++)
            {
                if (GameResultArray[0, 0] != GameResultArray[i, i] || String.IsNullOrEmpty(GameResultArray[i, i]))
                {
                    break;
                }
                if (i == n - 1)
                {
                    return 3;
                }
            }
        }
        // Check win for diagonal 2.
        if (row + column == n - 1)
        {
            for (int i = 1; i < n; i++)
            {
                if (GameResultArray[0, n - 1] != GameResultArray[i, n - 1 - i] || String.IsNullOrEmpty(GameResultArray[i, n - 1 - i]))
                {
                    break;
                }
                if (i == n - 1)
                {
                    return 4;
                }
            }
        }
        return 0;
    }

    public Boolean IsDraw()
    {
        // Return true if TurnCount equal to n*n. That means all grid have played.
        return (TurnCount == n * n) ? true : false;
    }

    public void SaveGame(Stream FileStream)
    {
        StreamWriter streamWriter = new StreamWriter(FileStream);
        streamWriter.WriteLine(n);
        streamWriter.WriteLine(GetArrayToString());
        streamWriter.WriteLine(GetCurrentTurn());
        streamWriter.Write(TurnCount);
        streamWriter.Close();

    }

    public string GetArrayToString()
    {
        string Result = "";
        foreach (string Text in GameResultArray)
        {
            if (String.IsNullOrEmpty(Text))
            {
                Result += "n";
            }
            else
            {
                Result += Text;
            }
        }
        return Result;
    }

    public string GetCurrentTurn()
    {
        if (_turnCheck == 0)
        {
            return "x";
        }
        else if (_turnCheck == 1)
        {
            return "o";
        }
        return "l";
    }

    public Boolean LoadGame(Stream FileStream)

    {
        // if return is true = not error
        try
        {
            StreamReader streamReader = new StreamReader(FileStream);
            n = Int32.Parse(streamReader.ReadLine());
            string ResultText = streamReader.ReadLine();
            string NowTurn = streamReader.ReadLine();
            CreateArray(n);
            TurnCount = Int32.Parse(streamReader.ReadLine());
            UpdateArray(ResultText);
            //SetTurn(NowTurn);
            streamReader.Close();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }

    public void UpdateArray(string ResultText)
    {
        int IndexText = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (ResultText[IndexText] == 'n')
                {
                    GameResultArray[row, col] = "";
                }
                else
                {
                    GameResultArray[row, col] = ResultText[IndexText].ToString();
                }
                IndexText++;
            }
        }
    }

    public void SetTurn(string Turn)
    {
        //_turnCheck = (Turn == "x") ? true : false;

    }




}

