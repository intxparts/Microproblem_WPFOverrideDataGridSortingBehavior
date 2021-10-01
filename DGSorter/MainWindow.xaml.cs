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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DGSorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if ((string) e.Column.Header == "Name" && e.Column.SortDirection == null)
                e.Column.SortDirection = System.ComponentModel.ListSortDirection.Ascending;

            e.Handled = false;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainWindowViewModel
    {
        private readonly List<Person> _people;
        public List<Person> People => _people;

        public MainWindowViewModel()
        {
            _people = new List<Person>();
            _people.Add(new Person() { Name = "James", Age = 33 });
            _people.Add(new Person() { Name = "Tim", Age = 21 });
            _people.Add(new Person() { Name = "Matt", Age = 28 });
            _people.Add(new Person() { Name = "Andrew", Age = 45 });
            _people.Add(new Person() { Name = "Bobby", Age = 57});
            _people.Add(new Person() { Name = "Ken", Age = 53 });
        }
    }
}
