using System.Windows;

namespace StudentsAppTask
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private AddStudentViewModel studentViewModel;
        private bool isAddStudent = false;
        public AddStudentViewModel StudentViewModel
        {
            get { return studentViewModel; }
        }
        public bool IsAddStudent
        {
            get { return isAddStudent; }
        }

        public AddWindow()
        {
            InitializeComponent();
            studentViewModel = new AddStudentViewModel(new Student());            
            this.DataContext = studentViewModel;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Добавление студента";
        }
        public AddWindow(Student student)
        {
            InitializeComponent();
            studentViewModel = new AddStudentViewModel(student);
            this.DataContext = studentViewModel;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Редактирование студента";
        }

        private void SaveStudent_Click(object sender, RoutedEventArgs e)
        {            
            if (studentViewModel.InvalidProperty.Count == 0)
            {
                studentViewModel.Student.FirstName = FirstNameAddTb.Text;
                studentViewModel.Student.Last = LastAddTb.Text;
                studentViewModel.Student.Age = int.Parse(AgeAddTb.Text);
                studentViewModel.Student.Gender = int.Parse(GenderAddTb.Text);

                isAddStudent = true;
                this.DialogResult = false;
            }
            else
            {
                studentViewModel.CheckValidityAllProperties();
            }            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            studentViewModel.IsValidationEnabled = true;
        }
    }
}
