using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_first_touch.MVC;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using WPF_first_touch.MVC.Controller;

namespace WPF_first_touch.MVC.View
{
    public class View
    {
        public int field_size;
        public Point[] x_array = new Point[4];

        public int grid_size;

        public Storyboard x_Story = new Storyboard();
        public Storyboard x_Story1 = new Storyboard();

        public int o_size = 0;
        public int o_position_x = 0;
        public int o_position_y = 0;

        public Point[] o_cooardinate_list = new Point[361];
        public double one_radian = 6.28 / 360;
        public Storyboard o_Story = new Storyboard();

        public SaveFileDialog my_save_window = new SaveFileDialog();
        string save_path = Directory.GetCurrentDirectory() + "\\Save";

        public OpenFileDialog my_open_window = new OpenFileDialog();


        public Label label_num_count;
        public Label label_OX_turn;

        public Canvas Canvas_field;
        public Canvas my_Canvas;

        private Model model;

        Line my_line = new Line();
        Line my_line1 = new Line();

        public View(Model model , Canvas my_Canvas , Label label_num_count , Label label_OX_turn) 
        {
            this.model = model;
            this.my_Canvas = my_Canvas;           
            this.label_num_count = label_num_count;
            this.label_OX_turn = label_OX_turn;
        }
        public void Create_board(MouseButtonEventHandler Canvas_field_click , MouseEventHandler Canvas_Mouse_Move) 
        {
            my_Canvas.Children.Remove(Canvas_field);

            grid_size = 300 / model.BoardSize ;
            field_size = grid_size * model.BoardSize;

            Canvas_field = new Canvas();

            Canvas_field.Height = field_size;
            Canvas_field.Width = field_size;
            Canvas_field.Background = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(Canvas_field, 125);
            Canvas_field.MouseDown += new MouseButtonEventHandler(Canvas_field_click);
            Canvas_field.MouseMove += new MouseEventHandler(Canvas_Mouse_Move);
            my_Canvas.Children.Add(Canvas_field);
            Board_line_show();
            label_update();

        }

        public void Board_line_show() 
        {
            for (int row = 1; row< model.BoardSize; row++) 
            {
                draw_line(row,0, "board_horizontal");
            }
            for (int col = 1; col < model.BoardSize; col++)
            {
                draw_line(0, col, "board_vertical");
            }
        }
        

