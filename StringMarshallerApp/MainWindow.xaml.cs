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

namespace StringMarshallerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGetVersionCharPtr_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionCharPtr();
            }
        }

        private void buttonGetVersionCharPtr_2_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionCharPtr_2();
            }
        }

        private void buttonGetVersionBSTR_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionBSTR();
            }
        }

        private void buttonSetVersionCharPtr_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SetVersionCharPtr();
            }
        }

        private void buttonSetVersionBSTR_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SetVersionBSTR();
            }
        }

        private void buttonGetVersionCharPtrPtr_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionCharPtrPtr();
            }
        }

        private void buttonGetVersionBSTRPtr_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionBSTRPtr();
            }
        }

        private void buttonGetVersionBuffer_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.GetVersionBuffer();
            }
        }

        private void buttonSetVersion_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SetVersion();
            }
        }

        private void buttonSetStringArray_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SetStringArray();
            }
        }
    }
}
