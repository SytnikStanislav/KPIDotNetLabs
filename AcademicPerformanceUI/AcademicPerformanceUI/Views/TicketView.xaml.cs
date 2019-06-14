using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TestResultResultView.xaml
    /// </summary>
    public partial class TicketView : Page
    {

        private TicketViewModel TicketViewModel { get; set; }

        public TicketView()
        {
            InitializeComponent();
            TicketViewModel = new TicketViewModel();
            DataContext = TicketViewModel;
        }

        private void Add_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TicketViewModel.AddData();
        }

        private void Update_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TicketViewModel.UpdateData();
        }

        private void Remove_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TicketViewModel.RemoveData();
        }

        private void Save_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TicketViewModel.SaveEntity();
        }

        private void SaveAll__TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TicketViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                TicketViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
