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

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerListWindow.xaml
    /// </summary>
    public partial class EngineerListWindow : Window
    {
        // DependencyProperty for EngineerList property
        public IEnumerable<BO.Engineer> EngineerList
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }

        public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.Engineer>), typeof(EngineerListWindow), new PropertyMetadata(null));

        // Property for Experience
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        // Static instance of the business logic layer
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        // Constructor for EngineerListWindow
        public EngineerListWindow()
        {
            InitializeComponent();
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        // Event handler for the window's activity event
        private void window_activity(object sender, EventArgs e)
        {
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        // Event handler for the ExperienceChanged event
        private void ExperienceChanged(object sender, SelectionChangedEventArgs e)
        {
            EngineerList = (Experience == BO.EngineerExperience.None) ?
                s_bl?.Engineer.ReadAll()! : s_bl?.Engineer.ReadAll(item => item.Level == Experience)!;
        }

        // Event handler for the Button_Click event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new EngineerWindow().ShowDialog();
        }

        // Event handler for the OnListViewClicked event
        private void OnListViewClicked(object sender, MouseButtonEventArgs e)
        {
            BO.Engineer? engineerInList = (sender as ListView)?.SelectedItem as BO.Engineer;
            int id = engineerInList!.Id;

            new EngineerWindow(id).ShowDialog();
        }

        // Event handler for the ListView_SelectionChanged event
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Currently, this event handler does not have any logic
        }
    }
}
