using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TrainView.xaml
    /// </summary>
    public partial class TrainView : Page
    {
        private TrainViewModel TrainViewModel { get; set; }

        public TrainView()
        {
            InitializeComponent();
            TrainViewModel = new TrainViewModel();
            DataContext = TrainViewModel;
        }

        private void Add_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            TrainViewModel.AddData();
        }

        private void Update_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            TrainViewModel.UpdateData();
        }

        private void Remove_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            TrainViewModel.RemoveData();
        }

        private void Save_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            TrainViewModel.SaveEntity();
        }

        private void SaveAll__Subject_OnClick(object sender, RoutedEventArgs e)
        {
            TrainViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                TrainViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
