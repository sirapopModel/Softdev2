
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
using System.IO;
using WPF_first_touch.MVC.Model;
using WPF_first_touch.MVC.View;

namespace WPF_first_touch.MVC.Controller

{
    public class Button_Controller
    {
        public game_data data = new game_data();

        public View.my_View view = new View.my_View();

       
        

        public void Made_empty_Array(int n)
        {
            data.CreateArray(n);
        }
        public void Play_Setup(int n)
        {
            data.n = n;

            view.grid_size =  300/ n;
            view.field_size = view.grid_size * n;
            //1
            view.Canvas_field = new Canvas();
        
            view.Canvas_field.Height = view.field_size;
            view.Canvas_field.Width = view.field_size ;
            view.Canvas_field.Background = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(view.Canvas_field, 125);
            view.Canvas_field.MouseDown += new MouseButtonEventHandler(Canvas_field_click);
            view.Canvas_field.MouseMove += new MouseEventHandler(view.Canvas_field_Enter);

            view.Grid_line_gen(data.n);
            

        }


        public void serve_component_to_view(Label Count_Label , Label OX_turn_label)
        {
            view.label_num_count = Count_Label;
            view.label_OX_turn = OX_turn_label;
        }
       

        public void Canvas_field_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(view.Canvas_field);
            
            int row = Convert.ToInt32(Math.Floor(my_point.Y/view.grid_size));
            int col = Convert.ToInt32(Math.Floor(my_point.X / view.grid_size));
            

            if ( !data.IsAlreadyPlayed(row,col) )
            {
                data.PlayerPlay(row, col);
                int winner_found = data.CheckForWinner(row, col);
                view.num_turn_update(data.TurnCount);
                

                if (data.check_turn() == 0)
                {
                    view.X_draw(data.n,row, col);
                    if (winner_found >0)
                    {
                        view.num_turn_update(data.TurnCount);

                        //view.Hight_light_winner(row, col,winner_found,data.n);
                        MessageBox.Show("winner is X", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.Canvas_field.IsEnabled = false;
                        //view.Hight_light_winner(row, col,winner_found,data.n);
                        
                        

                        //data.ClearAllArray();
                        return;

                    }
                    
                }
                else
                {
                    view.O_draw(data.n,row, col);
                    if (winner_found >0)
                    {
                        view.num_turn_update(data.TurnCount);
                        //view.Hight_light_winner(row, col, winner_found, data.n);
                        MessageBox.Show("winner is O", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.Canvas_field.IsEnabled = false;
                        //view.Hight_light_winner(row, col, winner_found, data.n);
                       
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
                Array.Clear(view.x_array,0,view.x_array.Length);
                Array.Clear(view.o_cooardinate_list, 0, view.o_cooardinate_list.Length);

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
                          
                            view.X_draw(data.n ,row , col);
                        }
                        else if (data.GameResultArray[row, col] == "o")
                        {
                           
                            view.O_draw(data.n,row, col);
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
