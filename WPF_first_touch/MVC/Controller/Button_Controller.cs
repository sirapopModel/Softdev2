using System;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WPF_first_touch;
using System.IO;
using WPF_first_touch.MVC.Model;
using WPF_first_touch.MVC.View;

namespace WPF_first_touch.MVC.Controller

{
    public class Button_Controller
    {
        public game_data data = new game_data();
        public View.View view = new View.View();

        public void Made_empty_Array(int n)
        {
            data.CreateArray(n);
        }
        public void Play_Setup(int n)
        {
            data.n = n;
            
            view.grid_size = 300/n ;

            view.sheet_2d_array = new Canvas[n, n];
            view.grid_size =  300/ n;

            
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

        public void grid_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(view.grid_field);
            int row = (int)(my_point.Y / view.grid_size);
            int col = (int)(my_point.X / view.grid_size);

            if ( !data.IsAlreadyPlayed(row,col) )
            {
                data.PlayerPlay(row, col);
                int winner_found = data.CheckForWinner(row, col);
                view.num_turn_update(data.TurnCount);
                

                if (data.check_turn() == 0)
                {
                    view.X_model(row, col);
                    if (winner_found >0)
                    {
                        view.num_turn_update(data.TurnCount);
                        view.Hight_light_winner(row, col,winner_found,data.n);
                        MessageBox.Show("winner is X", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.grid_field.IsEnabled = false;
                        //data.ClearAllArray();
                        return;

                    }
                    
                }
                else
                {
                    view.O_model(row, col);
                    if (winner_found >0)
                    {
                        view.num_turn_update(data.TurnCount);
                        view.Hight_light_winner(row, col, winner_found, data.n);
                        MessageBox.Show("winner is O", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.grid_field.IsEnabled = false;

                        return;

                    }
                }
                if (data.IsDraw())
                {
                    view.num_turn_update(data.TurnCount);
                    MessageBox.Show("Draw", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    return;
                }

                
                data.SwitchTurn();
                view.XO_turn_update(data.check_turn());
            }
        }

        public void Do_save()
        {
            
            Stream Savefile = view.Save_window_call();

            if (Savefile != null)
            {
                data.SaveGame(Savefile);

            }

        }

        public Boolean Do_load()
        {
            Stream Loadfile = view.Load_window_call();

            if (Loadfile != null)
            {
                data.LoadGame(Loadfile);

                Play_Setup(data.n);

                for (int row = 0; row < data.n; row++)
                {
                    for (int col = 0; col < data.n; col++)
                    {
                        Console.Write(data.GameResultArray[row,col]);
                        if (data.GameResultArray[row,col] == "x")
                        {
                            view.X_model(row , col);
                        }
                        else if (data.GameResultArray[row, col] == "o")
                        {
                            view.O_model(row, col);
                        }
                    }
                    
                }
                view.XO_turn_update(data.check_turn());
                view.num_turn_update(data.TurnCount);
                Loadfile = null;
                return true;
            }
            return false;
            
        }

        



    }

}
