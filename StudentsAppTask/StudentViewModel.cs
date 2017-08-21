using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentsAppTask
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student student;
        private string fullName, gender, age;
        public StudentViewModel (Student s)
        {
            student = s;
            fullName = FullName;
        }

        public int Id
        {
            get { return student.Id; }
            set
            {
                student.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return student.FirstName; }
            set
            {
                student.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string Last
        {
            get { return student.Last; }
            set
            {
                student.Last = value;
                OnPropertyChanged("Last");
            }
        }
        public string Age
        {
            get { return student.Age + " лет"; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Gender
        {
            get
            {
                switch(student.Gender)
                {
                    case 0: return "Мужчина";
                    case 1: return "Женщина";
                    default: return "Пол не установлен";
                }
                    
            }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string FullName
        {
            get { return this.FirstName + " " + this.Last; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public Student Student
        {
            get { return student; }
            set
            {
                student = value;
                OnPropertyChanged("StudentInformation");
            }
        }       
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
