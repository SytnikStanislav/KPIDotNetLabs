using DataAccess.Models;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;

namespace WebFormsClient
{
    public partial class TicketCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<Ticket> client = new WebClientCrudService<Ticket>("TicketService.svc");
        private WebClientCrudService<Cart> clientCart = new WebClientCrudService<Cart>("CartService.svc");
        private WebClientCrudService<Passanger> clientPassanger = new WebClientCrudService<Passanger>("PassangerService.svc");
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
                    var _loadedSubject = client.GetEntities().Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

                    arrivalStation.Text = _loadedSubject.ArrivalStation;
                    arrivalDate.Text = _loadedSubject.ArrivalDate.ToString();
                    departureStation.Text = _loadedSubject.DepartureStation;
                    departureDate.Text = _loadedSubject.DepartureTime.ToString();
                    dropdownCart.SelectedValue = _loadedSubject.CartId.ToString();
                    dropdownPassanger.SelectedValue = _loadedSubject.PassangerId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update ticket";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new ticket";
                }
            }
            dropdownCart.DataSource = clientCart.GetEntities().Select(item => item.Id);
            dropdownPassanger.DataSource = clientPassanger.GetEntities().Select(item => item.Id);
            DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();

            ticket.ArrivalStation = arrivalStation.Text;
            ticket.ArrivalDate = DateTime.Parse(arrivalDate.Text);
            ticket.DepartureTime = DateTime.Parse(departureDate.Text);
            ticket.DepartureStation = departureStation.Text;
            ticket.CartId = Guid.Parse(dropdownCart.SelectedItem.Text);
            ticket.PassangerId = Guid.Parse(dropdownPassanger.SelectedItem.Text);
            ticket.Id = Guid.NewGuid();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.CreateEntity(ticket);

                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("ticketsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var ticket = client.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            ticket.ArrivalStation = arrivalStation.Text;
            ticket.ArrivalDate = DateTime.Parse(arrivalDate.Text);
            ticket.DepartureTime = DateTime.Parse(departureDate.Text);
            ticket.DepartureStation = departureStation.Text;
            ticket.CartId = Guid.Parse(dropdownCart.SelectedItem.Text);
            ticket.PassangerId = Guid.Parse(dropdownPassanger.SelectedItem.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.UpdateEntity(ticket);
                scope.Complete();
            }

            Response.Redirect("ticketsPage");
        }
    }
}