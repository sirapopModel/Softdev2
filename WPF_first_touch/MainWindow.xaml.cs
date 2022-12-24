using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_first_touch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button_Controller button_Controller = new Button_Controller();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Play_Pressed(object sender, EventArgs e)
        {
            button_Controller.Play_Setup( Int32.Parse(Size_Text.Text) );
            int n = button_Controller.data.n;
            Size_Text.Text = n.ToString();

            for (int Row = 0; Row < n; Row++)
            {
                for (int Column = 0; Column < n; Column++)
                {
                    Button temp = button_Controller.data.checked_array[Row][Column];
                    Canvas.SetLeft(temp, (Column* button_Controller.data.button_size) +20);
                    Canvas.SetTop(temp, (Row * button_Controller.data.button_size) + 20);
                    my_Canvas.Children.Add(temp);
                    
                }
                
            }       
        }

        public void Change_Colour()
        {
            
        }

        public void Save_Pressed(object sender, EventArgs e)
        {
            Size_Text.Text = "HELLO";
            Button temp = new Button();
            temp.Height = 40;
            temp.Width = 40;
            Canvas.SetLeft(temp, 100);
            Canvas.SetBottom(temp, 100);
            my_Canvas.Children.Add(temp);
            temp.Content = "HELLO";

        }


    }
}
