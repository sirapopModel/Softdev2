using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace WPF_Rubik
{
    public class View
    {
        public Canvas Canvas_field;
        private Model model;

        private Point[] cube_array = new Point[4];

        private Storyboard Cube_Story = new Storyboard();

        private Canvas my_Canvas;

        public View(Model model, Canvas my_Canvas)
        {
            this.model = model;
            this.my_Canvas = my_Canvas;

        }

        public void Create_board()
        {
            my_Canvas.Children.Remove(Canvas_field);

            
            Canvas_field = new Canvas();
            Canvas_field.Height = 300;
            Canvas_field.Width = 300;

            my_Canvas.Children.Add(Canvas_field);

            Cube_draw();



        }

        public void Cube_draw()
        {
            Line my_line;

            cube_array[0] = new Point((0), (0));
            cube_array[1] = new Point((240), (0));

            cube_array[2] = new Point((240), (0));
            cube_array[3] = new Point((240), (240));

            cube_array[4] = new Point((240), (240));
            cube_array[5] = new Point((0), (240));

            cube_array[6] = new Point((0), (240));
            cube_array[7] = new Point((0), (0));

            for (int i = 0; i < 7; i++)
            {
                my_line = new Line();
                my_line.StrokeThickness = 4;
                my_line.Stroke = Brushes.Red;

                double start_point_X = cube_array[i].X;
                double start_point_Y = cube_array[i].Y;
                double end_point_X = cube_array[i + 1].X;
                double end_point_Y = cube_array[i + 1].Y;

                my_line.X1 = start_point_X;
                my_line.Y1 = start_point_Y;
                my_line.X2 = start_point_X;
                my_line.Y2 = start_point_Y;

                Canvas_field.Children.Add(my_line);
                DoubleAnimation varX = new DoubleAnimation(end_point_X, new Duration(TimeSpan.FromMilliseconds(2)));
                varX.BeginTime = TimeSpan.FromMilliseconds(2 * i);
                DoubleAnimation varY = new DoubleAnimation(end_point_Y, new Duration(TimeSpan.FromMilliseconds(2)));
                varY.BeginTime = TimeSpan.FromMilliseconds(2 * i);

                Cube_Story.Children.Add(varX);
                Cube_Story.Children.Add(varY);
                Storyboard.SetTarget(varX, my_line);
                Storyboard.SetTarget(varY, my_line);
                Storyboard.SetTargetProperty(varX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(varY, new PropertyPath(Line.Y2Property));
            }
            Cube_Story.Begin();
            Cube_Story.Children.Clear();
        }
        
    }
}
