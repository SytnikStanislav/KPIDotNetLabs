using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class TrainViewModel:BaseViewModel<Train>
    {
        public TrainViewModel()
        {
            SelectedEntity = new Train();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
        }
    }
}
