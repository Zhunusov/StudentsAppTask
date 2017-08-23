using System.Windows;

namespace StudentsAppTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {          
        public MainWindow()
        {
            InitializeComponent();            
            DataContext = new ApplicationViewModel();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                              
        }
    }
}
