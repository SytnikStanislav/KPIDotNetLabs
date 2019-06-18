using DataAccess.Models;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;

namespace WebFormsClient
{
    public partial class SubjectInGroupCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<Passanger> client = new WebClientCrudService<Passanger>("PassangerService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedRoute = client.GetEntities().Where(x => x.Id == _id).FirstOrDefault();
                    firstname.Text = _loadedRoute.FirstName.ToString();
                    lastname.Text = _loadedRoute.LastName.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update passanger";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new passanger";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var route = new Passanger();
            route.Id = Guid.NewGuid();
            route.FirstName = firstname.Text;
            route.LastName = lastname.Text;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.CreateEntity(route);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("SubjectInGroupsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = client.GetEntities().Where(x => x.Id == _id).FirstOrDefault();

            route.FirstName = firstname.Text;
            route.LastName = lastname.Text;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.UpdateEntity(route);
                scope.Complete();
            }

            Response.Redirect("SubjectInGroupsPage");
        }
    }
}