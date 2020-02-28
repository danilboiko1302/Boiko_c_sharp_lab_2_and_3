using System.Windows;
using BirthdayPicker.ViewModels;

namespace BirthdayPicker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayPickerViewModel();
        }
    }
}
