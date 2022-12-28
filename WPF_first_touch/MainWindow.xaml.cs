﻿using WPF_first_touch.MVC.Controller;
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
           
            try
            {
                //button_Controller.view.grid_field.Children.Clear();
                button_Controller.Play_Setup(Int32.Parse(Size_Text.Text));
                
                
            }
            
            catch(System.Exception)
            {
                MessageBox.Show("Integer_Only" ,"Alert!!",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            //int n = button_Controller.data.n;
            my_Canvas.Children.Remove(button_Controller.view.grid_field_old_one);
            //my_Canvas.Children.Clear(); clear
            button_Controller.view.grid_field_old_one = button_Controller.view.grid_field;
            


            my_Canvas.Children.Add(button_Controller.view.grid_field);

            button_Controller.view.label_num_count = Count_Move_UI ;
            button_Controller.view.num_turn_update(0);

            button_Controller.view.label_OX_turn = Turn_UI;
        }
        
        public void Change_Colour()
        {
            
        }

        public void Save_Pressed(object sender, EventArgs e)
        {
            button_Controller.view.Save_window_call();

        }

       
    }
}
