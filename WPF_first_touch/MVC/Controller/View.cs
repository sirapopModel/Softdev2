using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace WPF_first_touch.MVC.Controller
{
    public class View
    {
        //public Point[] x_array = { new Point(20, 20), new Point(80, 80), new Point(80, 20), new Point(20, 80) };
        public Point[] x_array = new Point[4] ;
        public Canvas[,] sheet_2d_array;
        public Grid grid_field;
        public int grid_size;

        public Storyboard x_Story = new Storyboard();
        public Storyboard x_Story1 = new Storyboard();

        public int o_size = 0 ;
        public int o_position = 0 ;
        public Point[] o_cooardinate_list = new Point[721] ;
        public double one_radian = 3.14 / 360 ;
        public Storyboard o_Story = new Storyboard();
        
        public void O_model(int row, int col)
        {
            for (int i = 0; i< 720; i++)
            {
                Line my_line = new Line();
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

                sheet_2d_array[row, col].Children.Add(my_line);
                DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(1)));
                varX.BeginTime = TimeSpan.FromMilliseconds(3*i);
                DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(1)));
                varY.BeginTime = TimeSpan.FromMilliseconds(3*i);

                o_Story.Children.Add(varX);
                o_Story.Children.Add(varY);
                Storyboard.SetTarget(varX, my_line);
                Storyboard.SetTarget(varY, my_line);
                Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
                
            }
            o_Story.Begin();









        }

        public void O_size_config(int n)
        {
            o_size = 210/(2*n) ;
            o_position = 45 / n;
            
            for (int i = 0; i < 720; i++)
            {
                Double x_point = Math.Round( ((o_size)*Math.Cos(i*one_radian)+ (o_size)) + o_position ,5);
                Double y_point = Math.Round(((o_size) * Math.Sin(i*one_radian)+ (o_size)) + o_position ,5);
                o_cooardinate_list[i] = new Point( x_point, y_point);
                o_cooardinate_list[720] = o_cooardinate_list[719];
            }
            


            //o_cooardinate_list[360] = o_cooardinate_list[359];
        }
        public void X_size_config(int n)
        {
            x_array[0] = new Point(60/n,60/n);
            x_array[1] = new Point(240 / n, 240 / n);
            x_array[2] = new Point(60 / n, 240 / n);
            x_array[3] = new Point(240 / n, 60 / n);
        }
        public void X_model(int row, int col)
        {
            // line property
            var my_line = new Line();
            my_line.StrokeThickness = 4;
            my_line.Stroke = Brushes.Blue;
            var my_line1 = new Line();
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

            //Grid.SetRow(my_line, row);
            //Grid.SetColumn(my_line, col);
            sheet_2d_array[row, col].Children.Add(my_line);
            sheet_2d_array[row, col].Children.Add(my_line1);
            //create animation
            DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(500)));
            DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(500)));
            varX.BeginTime = TimeSpan.FromMilliseconds(0);
            varY.BeginTime = TimeSpan.FromMilliseconds(0);

            DoubleAnimation varX1 = new DoubleAnimation(end_point1_X, new Duration(TimeSpan.FromMilliseconds(500)));
            DoubleAnimation varY1 = new DoubleAnimation(end_point1_Y, new Duration(TimeSpan.FromMilliseconds(500)));
            varX1.BeginTime = TimeSpan.FromMilliseconds(510);
            varY1.BeginTime = TimeSpan.FromMilliseconds(510);

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

        }
    }
}
