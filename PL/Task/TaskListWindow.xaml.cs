using PL.Engineer;
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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {
        // DependencyProperty for TaskList property
        public IEnumerable<BO.Task> TaskList
        {
            get { return (IEnumerable<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }

        public static readonly DependencyProperty TaskListProperty =
            DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.Task>), typeof(TaskListWindow), new PropertyMetadata(null));

        // Property for Experience
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        // Property for Status
        public BO.TaskStatus Status { get; set; } = BO.TaskStatus.None;

        // Static instance of the business logic layer
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        // Constructor for TaskListWindow
        public TaskListWindow()
        {
            InitializeComponent();
            TaskList = s_bl?.Task.ReadAll()!;
        }

        // Event handler for the window's activity event
        private void window_activity(object sender, EventArgs e)
        {
            TaskList = s_bl?.Task.ReadAll()!;
        }

        // Event handler for the ExperienceChanged event
        private void ExperienceChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskList = (Status == BO.TaskStatus.None) ?
                s_bl?.Task.ReadAll()! : s_bl?.Task.ReadAll(item => item.Status == Status)!;
        }

        // Event handler for the Button_Click event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TaskWindow().ShowDialog();
        }

        // Event handler for the OnListViewClicked event
        private void OnListViewClicked(object sender, MouseButtonEventArgs e)
        {
            BO.Task? taskInList = (sender as ListView)?.SelectedItem as BO.Task;
            int id = taskInList!.Id;

            new TaskWindow(id).ShowDialog();
        }
    }
}
