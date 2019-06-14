using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for PassangerView.xaml
    /// </summary>
    public partial class PassangerView : Page
    {
        private PassangerViewModel PassangerViewModel { get; set; }

        public PassangerView()
        {
            InitializeComponent();
            PassangerViewModel = new PassangerViewModel();
            DataContext = PassangerViewModel;
        }

        private void Add_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            PassangerViewModel.AddData();
        }

        private void Update_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            PassangerViewModel.UpdateData();
        }

        private void Remove_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            PassangerViewModel.RemoveData();
        }

        private void Save_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            PassangerViewModel.SaveEntity();
        }

        private void SaveAll__Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            PassangerViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                PassangerViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
