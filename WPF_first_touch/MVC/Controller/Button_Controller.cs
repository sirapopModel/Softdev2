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
using WPF_first_touch.MVC;
using WPF_first_touch.MVC.View;
using System.Windows.Xps.Serialization;

namespace WPF_first_touch.MVC.Controller

{
    public class Button_Controller
    {
        public Model model;

        public View.View view ;

        public Button_Controller(Model model , View.View view) 
        {
            this.model = model;
            this.view = view;
        }
        public void Play_Setup(int n)
        {
            model.ChangeBoardSize(n);
            view.Create_board(Canvas_field_click, Canvas_Mouse_Move);
        }

        public void Canvas_Mouse_Move(object sender, MouseEventArgs e)
        {
            Canvas Canvas_field = (Canvas)sender;
            Canvas_field.Cursor = Cursors.Hand;
        }

        public void Made_empty_Array(int n)
        {
            model.ChangeBoardSize(n);
        }

       
       
        private void Canvas_field_click(object sender, MouseButtonEventArgs e)
        {
            Point my_point = e.GetPosition(view.Canvas_field);
            
            int row = Convert.ToInt32(Math.Floor(my_point.Y/view.grid_size));
            int col = Convert.ToInt32(Math.Floor(my_point.X / view.grid_size));
            

            if (model.PlayerPlay(row, col) )
            {
                int winner_found = model.CheckEndGame(row, col);
                view.label_update();

                
                if (model.GetCurrentTurn() == "x")
                {
                    view.X_draw(row, col);
                    if (winner_found >0)
                    {
                        view.label_update();
                        view.winner_show(winner_found, row, col);
                        MessageBox.Show("winner is X", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.Canvas_field.IsEnabled = false;
                        return;
                    }
                }
                else
                {
                    view.O_draw(row, col);
                    if (winner_found >0)
                    {
                        view.label_update();
                        view.winner_show(winner_found, row, col);
                        MessageBox.Show("winner is O", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        view.Canvas_field.IsEnabled = false;
                        return;
                    }
                }
                if (winner_found == -1 )
                {
                    view.label_update();
                    MessageBox.Show("Draw", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }


               
                view.label_update();
                Array.Clear(view.x_array,0,view.x_array.Length);
                Array.Clear(view.o_cooardinate_list, 0, view.o_cooardinate_list.Length);

            }
        }

        public void Do_save()
        {
            String Savefile_name = view.Save_window_call();
            if (Savefile_name != null)
            {
                model.SaveGame(Savefile_name);
            }
        }

        
        public void Do_load()
        {
            String Loadfile_name = view.Load_window_call();

            if (Loadfile_name != null)
            {
                model.LoadGame(Loadfile_name);
                
                view.Create_board(Canvas_field_click , Canvas_Mouse_Move);

                for (int row = 0; row < model.BoardSize; row++)
                {
                    for (int col = 0; col < model.BoardSize; col++)
                    {
                        //Console.Write(data.GameResultArray[row,col]);
                        if ( model.GetBoardValue(row,col) == "x")
                        {
                            view.X_draw(row , col);
                        }
                        else if (model.GetBoardValue(row, col) == "o")
                        {
                            view.O_draw(row, col);
                        }
                    }
                }

                view.label_update();
            }
        }
    }
}
