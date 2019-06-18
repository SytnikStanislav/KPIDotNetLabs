using System;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using DataAccess.Models;

namespace WebFormsClient
{
    public partial class GroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<Cart> webClient = new WebClientCrudService<Cart>("CartService.svc");
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
                    var _loadedSubject = webClient.GetEntities().FirstOrDefault(i => i.Id == Guid.Parse(id));

                    groupName.Text = _loadedSubject.Name;
                    groupMaxStudents.Text = _loadedSubject.MaxCapacity.ToString();
                    groupStudyYear.Text = _loadedSubject.TrainId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update cart";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new cart";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Cart subject = new Cart();
            subject.Name = groupName.Text;
            subject.MaxCapacity = int.Parse(groupMaxStudents.Text);
            subject.TrainId = Guid.NewGuid();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.CreateEntity(subject);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = webClient.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            group.Name = groupName.Text;
            group.MaxCapacity = int.Parse(groupMaxStudents.Text);
            group.TrainId = Guid.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.UpdateEntity(group);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}