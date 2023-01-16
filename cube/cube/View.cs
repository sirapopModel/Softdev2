using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1_Dice;

namespace cube
{
    internal class View
    {
        private Model model;
        private Canvas my_canvas;

        private List<System.Drawing.Point> point_list = new List<System.Drawing.Point>();
        private System.Drawing.Point[] point_array = new System.Drawing.Point[10];

        Label x = new Label();
        Label y = new Label();
        Label z = new Label();
        public View(Canvas my_canvas , Model model)
        {
            this.my_canvas = my_canvas;
            this.model = model;
            point_config();
            
        }
        private void point_config() 
        {
            int offset = 35;
            int initial_positon = 100;
            int length = 100;
            point_array[0] = new System.Drawing.Point(initial_positon, initial_positon);
            point_array[1] = new System.Drawing.Point(initial_positon+length, initial_positon);
            point_array[2] = new System.Drawing.Point(initial_positon+length + offset, initial_positon + offset);
            point_array[3] = new System.Drawing.Point(initial_positon + offset, initial_positon + offset);
            point_array[4] = new System.Drawing.Point(initial_positon, initial_positon);

            point_array[5] = new System.Drawing.Point(initial_positon + offset, initial_positon + offset);
            point_array[6] = new System.Drawing.Point(initial_positon+ length + offset, initial_positon + offset);
            point_array[7] = new System.Drawing.Point(initial_positon+ length + offset, initial_positon+ length + offset);
            point_array[8] = new System.Drawing.Point(initial_positon + offset ,initial_positon+ length + offset);
            point_array[9] = new System.Drawing.Point(initial_positon + offset, initial_positon + offset);

           
        }
        public void cube_draw()
        {
            Line my_line;
            for (int i = 0; i<point_array.Length-1; i++)
            {
                my_line = make_line(point_array[i].X, point_array[i].Y, point_array[i + 1].X, point_array[i + 1].Y);
                my_canvas.Children.Add(my_line);
            }

            my_line = make_line(point_array[8].X, point_array[8].Y, 100, 200);
            my_canvas.Children.Add(my_line);
            my_line = make_line(100,200, 100, 100);
            my_canvas.Children.Add(my_line);

            x.Name = "x_label";
            x.Content = model.GetFaces()[0].ToString();
            Canvas.SetLeft(x, 180);
            Canvas.SetTop(x, 170);

            y.Name = "y_label";
            y.Content = model.GetFaces()[1].ToString();
            Canvas.SetLeft(y, 110);
            Canvas.SetTop(y, 150);
           
            z.Name = "z_label";
            z.Content = model.GetFaces()[2].ToString();
            Canvas.SetLeft(z, 160);
            Canvas.SetTop(z, 100);

            my_canvas.Children.Add(x);
            my_canvas.Children.Add(y);
            my_canvas.Children.Add(z);

        }




        public Line make_line( Double X1 , Double Y1 , Double X2 , Double Y2 )
        {
            Line line = new Line();
            line.X1 = X1;
            line.Y1 = Y1;
            line.X2 = X2;
            line.Y2 = Y2;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 4;
            return line;
        }
        private void update_label() 
        {
            x.Content = model.GetFaces()[0].ToString();
            y.Content = model.GetFaces()[1].ToString();
            z.Content = model.GetFaces()[2].ToString();
        }
        public void Front_to_Side_update() 
        {
            model.X_To_Y();
            update_label();
        }

        public void Top_to_Front_update()
        {
            model.Z_To_X();
            update_label();
        }
    }
}
