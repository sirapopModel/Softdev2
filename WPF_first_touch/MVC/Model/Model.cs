using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WPF_first_touch.MVC.Model
{
    public class game_data
    {

        public int n ;
        private Boolean _turnCheck = true ;
        public string[,] GameResultArray = new string[3, 3];
        public int TurnCount = 0 ;

        public void ClearAllArray() => Array.Clear(GameResultArray, 0, GameResultArray.Length);
        public void CreateArray(int size)
        {
            // Set n = size. Clear all array and create new string.
            n = size;
            ClearAllArray();
            GameResultArray = new string[size, size];
            TurnCount = 0;
        }
        public Boolean Is_X_turn()
        { 
            // Return true if it's Player_x's turn, otherwise false.
            return _turnCheck; 
        }

        
        public void switchTurn()
        {
            // Switch player's turn.
            _turnCheck = !_turnCheck;
        }
        
        public void PlayerPlay(int row, int column)
        {
            // If already played, return
            if (IsAlreadyPlayed(row, column)) { return; }

            // Insert "x" or "o" into GameResultArray when player plays.
            GameResultArray[row, column] = (Is_X_turn()) ? "x" : "o";
            TurnCount++;
        }

        public Boolean IsAlreadyPlayed(int row, int column)
        {
            // Return ture if that row and column is already played.
            return !String.IsNullOrWhiteSpace(GameResultArray[row, column]);
        }

        public Boolean CheckForWinner(int row, int column)
        {
            // Check win for horizontal.
            for (int i = 1; i < n; i++)
            {
                if (GameResultArray[row,0] != GameResultArray[row,i] || String.IsNullOrEmpty(GameResultArray[row, i]))
                {
                    break;
                }
                if (i == n-1)
                {
                    return true;
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
                    return true;
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
                        return true;
                    }
                }
            }
            // Check win for diagonal 2.
            if (row + column == n-1)
            {
                for (int i = 1; i < n; i++)
                {
                    if (GameResultArray[0, n-1] != GameResultArray[i, n-1-i] || String.IsNullOrEmpty(GameResultArray[i, n - 1 - i]))
                    {
                        break;
                    }
                    if (i == n - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean IsDraw()
        {
            // Return true if TurnCount equal to n*n. That means all grid have played.
            return (TurnCount == n * n) ? true : false;
        }







    }

}
