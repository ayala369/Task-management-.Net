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

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        // Dependency property for the current engineer
        public BO.Engineer CurrentEngineer
        {
            get { return (BO.Engineer)GetValue(CurrentEngineerProperty); }
            set { SetValue(CurrentEngineerProperty, value); }
        }

        public static readonly DependencyProperty CurrentEngineerProperty =
            DependencyProperty.Register("CurrentEngineer", typeof(BO.Engineer), typeof(EngineerWindow), new PropertyMetadata(null));

        // Property for the engineer's experience
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        // Static readonly field for the business logic layer
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        // Constructor for the EngineerWindow
        public EngineerWindow(int Id = 0)
        {
            InitializeComponent();

            if (Id == 0)
            {
                // Creating a new engineer if Id is 0
                CurrentEngineer = new BO.Engineer
                {
                    Id = 0,
                    Name = "",
                    Email = "",
                    Level = BO.EngineerExperience.None,
                    Cost = 0,
                    Task = null
                };
            }
            else
            {
                // Reading the existing engineer if Id is not 0
                CurrentEngineer = s_bl?.Engineer.Read(Id)!;
            }
        }

        // Event handler for the AddOrUpdate button click
        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)!.Content.ToString() == "Add")
            {
                try
                {
                    // Adding a new engineer
                    int? id = s_bl.Engineer.Create(CurrentEngineer!);
                    MessageBox.Show($"Engineer {id} was successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
                    // Updating an existing engineer
                    s_bl.Engineer.Update(CurrentEngineer!);
                    MessageBox.Show($"Engineer {CurrentEngineer?.Id} was successfully updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
