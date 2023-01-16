using System;
using System.Collections.Generic;
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

namespace WPF_Rubik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Model model;
        private View View;
        private Model Model;
        private Controller Controller;

        public MainWindow()
        {
            InitializeComponent();
            this.Model = new Model();
            this.View = new View(Model, my_Canvas);
            this.Controller = new Controller(Model, View);
        }

        private void Play_Pressed(object sender, EventArgs e)
        {
            
            Controller.Play_Setup();
        }
    }
}
