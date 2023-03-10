using WPF_first_touch.MVC.Controller;
using WPF_first_touch.MVC;
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
        private View view;
        private Model model ;
        private Button_Controller button_Controller;

        public MainView()
        {
            InitializeComponent();
            this.model = new Model();
            this.view = new View(model , my_Canvas, Count_Move_UI, Turn_UI);
            this.button_Controller = new Button_Controller(model, view);
        }

        private void Play_Pressed(object sender, EventArgs e)
        {
            try
            {
                button_Controller.Play_Setup(Int32.Parse(Size_Text.Text));
            }

            catch (System.Exception)
            {
                MessageBox.Show("Integer_Only", "Alert!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Save_Pressed(object sender, EventArgs e)
        {
            button_Controller.Do_save();
        }

        private void Load_button_Click(object sender, RoutedEventArgs e)
        {
            button_Controller.Do_load();
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
