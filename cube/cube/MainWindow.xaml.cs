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
using WpfApp1_Dice;

namespace cube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        View view;
        Model model;
        public MainWindow()
        {
            InitializeComponent();
            model = new Model();
            view = new View(my_canvas , model);
            Controller controller = new Controller(model, view);
        }

        private void start_button_click(object sender, RoutedEventArgs e)
        {
            Front_to_Side_button.Visibility = Visibility.Visible;
            Front_to_Side_button.IsEnabled = true;

            Top_to_Front_button.Visibility = Visibility.Visible;
            Top_to_Front_button.IsEnabled = true;

            Front_to_Side_3_times.Visibility = Visibility.Visible;
            Front_to_Side_3_times.IsEnabled = true;

            Bottom_to_Front_3_times.Visibility = Visibility.Visible;
            Bottom_to_Front_3_times.IsEnabled = true;

            Start_button.Visibility = Visibility.Hidden;
            Start_button.IsEnabled = false;


            view.cube_draw();

        }

        private void Front_to_Side_button_Click(object sender, RoutedEventArgs e)
        {
           
                view.Front_to_Side_update();
            
        }

        private void Top_to_Front_button_Click(object sender, RoutedEventArgs e)
        {
            view.Top_to_Front_update();
        }

        private void Front_to_Side_3_times_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                view.Front_to_Side_update();
            }
        }

        private void Bottom_to_Front_3_times_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                view.Top_to_Front_update();
            }
        }
    }
}
