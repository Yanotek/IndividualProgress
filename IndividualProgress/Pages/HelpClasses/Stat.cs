using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProgress.Pages.HelpClasses
{
    public class Stat : INotifyPropertyChanged
    {
        private string countParts;
        private string countFirstPlace;
        private string countSecondPlace;
        private string countThirdPlace;
        private string countPrizePlace;
        private string allResult;
        private string averagePlace;

        public string CountParts
        {
            get { return countParts; }
            set
            {
                countParts = value;
                OnPropertyChanged("CountParts");
            }
        }

        public string CountFirstPlace
        {
            get { return countFirstPlace; }
            set
            {
                countFirstPlace = value;
                OnPropertyChanged("CountFirstPlace");
            }
        }
        public string CountSecondPlace
        {
            get { return countSecondPlace; }
            set
            {
                countSecondPlace = value;
                OnPropertyChanged("CountSecondPlace");
            }
        }
        public string CountThirdPlace
        {
            get { return countThirdPlace; }
            set
            {
                countThirdPlace = value;
                OnPropertyChanged("CountThirdPlace");
            }
        }
        public string CountPrizePlace
        {
            get { return countPrizePlace; }
            set
            {
                countPrizePlace = value;
                OnPropertyChanged("CountPrizePlace");
            }
        }

        public string AveragePlace
        {
            get => averagePlace;
            set
            {
                averagePlace = value;
                OnPropertyChanged("AveragePlace");
            }
        }
        public string AllResult
        {
            get => allResult;
            set
            {
                allResult = value;
                OnPropertyChanged("AllResult");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged ([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop));
        }
    }
}
