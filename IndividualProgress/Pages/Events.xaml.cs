using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndividualProgress.Windows;
using IndividualProgress.DateBase;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IndividualProgress.Pages
{
    /// <summary>
    /// Логика взаимодействия для Events.xaml
    /// </summary>
    public partial class Events : Page
    {
        public bool Crutch = true;
        public EventsViewModel model = new EventsViewModel();
        public Events()
        {
            InitializeComponent();
            try
            {
                model.Spheres = new ObservableCollection<Sphere>(App.DbHelper.Sphere.ToList());
                model.Levels = new ObservableCollection<Level>(App.DbHelper.Level.ToList());
                model.Events = new ObservableCollection<DateBase.Event>(App.DbHelper.Event.Include(nameof(DateBase.Location)).Include(nameof(DateBase.Direction)).Include(nameof(DateBase.Level)).ToList());
                model.Parts = new ObservableCollection<Part>(App.DbHelper.Part.Include(nameof(Student)).Include(nameof(Event)).ToList());
                model.SelectedParts = new ObservableCollection<Part>(model.Parts.Where(x => x.Event == model.SelectedEvent));
                model.SelectedEvents = model.Events;
                model.SelectedEvent = new Event()
                {
                    Name = "Новое мероприятие",
                    Date = DateTime.Now,
                    Direction = new Direction(),
                    Location = new Location()
                };
            }
            catch { }
            DataContext = model;
            
        }

        private void ClickAddEvent(object sender, RoutedEventArgs e)
        {
            model.SelectedEvent = new Event()
            {
                Name = "Новое мероприятие",
                Date = DateTime.Now,
                Direction = new Direction(),
                Location = new Location()
            };
            model.SelectedParts.Clear();
        }

        private void StaticticClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Statistics());
        }

        private void ClickRemoveEvent(object sender, RoutedEventArgs e)
        {
            if (model.Events.Contains(model.SelectedEvent))
            {
                MessageBoxResult mess = MessageBox.Show("Удалить информацию о мероприятии?", "Подтверждение", MessageBoxButton.YesNo);
                if (mess == MessageBoxResult.Yes)
                {
                    App.DbHelper.Part.RemoveRange(App.DbHelper.Part.Where(x => x.Event == model.SelectedEvent));
                    foreach (var b in model.Parts.Where(x => x.Event == model.SelectedEvent))
                    {
                        model.SelectedParts.Remove(b);
                    }
                    App.DbHelper.Event.Remove(model.SelectedEvent);
                    App.DbHelper.SaveChanges();
                    model.Events.Remove(model.SelectedEvent);
                    model.SelectedEvent = new Event()
                    {
                        Name = "Новое мероприятие",
                        Date = DateTime.Now,
                        Direction = new Direction(),
                        Location = new Location()
                    };
                    model.SelectedParts.Clear();
                    Crutch = false;
                }
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

        private void SaveEventClick(object sender, RoutedEventArgs e)
        {
            if (model.SelectedEvent.Name != "Новое мероприятие")
            {
                if (model.SelectedEvent.Name != null && model.SelectedEvent.Location.City != null && model.SelectedEvent.Direction.Description != null && model.SelectedEvent.Level.Name != null)
                {
                    if (!model.Events.Contains(model.SelectedEvent))
                    {
                        model.Events.Add(model.SelectedEvent);
                    }

                    App.DbHelper.Event.Update(model.SelectedEvent);

                    App.DbHelper.SaveChanges();
                    MessageBox.Show("Изменения сохранены");
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введённых данных");
                }
            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                model.SelectedParts.Clear();
                foreach (var b in model.Parts.Where(x => x.Event == model.SelectedEvent))
                    model.SelectedParts.Add(b);
                model.SelectedPart = null;
            }
            catch { }
        }

        private void AddStudentClick(object sender, RoutedEventArgs e)
        {
            if (model.Events.Contains(model.SelectedEvent))
            {
                AddPartStudent addPart = new AddPartStudent(model.SelectedEvent);
                addPart.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                addPart.ShowDialog();
                if (addPart.DialogResult == true)
                {
                    model.Parts.Add(addPart.model.Part);
                    model.SelectedParts.Add(addPart.model.Part);
                }
            }
        }

        private void RemoveStudentClick(object sender, RoutedEventArgs e)
        {
            if (model.Events.Contains(model.SelectedEvent) && model.SelectedParts.Contains(model.SelectedPart))
            {
                MessageBoxResult mess = MessageBox.Show("Удалить участника?", "Подтверждение", MessageBoxButton.YesNo);
                if (mess == MessageBoxResult.Yes)
                {
                    App.DbHelper.Part.Remove(model.SelectedPart);
                    App.DbHelper.SaveChanges();
                    model.SelectedParts.Remove(model.SelectedPart);
                    model.Parts.Remove(model.SelectedPart);
                }
            }
        }

        private void StudenListClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Main());
        }

        private void MoreStudentInfo(object sender, RoutedEventArgs e)
        {
            if(model.SelectedPart != null)
            {
                Student student = model.SelectedPart.Student;
                Main main = new Main();
                main.model.SelectedStudent = student;
                NavigationService.Navigate(main);
            }
        }
    }

    public class EventsViewModel : INotifyPropertyChanged
    {
        private Event selectedEvent;
        private ObservableCollection<Event> selectedEvents;
        private string filterName;
        private DateTime begginDate;
        private DateTime endDate;

        public ObservableCollection<DateBase.Event> Events { get; set; }
        public ObservableCollection<DateBase.Sphere> Spheres { get; set; }
        public ObservableCollection<DateBase.Level> Levels { get; set; }
        public ObservableCollection<DateBase.Part> Parts { get; set; }
        public ObservableCollection<DateBase.Part> SelectedParts { get; set; }
        public Part SelectedPart { get; set; }

        public string FilterName
        {
            get => filterName;
            set
            {
                filterName = value;
                Refresh();
            }
        }

        public DateTime BegginDate
        {
            get => begginDate;
            set
            {
                begginDate = value;
                Refresh();
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                Refresh();
            }
        }

        public ObservableCollection<Event> SelectedEvents
        {
            get => selectedEvents;
            set
            {
                selectedEvents = value;
                OnPropertyChanged("SelectedEvents");
            }
        }

        public Event SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        private void Refresh()
        {
            SelectedEvents = new ObservableCollection<Event>(
                Events.Where(x =>
                        x.Name.ToLower().Contains(FilterName.ToLower())

                    ).ToList()
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
