using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using IndividualProgress.DateBase;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Runtime.CompilerServices;

namespace IndividualProgress.Pages
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        StatisticsViewModel model = new StatisticsViewModel();
        public Statistics()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void GoStudent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Main());
        }

        private void GoEvent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Events());
        }
    }

    public class StatisticsViewModel :INotifyPropertyChanged
    {
        public Sphere AnySphere { get; set; } = new Sphere()
        {
            Name = "Любая сфера"
        };
        public Teacher AnyTeacher { get; set; } = new Teacher()
        {
            Name = "Любой преподаватель"
        };
        public Level AnyLevel { get; set; } = new Level()
        {
            Name = "Любой уровень"
        };

        public StatisticsViewModel() 
        {
            Teachers = new ObservableCollection<Teacher>(App.DbHelper.Teacher.ToList());
            Teachers.Add(AnyTeacher);
            Spheres = new ObservableCollection<Sphere>(App.DbHelper.Sphere.ToList());
            Spheres.Add(AnySphere);
            Levels = new ObservableCollection<Level>(App.DbHelper.Level.ToList());
            Levels.Add(AnyLevel);
            Parts = new ObservableCollection<Part>(App.DbHelper.Part
                .Include(x => x.Teacher)
                .Include(x => x.Student)
                .Include(x => x.Event).ThenInclude(x => x.Direction).ThenInclude(x=> x.Sphere)
                );
            SelectedParts = new ObservableCollection<Part>();
            var view = CollectionViewSource.GetDefaultView(Parts);

            EndDate = DateTime.Now;
            try
            {
                BeginDate = App.DbHelper.Event.Min(x => x.Date).Date;
            }
            catch { }

            PartsView = view;
            SelectedTeacher = AnyTeacher;
            SelectedSphere = AnySphere;
            SelectedLevel = AnyLevel;
        }

        public ObservableCollection<Teacher> Teachers { get; set; }
        public ObservableCollection<Sphere> Spheres { get; set; }
        public ObservableCollection<Level> Levels { get; set; }
        public Teacher SelectedTeacher { get => _selectedTeacher; set { _selectedTeacher = value; Refresh(); } }
        public Sphere SelectedSphere { get => _selectedSphere; set { _selectedSphere = value; Refresh(); } }
        public Level SelectedLevel { get => _selectedLevel; set { _selectedLevel = value; Refresh(); } }
        public DateTime BeginDate { get => _beginDate; set { _beginDate = value; Refresh(); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; Refresh(); } }
        public ObservableCollection<Part> Parts { get; set; }
        public ObservableCollection<Part> SelectedParts
        {
            get { return _selectedParts; }
            set
            {
                _selectedParts = value;
                OnPropertyChanged("SelectedParts");
            }
        }
        public ICollectionView PartsView { get; set; }
        public HelpClasses.Stat Stat { get; set; } = new HelpClasses.Stat();
        

        private Teacher _selectedTeacher;
        private Sphere _selectedSphere;
        private Level _selectedLevel;
        private DateTime _beginDate;
        private DateTime _endDate;
        public ObservableCollection<Part> _selectedParts;



        void Refresh()
        {
            SelectedParts = new ObservableCollection<Part>(Parts.Where(x =>
                    (x.Event.Date >= BeginDate && x.Event.Date <= EndDate) &&
                    (SelectedLevel == null || SelectedLevel == AnyLevel || x.Event.Level == SelectedLevel) &&
                    (SelectedTeacher == null || SelectedTeacher == AnyTeacher || x.Teacher == SelectedTeacher) &&
                    (SelectedSphere == null || SelectedSphere == AnySphere || x.Event.Direction.Sphere == SelectedSphere)).ToList());
            Stat.CountFirstPlace = SelectedParts.Count(x => x.Place == 1).ToString();
            Stat.CountSecondPlace = SelectedParts.Count(x => x.Place == 2).ToString();
            Stat.CountThirdPlace = SelectedParts.Count(x => x.Place == 3).ToString();
            Stat.CountParts = SelectedParts.Count.ToString();
            Stat.CountPrizePlace = SelectedParts.Count(x => x.Place <= 3).ToString();
            Stat.AllResult =Math.Round((Convert.ToDouble(SelectedParts.Count(x => x.Place <= 3)) / Convert.ToDouble(SelectedParts.Count) * 100),2).ToString() + "%";
            Stat.AveragePlace =Math.Round(Convert.ToDouble(SelectedParts.Average(x => x.Place)),2).ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
