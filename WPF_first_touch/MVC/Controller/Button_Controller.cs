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
            view.grid_size =  300/ n;

            data.CreateArray(n);
            //data.checked_array = new Button[n][];
            //set grid property
            view.grid_field = new Grid();
            view.grid_field.Background = new SolidColorBrush(Colors.Cornsilk);
            view.grid_field.ShowGridLines = true;
            Canvas.SetLeft(view.grid_field , 125 );
            


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

        public void serve_component_to_view(Label Count_Label , Label OX_turn_label)
        {
            view.label_num_count = Count_Label;
            view.label_OX_turn = OX_turn_label;
        }

        public void reset_label()
        {

        }
        public void grid_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(view.grid_field);
            int row = (int)(my_point.Y / view.grid_size);
            int col = (int)(my_point.X / view.grid_size);

            if ( !data.IsAlreadyPlayed(row,col) )
            {
                data.PlayerPlay(row, col);
                bool winner_found = data.CheckForWinner(row, col);
                view.num_turn_update(data.TurnCount);
                

                if (data.Is_X_turn())
                {
                    view.X_model(row, col);
                    if (winner_found == true)
                    {
                        view.num_turn_update(data.TurnCount);
                        MessageBox.Show("winner is X", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        data.ClearAllArray();
                        return;

                    }
                    
                }
                else
                {
                    view.O_model(row, col);
                    if (winner_found == true)
                    {
                        view.num_turn_update(data.TurnCount);
                        MessageBox.Show("winner is O", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        data.ClearAllArray();
                        return;

                    }
                }
                if (data.IsDraw())
                {
                    view.num_turn_update(data.TurnCount);
                    MessageBox.Show("Draw", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    data.ClearAllArray();
                    return;
                }

                
                data.SwitchTurn();
                view.XO_turn_update(data.Is_X_turn());
            }
            





        }



    }

}
