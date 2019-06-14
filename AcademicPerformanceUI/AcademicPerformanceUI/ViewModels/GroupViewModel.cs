using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class GroupViewModel:BaseViewModel<Cart>
    {
        public GroupViewModel()
        {
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            SelectedEntity = new Cart();
        }
    }
}
