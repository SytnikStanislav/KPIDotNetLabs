using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectViewModel:BaseViewModel<Train>
    {
        public SubjectViewModel()
        {
            SelectedEntity = new Train();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
        }
    }
}
