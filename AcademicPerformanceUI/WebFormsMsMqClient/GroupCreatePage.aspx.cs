using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class GroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private readonly IRepository<Cart> Repository = Singleton.UnitOfWork.CartRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["Id"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedSubject = Repository.GetAllEntitiesAsync().Result.Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

                    groupName.Text = _loadedSubject.Name;
                    groupMaxStudents.Text = _loadedSubject.MaxCapacity.ToString();
                    groupStudyYear.Text = _loadedSubject.TrainId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update group";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new group";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Cart subject = new Cart();
            subject.Id = Guid.NewGuid();
            subject.Name = groupName.Text;
            subject.MaxCapacity = int.Parse(groupMaxStudents.Text);
            subject.TrainId = Guid.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(subject);
                serviceClient.CreateGroup(serialized);
                scope.Complete();
            }
            Thread.Sleep(3000);

            Response.Redirect("groupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();
            group.Name = groupName.Text;
            group.MaxCapacity = int.Parse(groupMaxStudents.Text);
            group.TrainId = Guid.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(group);

                serviceClient.UpdateGroup(serialized);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}