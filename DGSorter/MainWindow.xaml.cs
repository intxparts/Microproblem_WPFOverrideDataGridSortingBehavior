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
    }

    public static class DataGridExtensions
    {
        public static readonly DependencyProperty InitialSortDescending = DependencyProperty.RegisterAttached(
            nameof(InitialSortDescending), 
            typeof(bool), 
            typeof(DataGridExtensions),
            new PropertyMetadata(false)
        );

        public static void SetInitialSortDescending(DependencyObject e, bool v)
        {
            e.SetValue(InitialSortDescending, v);
        }

        public static bool GetInitialSortDescending(DependencyObject e)
        {
            return (bool)e.GetValue(InitialSortDescending);
        }

        public static readonly DependencyProperty RegisterInitialSortDescending = DependencyProperty.RegisterAttached(
            nameof(RegisterInitialSortDescending),
            typeof(bool),
            typeof(DataGridExtensions),
            new PropertyMetadata(false, OnRegisterSorting)
        );

        public static void SetRegisterInitialSortDescending(DependencyObject e, bool v)
        {
            e.SetValue(RegisterInitialSortDescending, v);
        }

        public static bool GetRegisterInitialSortDescending(DependencyObject e)
        {
            return (bool)e.GetValue(RegisterInitialSortDescending);
        }

        private static void OnRegisterSorting(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as DataGrid;
            if (grid == null)
                return;

            grid.Unloaded += Grid_Unloaded;
            grid.Sorting += Grid_Sorting;
        }

        private static void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid == null)
                return;

            grid.Unloaded -= Grid_Unloaded;
            grid.Sorting -= Grid_Sorting;
        }

        private static void Grid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null && (bool) e.Column.GetValue(InitialSortDescending))
                e.Column.SortDirection = System.ComponentModel.ListSortDirection.Ascending;
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
            _people.Add(new Person() { Name = "Lisa", Age = 33 });
            _people.Add(new Person() { Name = "Mary", Age = 33 });
            _people.Add(new Person() { Name = "Tim", Age = 21 });
            _people.Add(new Person() { Name = "Matt", Age = 28 });
            _people.Add(new Person() { Name = "Andrew", Age = 45 });
            _people.Add(new Person() { Name = "Bobby", Age = 57});
            _people.Add(new Person() { Name = "Ken", Age = 53 });
        }
    }
}
