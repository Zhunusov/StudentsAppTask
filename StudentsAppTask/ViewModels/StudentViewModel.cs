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
            get { return student.Age +" "+ AgeAdditionDetecting(student.Age); }
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
            get { return student.FirstName + " " + student.Last; }
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
        public string AgeAdditionDetecting (int age)
        {            
            string result = "";

            var array = age.ToString().ToCharArray();
            switch (int.Parse(array[array.Length -1].ToString()))
            {
                case 0: result = "лет"; break;
                case 1: result = "год"; break;
                case 2: result = "года"; break;
                case 3: result = "года"; break;
                case 4: result = "года"; break;
                case 5: result = "лет"; break;
                case 6: result = "лет"; break;
                case 7: result = "лет"; break;
                case 8: result = "лет"; break;
                case 9: result = "лет"; break;
            }
            return result;
        }
    }
}
