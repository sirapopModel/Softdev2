using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Model
{
    public class game_data
    {
        public int n;
        public int grid_size;
        public Grid grid_field;
        public Button[][] checked_array;
        public Canvas[,] sheet_2d_array;
        public Point[] x_array = { new Point(20, 20), new Point(80, 80) };
        public Storyboard x_Story = new Storyboard();

        public void X_draw(int row, int col)
        {

            // line property
            var my_line = new Line();
            my_line.StrokeThickness = 4;
            my_line.Stroke = Brushes.Blue;

            // set variable
            double start_point_X = (x_array[0].X);
            double start_point_Y = (x_array[0].Y);
            double end_point_X = (x_array[1].X); ;
            double end_point_Y = (x_array[1].Y); ;

            //set initial state of line and that to UI
            my_line.X1 = start_point_X;
            my_line.Y1 = start_point_Y;
            my_line.X2 = start_point_X;
            my_line.Y2 = start_point_Y;
            //Grid.SetRow(my_line, row);
            //Grid.SetColumn(my_line, col);
            (sheet_2d_array[row, col]).Children.Add(my_line);

            //create animation
            DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(1000)));
            DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(1000)));
            varX.BeginTime = TimeSpan.FromMilliseconds(0);
            varY.BeginTime = TimeSpan.FromMilliseconds(0);

            //connect an animation to story board

            x_Story.Children.Add(varX);
            x_Story.Children.Add(varY);

            // add property of animation in this case line property 
            Storyboard.SetTarget(varX, my_line);
            Storyboard.SetTarget(varY, my_line);
            Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
            Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
        }


    }
    
}
