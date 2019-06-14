using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TeacherViewModel:BaseViewModel<Passanger>
    {
        public ObservableCollection<Guid> SubjectIds { get; set; }

        public TeacherViewModel()
        {
            SelectedEntity = new Passanger();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
           SubjectIds = new ObservableCollection<Guid>(UnitOfWork.TrainRepostitory.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
