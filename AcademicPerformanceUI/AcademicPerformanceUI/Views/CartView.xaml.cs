using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView: Page
    {
        private CartViewModel ViewModel { get; set; }

        public CartView()
        {
            InitializeComponent();
            ViewModel = new CartViewModel();
            DataContext = ViewModel;
        }

        private void Add_Group_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.AddData();
        }

        private void Update_Group_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateData();
        }

        private void Remove_Group_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveData();
        }

        private void Save_Group_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveEntity();
        }

        private void SaveAll__Group_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                ViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
