using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace StudentsAppTask
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {        
        private StudentViewModel selectedStudent;
        private AddWindow addWindow, editWindow;
        private AcceptWindow acceptWindow;

        public ObservableCollection<StudentViewModel> Students { get; set; }       

        public StudentViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        public ApplicationViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();           
            LoadXmlFile();            
        }

        public void LoadXmlFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(.xml)|*.xml";
            dlg.Title = "Выберите файл с данными студентов";
            if ((bool)dlg.ShowDialog())
                Students = LoadFromXML(dlg.FileName);
        }

        public ObservableCollection<StudentViewModel> LoadFromXML (string pathToXmlFile)
        {
            Students.Clear();
            XDocument xdoc = XDocument.Load(pathToXmlFile);
            List<StudentViewModel> list = xdoc.Root.Elements("Student")
                .Select(
                   p =>
                   {
                       return new StudentViewModel(
                           new Student
                           {
                               Id = int.Parse(p.Attribute("Id").Value),
                               FirstName = p.Element("FirstName").Value,
                               Last = p.Element("Last").Value,
                               Age = int.Parse(p.Element("Age").Value),
                               Gender = int.Parse(p.Element("Gender").Value)
                           });
                   }
                ).ToList();

            return new ObservableCollection<StudentViewModel>(list);
        }

        private RelayCommand addDialogCommand;
        public RelayCommand AddDialogCommand
        {
            get
            {
                return addDialogCommand ??
                  (addDialogCommand = new RelayCommand(obj =>
                  {
                      addWindow = new AddWindow();
                      while (addWindow.ShowDialog() == true);
                      
                      if (addWindow.IsAddStudent)
                      {
                          Student newStudent = new Student
                          {
                              Id = Students.Count,
                              FirstName = addWindow.StudentViewModel.FirstName,
                              Last = addWindow.StudentViewModel.Last,
                              Age = addWindow.StudentViewModel.Age,
                              Gender = addWindow.StudentViewModel.Gender
                          };
                          Students.Add(new StudentViewModel(newStudent));
                      }
                  }));
            }
        }
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {                      
                      editWindow = new AddWindow(selectedStudent.Student);
                      while (editWindow.ShowDialog() == true) ;
                                            
                      if (editWindow.IsAddStudent)
                      {
                          selectedStudent.Student.FirstName = editWindow.StudentViewModel.FirstName;
                          selectedStudent.Student.Last = editWindow.StudentViewModel.Last;
                          selectedStudent.Student.Age = editWindow.StudentViewModel.Age;
                          selectedStudent.Student.Gender = editWindow.StudentViewModel.Gender;
                      }
                  },
                  (obj) => Students.Count > 0));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      var students = obj as Collection<object>;
                      List<StudentViewModel> deletingStudents = students.Cast<StudentViewModel>().ToList();
                      acceptWindow = new AcceptWindow(deletingStudents);
                      while (acceptWindow.ShowDialog() == true) ;
                      if (acceptWindow.IsDelete)
                      {                          
                          if (deletingStudents.Count>0)
                          {
                              deletingStudents.ForEach(student=> Students.Remove(student));
                          }
                      } 
                  },
                 (obj) => Students.Count > 0));
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

