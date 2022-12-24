using Model;
using System;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
namespace Controller

{
    public class Button_Controller
    {
        public game_data data = new game_data();
        public void Play_Setup(int n)
        {
            int count = 1 ;
            data.button_size = 300/n ;
            data.n = n;
            data.checked_array = new Button[n][];
  
            for (int Row = 0; Row < n; Row ++ )
            {
                data.checked_array[Row] = new Button[n];
                for (int Column = 0; Column < n; Column++)
                {
                    //Button
                    Button temp = new Button();
                    temp.Width = data.button_size;
                    temp.Height = data.button_size;
                    temp.Content = (count).ToString() ;
                    temp.Name = "Button" + (Row + Column).ToString();
                    data.checked_array[Row][Column] = temp;
                    //temp.Style = "{StaticResource Touch_Button}";
                    count++;
                }
            }
        }
    }
}
