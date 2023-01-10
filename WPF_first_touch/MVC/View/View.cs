using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_first_touch.MVC.Model;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WPF_first_touch.MVC.View
{
    public class my_View
    {
        //public game_data data = new game_data(); //model

        public Point[] x_array = new Point[4] ;
       
        //public Canvas[,] sheet_2d_array;

        //public Grid grid_field = new Grid() ;
        public Canvas grid_field_old_one ;
        public int grid_size;

        public Storyboard x_Story = new Storyboard();
        public Storyboard x_Story1 = new Storyboard();

        public int o_size = 0 ;
        public int o_position_x = 0 ;
        public int o_position_y = 0;

        public Point[] o_cooardinate_list = new Point[721] ;
        public double one_radian = 3.14 / 360 ;
        public Storyboard o_Story = new Storyboard();

        public SaveFileDialog my_save_window = new SaveFileDialog();
        string save_path = Directory.GetCurrentDirectory() + "\\Save";

        public OpenFileDialog my_open_window = new OpenFileDialog();

        
        public Label label_num_count ;
        public Label label_OX_turn;

        public Canvas Canvas_field;

        Line my_line = new Line();
        Line my_line1 = new Line();

        //public void 



        public void num_turn_update(int turn_count) 
        {
            label_num_count.Content = turn_count.ToString();
            
        }

        public void XO_turn_update(int check_turn)
        {
            if (check_turn == 0) 
            {
                label_OX_turn.Content = "X";
            }
            else
            {
                label_OX_turn.Content = "O";
            }
        }

        public Stream Save_window_call()

        {
            MessageBoxResult confirm_result = MessageBox.Show("Do you want to save file?","Alert!!",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if ( confirm_result == MessageBoxResult.Yes)
            {
                my_save_window.InitialDirectory = save_path;
                my_save_window.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                my_save_window.FilterIndex = 1;

                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                
                if (my_save_window.ShowDialog() == true) // press save the saveFileDialog.show will return true
                {

                    return my_save_window.OpenFile();
                    

                }
            }
            return null;
        }

        public Stream Load_window_call()
        {
            MessageBoxResult confirm_result = MessageBox.Show("Do you want to Load save?", "Alert!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm_result == MessageBoxResult.Yes)
            {
                my_open_window.InitialDirectory = save_path;
                my_open_window.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                my_open_window.FilterIndex = 1;

                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }

                if (my_open_window.ShowDialog() == true) // press save the saveFileDialog.show will return true
                {

                    return my_open_window.OpenFile();

                }
            }
            return null;


        }


        public void O_model(int row, int col)
        {
            for (int i = 0; i< 720; i++)
            {

                my_line = new Line();
                my_line.StrokeThickness = 4;
                my_line.Stroke = Brushes.Red;

                double start_point_X = o_cooardinate_list[i].X;
                double start_point_Y = o_cooardinate_list[i].Y;
                double end_point_X = o_cooardinate_list[i+1].X;
                double end_point_Y = o_cooardinate_list[i+1].Y;

                my_line.X1 = start_point_X;
                my_line.Y1 = start_point_Y;
                my_line.X2 = start_point_X;
                my_line.Y2 = start_point_Y;

                Canvas_field.Children.Add(my_line);
                //sheet_2d_array[row, col].Children.Add(my_line);
                DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(0.2)));
                varX.BeginTime = TimeSpan.FromMilliseconds(i);
                DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(0.2)));
                varY.BeginTime = TimeSpan.FromMilliseconds(i);

                o_Story.Children.Add(varX);
                o_Story.Children.Add(varY);
                Storyboard.SetTarget(varX, my_line);
                Storyboard.SetTarget(varY, my_line);
                Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
                
            }
            o_Story.Begin();
            o_Story.Children.Clear();
        }

        public void O_size_config(int n , int row , int col)
        {
            o_size = 210/(2*n) ;
            o_position_x = (45 / n) + (col* grid_size ) ;
            o_position_y = (45 / n) + (row * grid_size);
            
            for (int i = 0; i < 720; i++)
            {
                Double x_point = Math.Round( ((o_size)*Math.Cos(i*one_radian)+ (o_size)) + o_position_x ,5);
                Double y_point = Math.Round(((o_size) * Math.Sin(i*one_radian)+ (o_size)) + o_position_y ,5);
                o_cooardinate_list[i] = new Point( x_point, y_point);
                o_cooardinate_list[720] = o_cooardinate_list[1];
            }
            //o_cooardinate_list[360] = o_cooardinate_list[359];
        }
        public void X_size_config(int n , int row , int col)
        {
            x_array[0] = new Point( (60/n)+col*grid_size ,(60/n)+row*grid_size);
            x_array[1] = new Point((240 / n) + col * grid_size, (240 / n) + row * grid_size );
            x_array[2] = new Point( (60 / n) + col * grid_size, (240 / n) +row * grid_size );
            x_array[3] = new Point( (240 / n) + col * grid_size, (60 / n) + row * grid_size);
        }
        public void X_model(int row, int col)
        {
            // line property
            my_line = new Line();
            my_line.StrokeThickness = 4;
            my_line.Stroke = Brushes.Blue;
            my_line1 = new Line();
            my_line1.StrokeThickness = 4;
            my_line1.Stroke = Brushes.Blue;

            // set variable
            double start_point_X = x_array[0].X;
            double start_point_Y = x_array[0].Y;
            double end_point_X = x_array[1].X; ;
            double end_point_Y = x_array[1].Y; ;
            double start_point1_X = x_array[2].X;
            double start_point1_Y = x_array[2].Y;
            double end_point1_X = x_array[3].X; ;
            double end_point1_Y = x_array[3].Y; ;
            //set initial state of line and that to UI
            my_line.X1 = start_point_X;
            my_line.Y1 = start_point_Y;
            my_line.X2 = start_point_X;
            my_line.Y2 = start_point_Y;
            my_line1.X1 = start_point1_X;
            my_line1.Y1 = start_point1_Y;
            my_line1.X2 = start_point1_X;
            my_line1.Y2 = start_point1_Y;

            //Canvas.SetLeft(my_line, x_array[0].X);
           // Canvas.SetTop(my_line, x_array[0].Y);
            //Canvas.SetLeft(my_line1, x_array[2].X);
            //Canvas.SetTop(my_line1, x_array[2].Y);
            Canvas_field.Children.Add(my_line);
            Canvas_field.Children.Add(my_line1);
            //Grid.SetRow(my_line, row);
            //Grid.SetColumn(my_line, col);
            //sheet_2d_array[row, col].Children.Add(my_line);
            //sheet_2d_array[row, col].Children.Add(my_line1);
            //create animation
            DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(300)));
            DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(300)));
            varX.BeginTime = TimeSpan.FromMilliseconds(0);
            varY.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation varX1 = new DoubleAnimation(end_point1_X, new Duration(TimeSpan.FromMilliseconds(300)));
            DoubleAnimation varY1 = new DoubleAnimation(end_point1_Y, new Duration(TimeSpan.FromMilliseconds(300)));
            varX1.BeginTime = TimeSpan.FromMilliseconds(350);
            varY1.BeginTime = TimeSpan.FromMilliseconds(350);

            //connect an animation to story board

            x_Story.Children.Add(varX);
            x_Story.Children.Add(varY);
            x_Story1.Children.Add(varX1);
            x_Story1.Children.Add(varY1);

            // add property of animation in this case line property 
            Storyboard.SetTarget(varX, my_line);
            Storyboard.SetTarget(varY, my_line);
            Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
            Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
            x_Story.Begin();
            Storyboard.SetTarget(varX1, my_line1);
            Storyboard.SetTarget(varY1, my_line1);
            Storyboard.SetTargetProperty(varX1, new PropertyPath(Line.X2Property));
            Storyboard.SetTargetProperty(varY1, new PropertyPath(Line.Y2Property));
            x_Story1.Begin();

            x_Story.Children.Clear();
            x_Story1.Children.Clear();

        }
    }
}
