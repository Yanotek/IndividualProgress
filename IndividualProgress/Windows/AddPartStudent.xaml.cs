using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using IndividualProgress.DateBase;

namespace IndividualProgress.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPartStudent.xaml
    /// </summary>
    public partial class AddPartStudent : Window
    {
        public Event Event { get; set; }
        public AddPartStudentViewModel model { get; set; }
        public AddPartStudent(Event _event)
        {
            InitializeComponent();
            model = new AddPartStudentViewModel();
            model.Students = new ObservableCollection<Student>(App.DbHelper.Student.ToList());
            model.Teachers = new ObservableCollection<Teacher>(App.DbHelper.Teacher.ToList());
            Event = _event;
            DataContext = model;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int i =int.Parse(model.Part.Place.ToString());
                model.Part.Student = model.SelectedStudent;
                model.Part.Event = Event;
                if (model.SelectedTeacher != null)
                {
                    model.Part.Teacher = model.SelectedTeacher;
                }
                else
                {
                    model.Part.Teacher = new Teacher() { Name = model.TeacherName };
                }
                App.DbHelper.Part.Add(model.Part);
                App.DbHelper.SaveChanges();
                DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введённых данных", "Ошибка");
            }
        }

    }

    public class AddPartStudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }
        public Part Part { get; set; } = new Part();
        public ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }
        public string TeacherName { get; set; }
    }

}
