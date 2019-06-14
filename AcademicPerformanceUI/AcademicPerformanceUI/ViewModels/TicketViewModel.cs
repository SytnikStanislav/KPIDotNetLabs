using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TicketViewModel:BaseViewModel<Ticket>
    {
        public ObservableCollection<Guid> PassangerIds { get; set; }
        public ObservableCollection<Guid> CartIds { get; set; }

        public TicketViewModel()
        {
            SelectedEntity = new Ticket();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            PassangerIds = new ObservableCollection<Guid>(UnitOfWork.PassangerRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
            CartIds = new ObservableCollection<Guid>(UnitOfWork.CartRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
