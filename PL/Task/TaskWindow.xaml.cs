using BO;
using PL.Engineer;
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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {

        // DependencyProperty for CurrentTask property
        public BO.Task CurrentTask
        {
            get { return (BO.Task)GetValue(CurrentTaskProperty); }
            set { SetValue(CurrentTaskProperty, value); }
        }

        public static readonly DependencyProperty CurrentTaskProperty =
            DependencyProperty.Register("CurrentTask", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null));

        // Properties for Experience and Status
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;
        public BO.TaskStatus Status { get; set; } = BO.TaskStatus.None;

        // Static instance of the business logic layer
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        // DependencyProperty for Engineer property
        public BO.EngineerInTask? Engineer
        {
            get { return (BO.EngineerInTask)GetValue(EngineerProperty); }
            set { SetValue(EngineerProperty, value); }
        }

        public static readonly DependencyProperty EngineerProperty =
            DependencyProperty.Register("Engineer", typeof(BO.EngineerInTask), typeof(TaskWindow), new PropertyMetadata(null));

        // DependencyProperty for EngineersList property
        public ObservableCollection<BO.Engineer> EngineersList
        {
            get { return (ObservableCollection<BO.Engineer>)GetValue(EngineersListProperty); }
            set { SetValue(EngineersListProperty, value); }
        }

        public static readonly DependencyProperty EngineersListProperty =
            DependencyProperty.Register("EngineersList", typeof(ObservableCollection<BO.Engineer>), typeof(TaskWindow), new PropertyMetadata(null));

        ///***************************************************************************************

        // Constructor for the TaskWindow class
        public TaskWindow(int Id = 0)
        {
            InitializeComponent();

            if (Id == 0)
            {
                // Initialize a new Task if Id is 0
                CurrentTask = new BO.Task
                {
                    Id = 0,
                    Description = "",
                    Alias = "",
                    Milestone = null,
                    Status = BO.TaskStatus.None,
                    CreatedAtDate = DateTime.Now,
                    BaselineStartDate = null,
                    StartDate = null,
                    ForecastDate = null,
                    DeadlineDate = null,
                    CompleteDate = null,
                    Deliverables = "",
                    Remarks = "",
                    Dependencies = new List<TaskInList>(),
                    Engineer = null,
                    ComplexityLevel = EngineerExperience.None
                };
            }
            else
            {
                // Read the Task with the given Id from the business logic layer
                CurrentTask = s_bl?.Task.Read(Id)!;
            }
        }

        // Event handler for the AddOrUpdate button click
        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as Button)?.Content?.ToString() == "Add"))
            {
                try
                {
                    // Create a new Task using the business logic layer
                    int? id = s_bl.Task.Create(CurrentTask!);
                    MessageBox.Show($"task {id} was successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
                catch (BO.BlAlreadyExistsException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Fail", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Operation Fail", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else // Update
            {
                try
                {
                    // Update the existing Task using the business logic layer
                    s_bl.Task.Update(CurrentTask!);
                    MessageBox.Show($"Task {CurrentTask?.Id} was successfully updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (BO.BlDoesNotExistException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Fail", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Operation Fail", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
