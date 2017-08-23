using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace StudentsAppTask
{
    /// <summary>
    /// Логика взаимодействия для AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {       
        public AcceptWindow(List<StudentViewModel> deletingStudents)
        {
            InitializeComponent();
            if (deletingStudents.Count > 1)
            {
                TextConfirm.Text = "Вы действительно хотите удалить " + deletingStudents.First().FirstName + " " + deletingStudents.First().Last + " и еще "
                + (deletingStudents.Count - 1).ToString() + " студентов?";
            }
            else
            {
                TextConfirm.Text = "Вы действительно хотите удалить " + deletingStudents.First().FirstName + " " + deletingStudents.First().Last + " ?";
            }
                 
                
            
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            IsDelete = true;
            this.DialogResult = false;
        }
        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            IsDelete = false;
            this.DialogResult = false;
        }
    }
}
