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

            button_Controller.Play_Setup(Int32.Parse(Size_Text.Text));
            int n = button_Controller.data.n;
            my_Canvas.Children.Add(button_Controller.view.grid_field);
            
        }

        public void Change_Colour()
        {

        }

        public void Save_Pressed(object sender, EventArgs e)
        {


        }

       
    }
}
