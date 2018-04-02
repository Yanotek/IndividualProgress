using System;
using System.Collections.Generic;
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

namespace IndividualProgress.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddString.xaml
    /// </summary>
    public partial class AddString : Window
    {
        public string Value { get; set; }

        public AddString()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if(Value != null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных", "Ошибка");
            }
        }
    }
}
