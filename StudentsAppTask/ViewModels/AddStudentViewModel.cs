using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentsAppTask
{
    public class AddStudentViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Student student;
        private static readonly string[] RequiredProperties = { "FirstName", "Last","Age", "Gender" };
        private readonly HashSet<string> invalidProperty = new HashSet<string>();      
        public AddStudentViewModel(Student s)
        {
            student = s;            
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
        public int Age
        {
            get { return student.Age; }
            set
            {
                student.Age = value;
                OnPropertyChanged("Age");
            }
        }
        public int Gender
        {
            get { return student.Gender; }
            set
            {
                student.Gender = value;
                OnPropertyChanged("Gender");
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

        public string this[string propertyName]
        {
            get
            {                
                string error = String.Empty;
                switch (propertyName)
                {
                    case "Age":
                        if (invalidProperty.Contains("Age"))
                            invalidProperty.Remove("Age");
                        if ((Age < 15) || (Age > 100))
                        { 
                            error = "Возраст должен быть больше 15 и не больше 100";
                            if(!invalidProperty.Contains("Age"))
                                invalidProperty.Add("Age");
                        }
                        break;
                    case "FirstName":
                        if (invalidProperty.Contains("FirstName"))
                            invalidProperty.Remove("FirstName");
                        if (string.IsNullOrEmpty(FirstName))
                        {
                            error = "Необходимо указать имя";
                            if (!invalidProperty.Contains("FirstName"))
                                invalidProperty.Add("FirstName");
                        }
                        break;
                    case "Last":
                        if (invalidProperty.Contains("Last"))
                            invalidProperty.Remove("Last");
                        if (string.IsNullOrEmpty(Last))
                        {
                            error = "Необходимо указать фамилию";
                            if (!invalidProperty.Contains("Last"))
                                invalidProperty.Add("Last");
                        }
                        break;
                    case "Gender":
                        if (invalidProperty.Contains("Gender"))
                            invalidProperty.Remove("Gender");
                        if (Gender != 0 && Gender != 1)
                        {
                            error = "Для мужчины необходимо указать '0', для женщины - '1'";
                            if (!invalidProperty.Contains("Gender"))
                                invalidProperty.Add("Gender");
                        }
                        break;
                }                
                return this.IsValidationEnabled ? error : string.Empty;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public HashSet<string> InvalidProperty
        {
            get { return invalidProperty; }            
        }

        public bool IsValidationEnabled { get; set; }

        public void CheckValidityAllProperties()
        {
            foreach (var property in RequiredProperties)
            {
                OnPropertyChanged(property);
            }
        }

    }
}
