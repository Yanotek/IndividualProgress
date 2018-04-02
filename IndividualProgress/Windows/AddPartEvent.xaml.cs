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
    /// Логика взаимодействия для AddPartEvent.xaml
    /// </summary>
    public partial class AddPartEvent : Window
    {
        public Student Student { get; set; }
        public AddPartEventViewModel model { get; set; }
        public AddPartEvent(Student _student)
        {
            InitializeComponent();
            model = new AddPartEventViewModel
            {
                Levels = new ObservableCollection<Level>(App.DbHelper.Level.ToList()),
                Spheres = new ObservableCollection<Sphere>(App.DbHelper.Sphere.ToList()),
                Events = new ObservableCollection<Event>(App.DbHelper.Event.ToList()),
                Teachers = new ObservableCollection<Teacher>(App.DbHelper.Teacher)
            };
            Student = _student;
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
                int i = int.Parse(model.Part.Place.ToString());

                model.Part.Event = model.SelectedEvent;
                model.Part.Student = Student;
                if (model.SelectedTeacher == null)
                {
                    Teacher teacher = new Teacher
                    {
                        Name = model.TeacherName
                    };
                    model.Part.Teacher = teacher;
                }
                else
                {
                    model.Part.Teacher = model.SelectedTeacher;
                }
                if (model.SelectEvent)
                {
                    model.Part.Event = model.SelectedEvent;
                }
                else
                {
                    model.Part.Event = model.NewEvent;
                    App.DbHelper.Event.Add(model.NewEvent);
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

        private void AddSphereClick(object sender, RoutedEventArgs e)
        {
            AddString addString = new AddString();
            addString.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addString.ShowDialog();
            if (addString.DialogResult == true)
            {
                try
                {
                    model.Spheres.First(x => x.Name == addString.Value);
                }
                catch
                {
                    Sphere sphere = new Sphere() { Name = addString.Value };
                    App.DbHelper.Sphere.Add(sphere);
                    App.DbHelper.SaveChanges();
                    model.Spheres.Add(sphere);
                }
            }
        }

        private void AddLevelClick(object sender, RoutedEventArgs e)
        {
            AddString addString = new AddString();
            addString.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addString.ShowDialog();
            if (addString.DialogResult == true)
            {
                try
                {
                    model.Levels.First(x => x.Name == addString.Value);
                }
                catch
                {
                    Level level = new Level() { Name = addString.Value };
                    App.DbHelper.Level.Add(level);
                    App.DbHelper.SaveChanges();
                    model.Levels.Add(level);
                }
            }
        }

    }

    public class AddPartEventViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public Event SelectedEvent { get; set; }
        public Event NewEvent { get; set; } = new Event() {Direction = new Direction(), Location = new Location() };
        public Part Part { get; set; } = new Part();
        public ObservableCollection<Level> Levels { get; set; }
        public ObservableCollection<Sphere> Spheres { get; set; }
        public bool SelectEvent { get; set; } = true;
        public ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }

        public string TeacherName { get; set; }
    }
}
