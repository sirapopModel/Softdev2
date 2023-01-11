using WPF_first_touch.MVC.Controller;
using WPF_first_touch.MVC.Model;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Media3D;

namespace WPF_first_touch.MVC.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public Button_Controller button_Controller = new Button_Controller();

        public MainView()
        {
            InitializeComponent();
            button_Controller.serve_component_to_view(Count_Move_UI, Turn_UI);
        }

        private void Play_Pressed(object sender, EventArgs e)
        {
            try
            {
                my_Canvas.Children.Remove(button_Controller.view.Canvas_field);
                button_Controller.Play_Setup(Int32.Parse(Size_Text.Text));
            }

            catch (System.Exception)
            {
                MessageBox.Show("Integer_Only", "Alert!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            button_Controller.Made_empty_Array(Int32.Parse(Size_Text.Text));
            my_Canvas.Children.Add(button_Controller.view.Canvas_field);
        }


        private void Save_Pressed(object sender, EventArgs e)
        {
            button_Controller.Do_save();
        }

        private void Load_button_Click(object sender, RoutedEventArgs e)
        {
            Stream Load_file = button_Controller.LoadFileSelected();

            if (Load_file != null)
            {
                my_Canvas.Children.Remove(button_Controller.view.Canvas_field);
                button_Controller.Do_load(Load_file);
                my_Canvas.Children.Add(button_Controller.view.Canvas_field);
            }

        }

        private void Cursor_Enter(object sender, MouseEventArgs e)
        {
            Button my_button = (Button)sender;
            my_button.Width = 120;
            my_button.Height = 35;
            Play_button.Cursor = Cursors.Hand;
        }

        private void Cursor_Leave(object sender, MouseEventArgs e)
        {
            Button my_button = (Button)sender;
            my_button.Width = 100;
            my_button.Height = 30;
        }
    }
}
