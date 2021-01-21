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
using System.Threading;

namespace Kriteria
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ThreadMethods tm;
        public MainWindow()
        {
            InitializeComponent();
            tm = new ThreadMethods();
            FillComboBoxs();
                               
        }
        private void FillComboBoxs()
        {
            foreach (var item in tm.CondArr) { firstCondition.Items.Add(item.Method.Name); }
            foreach (var item in tm.CondArr) { secondCondition.Items.Add(item.Method.Name); }
            foreach (var item in tm.CondArr) { thirdCondition.Items.Add(item.Method.Name); }
        }

        private async void firstButton_Click(object sender, RoutedEventArgs e)
        {
            int chosenCondition = firstCondition.SelectedIndex;
            string result;
            firstButton.IsEnabled = false;
            firstResult.Text = "Calculating...";
            result = await tm.SearchAsync(chosenCondition);
            firstResult.Text = result;
            firstButton.IsEnabled = true;
        }

        private async void secondButton_Click(object sender, RoutedEventArgs e)
        {
            int chosenCondition = secondCondition.SelectedIndex;
            string result;
            secondButton.IsEnabled = false;
            secondResult.Text = "Calculating...";
            result = await tm.SearchAsync(chosenCondition);
            secondResult.Text = result;
            secondButton.IsEnabled = true;

        }

        private async void thirdButton_Click(object sender, RoutedEventArgs e)
        {
            int chosenCondition = thirdCondition.SelectedIndex;
            string result;
            thirdButton.IsEnabled = false;
            thirdResult.Text = "Calculating...";
            result = await tm.SearchAsync(chosenCondition);
            thirdResult.Text = result;
            thirdButton.IsEnabled = true;
        }
    }

    
}

