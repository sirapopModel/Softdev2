using Model;
using System;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WPF_first_touch;

namespace Controller

{
    public class Button_Controller
    {
        public game_data data = new game_data();
        public View view = new View();
        public void Play_Setup(int n)
        {
            view.sheet_2d_array = new Canvas[n,n];
            data.grid_size = 300/n ;
            data.n = n;
            //data.checked_array = new Button[n][];
            //set grid property
            data.grid_field = new Grid();
            data.grid_field.Background = new SolidColorBrush(Colors.Cornsilk);
            data.grid_field.ShowGridLines = true;

            for (int Row = 0; Row < n; Row ++ )
            {
                RowDefinition R = new RowDefinition();
                R.Height = new GridLength(data.grid_size);
                data.grid_field.RowDefinitions.Add(R);
            }
            for (int Col = 0; Col < n; Col++)
            {
                ColumnDefinition C = new ColumnDefinition();
                C.Width = new GridLength(data.grid_size);
                data.grid_field.ColumnDefinitions.Add(C);
            }
            
            for (int Row =0; Row< n; Row++)
            {
                for (int Col=0; Col <n; Col++)
                {
                    Canvas temp = new Canvas();
                    view.sheet_2d_array[Row,Col] = temp;
                    Grid.SetRow(temp,Row);
                    Grid.SetColumn(temp, Col);
                    data.grid_field.Children.Add(temp);
                }
            }
            data.grid_field.MouseDown += new MouseButtonEventHandler(grid_click);
        }

        public void grid_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(data.grid_field);
            int row = (int)(my_point.Y / data.grid_size);
            int col = (int)(my_point.X / data.grid_size);
            //TextBlock temp = new TextBlock();
            //temp.Text = "Hello";
            //Grid.SetRow(temp,row);
            //Grid.SetColumn(temp, col);
            //grid_field.Children.Add(temp);
            view.X_model(row, col);

        }



    }

}
