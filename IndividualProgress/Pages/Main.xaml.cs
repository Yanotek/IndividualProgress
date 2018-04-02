using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using IndividualProgress.DateBase;
using Microsoft.EntityFrameworkCore;
using IndividualProgress.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace IndividualProgress.Pages
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainViewModel model { get; set; } = new MainViewModel();
        public Main()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void ClickAddStud(object sender, RoutedEventArgs e)
        {
            Student student = new Student()
            {
                FullName = "Введите имя",
                DateOfBirth = DateTime.Now
            };
            model.SelectedStudent = student;
            model.SelectedParts.Clear();
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            if (model.Students.Contains(model.SelectedStudent))
            {
                MessageBoxResult mess = MessageBox.Show("Удалить студента?", "Подтверждение", MessageBoxButton.YesNo);
                if (mess == MessageBoxResult.Yes)
                {
                    App.DbHelper.Part.RemoveRange(App.DbHelper.Part.Where(x => x.Student == model.SelectedStudent));
                    foreach(var b in model.Parts.Where(x=> x.Student == model.SelectedStudent))
                    {
                        model.SelectedParts.Remove(b);
                    }
                    App.DbHelper.Student.Remove(model.SelectedStudent);
                    App.DbHelper.SaveChanges();
                    model.Students.Remove(model.SelectedStudent);
                    model.SelectedParts.Clear();
                    model.SelectedStudent = new Student()
                    {
                        FullName = "Введите имя",
                        DateOfBirth = DateTime.Now
                    };
                    model.Refresh();
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                model.SelectedParts.Clear();
                foreach (var b in model.Parts.Where(x => x.Student == model.SelectedStudent))
                    model.SelectedParts.Add(b);
                model.SelectedPart = null;
            }
            catch { }
        }

        private void MoreEventInfo(object sender, RoutedEventArgs e)
        {
            if (model.SelectedPart != null)
            {
                Event vent = model.SelectedPart.Event;
                Events main = new Events();
                main.model.SelectedEvent = vent;
                NavigationService.Navigate(main);
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (model.SelectedStudent.FullName != "Введите имя")
                {
                    if (model.SelectedStudent.Group == null)
                    {
                        Group group = new Group
                        {
                            Name = model.Groupname
                        };
                        App.DbHelper.Group.Add(group);
                        model.SelectedStudent.Group = group;
                        model.Groups.Add(group);

                    }
                    App.DbHelper.Student.Update(model.SelectedStudent);
                    App.DbHelper.SaveChanges();
                    if (!model.Students.Contains(model.SelectedStudent))
                    {
                        model.Students.Add(model.SelectedStudent);
                    }
                    MessageBox.Show("Изменения сохранены");
                    model.Refresh();
                }
            }
            catch { }
        }

        private void AddEventClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (model.Students.Contains(model.SelectedStudent))
                {
                    AddPartEvent addPart = new AddPartEvent(model.SelectedStudent);
                    addPart.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    addPart.ShowDialog();
                    if (addPart.DialogResult == true)
                    {
                        model.Parts.Add(addPart.model.Part);
                        model.SelectedParts.Add(addPart.model.Part);
                    }
                }
            }
            catch { }
        }

        private void RemoveEventClick(object sender, RoutedEventArgs e)
        {
            if (model.Students.Contains(model.SelectedStudent) &&model.SelectedParts.Contains(model.SelectedPart))
            {
                MessageBoxResult mess = MessageBox.Show("Удалить информацию об участии?", "Подтверждение", MessageBoxButton.YesNo);
                if (mess == MessageBoxResult.Yes)
                {
                    App.DbHelper.Part.Remove(model.SelectedPart);
                    App.DbHelper.SaveChanges();
                    model.SelectedParts.Remove(model.SelectedPart);
                    model.Parts.Remove(model.SelectedPart);
                }
            }
        }

        private void EventListClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Events());
        }

        private void StaticticClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Statistics());
        }
    }

    public class MainViewModel :INotifyPropertyChanged
    {
        public MainViewModel()
        {
            SelectedStudents = new ObservableCollection<Student>(Students.Where(x => Sort == null || (x.FullName.ToLower().Contains(Sort.ToLower()))).ToList());

            SelectedStudent = new Student()
            {
                FullName = "Введите имя",
                DateOfBirth = DateTime.Now
            };

            Parts = new ObservableCollection<Part>(App.DbHelper.Part.Include(x => x.Student).Include(x => x.Event).Include(x => x.Teacher).ToList());
            SelectedParts = new ObservableCollection<Part>(Parts.Where(x => x.Student == SelectedStudent));
            Groups = new ObservableCollection<Group>(App.DbHelper.Group.ToList());
        }

        public void Refresh()
        {
            SelectedStudents = new ObservableCollection<Student>(Students.Where(x => Sort == null || (x.FullName.ToLower().Contains(Sort.ToLower()))).ToList());
        }

        private string _sort;
        private Student selectedStudent;
        private ObservableCollection<Student> selectedStudents;

        public string Sort
        {
            get => _sort;
            set
            {
                _sort = value;
                Refresh();
            }
        }

        public ObservableCollection<Student> SelectedStudents
        {
            get => selectedStudents;
            set
            {
                selectedStudents = value;
                OnPropertyChanged("SelectedStudents");
            }
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private ObservableCollection<Student> students = new ObservableCollection<Student>(App.DbHelper.Student.Include(nameof(Group)).ToList());

        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                students = value;
                Refresh();
            }
        }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Part> Parts { get; set; }
        public ObservableCollection<Part> SelectedParts { get; set; }
        public Part SelectedPart { get; set; }
        public string Groupname { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
