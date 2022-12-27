using WPF_first_touch.MVC.Model;
using System;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WPF_first_touch;

namespace WPF_first_touch.MVC.Controller

{
    public class Button_Controller
    {
        public game_data data = new game_data();
        public View view = new View();
        public void Play_Setup(int n)
        {
            data.n = n;
            
            view.grid_size = 300/n ;

            view.sheet_2d_array = new Canvas[n, n];
            view.grid_size = 300 / n;

            data.CreateArray(n);
            //data.checked_array = new Button[n][];
            //set grid property
            view.grid_field = new Grid();
            view.grid_field.Background = new SolidColorBrush(Colors.Cornsilk);
            view.grid_field.ShowGridLines = true;


            view.sheet_2d_array = new Canvas[n, n];
            view.X_size_config(n);

            view.O_size_config(n);

           
            for (int Row = 0; Row < n; Row++)

            {
                RowDefinition R = new RowDefinition();
                R.Height = new GridLength(view.grid_size);
                view.grid_field.RowDefinitions.Add(R);
            }
            for (int Col = 0; Col < n; Col++)
            {
                ColumnDefinition C = new ColumnDefinition();
                C.Width = new GridLength(view.grid_size);
                view.grid_field.ColumnDefinitions.Add(C);
            }

            for (int Row = 0; Row < n; Row++)
            {
                for (int Col = 0; Col < n; Col++)
                {
                    Canvas temp = new Canvas();
                    view.sheet_2d_array[Row, Col] = temp;
                    Grid.SetRow(temp, Row);
                    Grid.SetColumn(temp, Col);
                    view.grid_field.Children.Add(temp);
                }
            }
            view.grid_field.MouseDown += new MouseButtonEventHandler(grid_click);
        }

        public void grid_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(view.grid_field);
            int row = (int)(my_point.Y / view.grid_size);
            int col = (int)(my_point.X / view.grid_size);
            
            //TextBlock temp = new TextBlock();
            //temp.Text = "Hello";
            //Grid.SetRow(temp,row);
            //Grid.SetColumn(temp, col);
            //grid_field.Children.Add(temp);

            if (data.GameResultArray[row,col] == null)
            {
                data.PlayerPlay(row, col);
                data.CheckForWinner(row, col);
                if (data.Is_X_turn())
                {
                    view.X_model(row, col);
                    
                }
                else
                {
                    view.O_model(row, col);

                }

                
            }
            





        }



    }

}
