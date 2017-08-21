using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentsAppTask
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window, IDataErrorInfo
    {
        private Student student;
        private bool isAddStudent = false;
        public Student Student
        {
            get { return student; }
        }
        public bool IsAddStudent
        {
            get { return isAddStudent; }
        }

        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {            
            student = new Student
            {
                FirstName = FirstNameAddTb.Text,
                Last = LastAddTb.Text,
                Age = int.Parse(AgeAddTb.Text),
                Gender = int.Parse(GenderAddTb.Text)
            };
            isAddStudent = true;
            this.DialogResult = false;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((int.Parse(AgeAddTb.Text) < 15) || (int.Parse(AgeAddTb.Text) > 100))
                        {
                            error = "Возраст должен быть больше 15 и меньше 100";
                        }
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstNameAddTb.Text))
                        {
                            error = "Необходимо указать имя";
                        }
                        break;
                    case "Last":
                        if (string.IsNullOrEmpty(LastAddTb.Text))
                        {
                            error = "Необходимо указать фамилию";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
       
    }
}
