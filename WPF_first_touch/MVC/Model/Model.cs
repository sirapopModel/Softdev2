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

        public void ClearAllArray() => Array.Clear(GameResultArray, 0, GameResultArray.Length);
        public void CreateArray(int size)
        {
            n = size;
            ClearAllArray();
            GameResultArray = new string[size, size];
        }
        public Boolean Is_X_turn()
        { 
            // Return true if it's Player_x's turn, otherwise false.
            return _turnCheck; 
        }

        private void _switchTurn()
        {
            // Switch player's turn.
            _turnCheck = !_turnCheck;
        }
        
        public void PlayerPlay(int row, int column)
        {
            // If already played, return
            if (IsPlayed(row, column)) { return; }

            // Insert "x" or "o" into GameResultArray when player plays.
            GameResultArray[row, column] = (Is_X_turn()) ? "x" : "o";
            _switchTurn();
        }

        public Boolean IsPlayed(int row, int column)
        {
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
            // Check win for diaganal.
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









    }

}
