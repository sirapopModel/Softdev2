using Microsoft.Win32;
using System;
using WPF_first_touch.MVC.Controller;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPF_first_touch.MVC.Model
{
    public class game_data
    {
        public string save_path = Path.GetFullPath(Path.Join(Directory.GetCurrentDirectory(), "Save"));

        public int n;
        private int _turnCheck = 0;
        public string[,] GameResultArray = new string[3, 3];
        public int TurnCount = 0;

        private void ClearAllArray() => Array.Clear(GameResultArray, 0, GameResultArray.Length);
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
            if (_turnCheck == 1)
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
            if (_turnCheck == 0)
            {
                GameResultArray[row, column] = "x";
            }
            else
            {
                GameResultArray[row, column] = "o";
            }
            TurnCount++;
        }

        public bool IsAlreadyPlayed(int row, int column)
        {
            // Return ture if that row and column is already played.
            return !string.IsNullOrWhiteSpace(GameResultArray[row, column]);
        }

        public int CheckForWinner(int row, int column)
        {
            // Check win for horizontal.
            for (int i = 1; i < n; i++)
            {
                if (GameResultArray[row, 0] != GameResultArray[row, i] || string.IsNullOrEmpty(GameResultArray[row, i]))
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
                if (GameResultArray[0, column] != GameResultArray[i, column] || string.IsNullOrEmpty(GameResultArray[i, column]))
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
                    if (GameResultArray[0, 0] != GameResultArray[i, i] || string.IsNullOrEmpty(GameResultArray[i, i]))
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
                    if (GameResultArray[0, n - 1] != GameResultArray[i, n - 1 - i] || string.IsNullOrEmpty(GameResultArray[i, n - 1 - i]))
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

        public bool IsDraw()
        {
            // Return true if TurnCount equal to n*n. That means all grid have played.
            return TurnCount == n * n ? true : false;
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

        private string GetArrayToString()
        {
            string Result = "";
            foreach (string Text in GameResultArray)
            {
                if (string.IsNullOrEmpty(Text))
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

        private string GetCurrentTurn()
        {
            if (_turnCheck == 0)
            {
                return "x";
            }
            return "o";
        }

        public bool LoadGame(Stream FileStream)

        {
            // if return is true = not error
            try
            {
                StreamReader streamReader = new StreamReader(FileStream);
                n = int.Parse(streamReader.ReadLine());
                string ResultText = streamReader.ReadLine();
                string NowTurn = streamReader.ReadLine();
                CreateArray(n);
                TurnCount = int.Parse(streamReader.ReadLine());
                UpdateArray(ResultText);
                SetTurn(NowTurn);
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private void UpdateArray(string ResultText)
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

        private void SetTurn(string Turn)
        {
            if (Turn == "x")
            {
                _turnCheck = 0;
            }
            else if (Turn == "o")
            {
                _turnCheck = 1;
            }
        }
    }
}
