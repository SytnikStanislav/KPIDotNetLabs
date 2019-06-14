using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class CartViewModel:BaseViewModel<Cart>
    {
        public ObservableCollection<Guid> TrainIds { get; set; }
        public CartViewModel()
        {
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            SelectedEntity = new Cart();
            TrainIds = new ObservableCollection<Guid>(UnitOfWork.TrainRepostitory.GetAllEntitiesAsync().Result.Select((train => train.Id)));
        }
    }
}