        private void draw_line(int row , int col, string type_line) 
        {
            my_line = new Line();
            my_line.StrokeThickness = 4;
            my_line.Stroke = Brushes.Black;
            double start_point_X;
            double start_point_Y;
            double end_point_X;
            double end_point_Y;
            if (type_line == "board_vertical") 
            {
                start_point_X = col*grid_size ;
                start_point_Y = 0;
                end_point_X = col*grid_size;
                end_point_Y = field_size;

            }
            else if(type_line == "board_horizontal")
            {
                start_point_X = 0;
                start_point_Y = row * grid_size;
                end_point_X = field_size;
                end_point_Y = row * grid_size;
            }
            else if(type_line == "horizontal_winner")
            {
                my_line.StrokeThickness = 10;
                my_line.Stroke = Brushes.LimeGreen;
                start_point_X = 0;
                start_point_Y = ((row + row + 1) * grid_size) / 2;
                end_point_X = field_size;
                end_point_Y = ((row + row + 1) * grid_size) / 2;
            }
            else if (type_line == "vertical_winner") 
            {
                my_line.StrokeThickness = 10;
                my_line.Stroke = Brushes.LimeGreen; 
                start_point_X = ((col + col + 1) * grid_size) / 2;
                start_point_Y = 0;
                end_point_X =  ((col + col + 1) * grid_size) / 2;
                end_point_Y = field_size;
            }
            else if (type_line == "diagonal_up_winner")
            {
                my_line.StrokeThickness = 10;
                my_line.Stroke = Brushes.LimeGreen;
                start_point_X = 0;
                start_point_Y = field_size;
                end_point_X = field_size;
                end_point_Y = 0;
            }
            else 
            {
                my_line.StrokeThickness = 10;
                my_line.Stroke = Brushes.LimeGreen; 
                start_point_X = 0;
                start_point_Y =0;
                end_point_X = field_size;
                end_point_Y = field_size;
            }
            my_line.X1 = start_point_X;
            my_line.Y1 = start_point_Y;
            my_line.X2 = start_point_X;
            my_line.Y2 = start_point_Y;

            Canvas_field.Children.Add(my_line);
            DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(1000)));
            varX.BeginTime = TimeSpan.FromMilliseconds(0);
            DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(1000)));
            varY.BeginTime = TimeSpan.FromMilliseconds(0);

            o_Story.Children.Add(varX);
            o_Story.Children.Add(varY);
            Storyboard.SetTarget(varX, my_line);
            Storyboard.SetTarget(varY, my_line);
            Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
            Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
            varX = null;
            varY = null;
            o_Story.Begin();
            o_Story.Children.Clear();
        }

        public void  winner_show(int winner_found , int row , int col) 
        {
            if (winner_found == 1) 
            {
                draw_line(row, col, "horizontal_winner");
            }
            else if (winner_found == 2) 
            {
                draw_line(row, col, "vertical_winner");
            }
            else if (winner_found == 3) 
            {
                draw_line(row, col, "diagonal_down_winner");
            }
            else
            {
                draw_line(row, col, "diagonal_up_winner");
            }
        }
       
        
       


       public void label_update()
        {
            label_OX_turn.Content = model.GetCurrentTurn().ToUpper() ;         
            label_num_count.Content = model.TurnCount.ToString();
        }

        public String Save_window_call()

        {
            MessageBoxResult confirm_result = MessageBox.Show("Do you want to save file?", "Alert!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm_result == MessageBoxResult.Yes)
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

                    return my_save_window.FileName ; 
                }
            }
            return null;
        }

        public String Load_window_call()
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

                    return my_open_window.FileName;

                }
            }
            return null;
        }

        public void O_draw(int row, int col)
        {
            int n = model.BoardSize;
            o_size = 210 / (2 * n);
            o_position_x = (45 / n) + (col * grid_size);
            o_position_y = (45 / n) + (row * grid_size);

            for (int i = 0; i < 361; i++)
            {
                Double x_point = Math.Round(((o_size) * Math.Cos(i * one_radian) + (o_size)) + o_position_x, 5);
                Double y_point = Math.Round(((o_size) * Math.Sin(i * one_radian) + (o_size)) + o_position_y, 5);
                o_cooardinate_list[i] = new Point(x_point, y_point);
                //o_cooardinate_list[720] = o_cooardinate_list[1];
            }
            for (int i = 0; i < 360; i++)
            {

                my_line = new Line();
                my_line.StrokeThickness = 4;
                my_line.Stroke = Brushes.Red;

                double start_point_X = o_cooardinate_list[i].X;
                double start_point_Y = o_cooardinate_list[i].Y;
                double end_point_X = o_cooardinate_list[i + 1].X;
                double end_point_Y = o_cooardinate_list[i + 1].Y;

                my_line.X1 = start_point_X;
                my_line.Y1 = start_point_Y;
                my_line.X2 = start_point_X;
                my_line.Y2 = start_point_Y;

                Canvas_field.Children.Add(my_line);
                DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(2)));
                varX.BeginTime = TimeSpan.FromMilliseconds(2*i);
                DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(2)));
                varY.BeginTime = TimeSpan.FromMilliseconds(2*i);

                o_Story.Children.Add(varX);
                o_Story.Children.Add(varY);
                Storyboard.SetTarget(varX, my_line);
                Storyboard.SetTarget(varY, my_line);
                Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
                varX = null;
                varY = null;

            }
            o_Story.Begin();
            o_Story.Children.Clear();
        }

        public void X_draw(int row, int col)
        {
            int n = model.BoardSize;
            x_array[0] = new Point((60 / n) + col * grid_size, (60 / n) + row * grid_size);
            x_array[1] = new Point((240 / n) + col * grid_size, (240 / n) + row * grid_size);
            x_array[2] = new Point((60 / n) + col * grid_size, (240 / n) + row * grid_size);
            x_array[3] = new Point((240 / n) + col * grid_size, (60 / n) + row * grid_size);

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

            Canvas_field.Children.Add(my_line);
            Canvas_field.Children.Add(my_line1);

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
