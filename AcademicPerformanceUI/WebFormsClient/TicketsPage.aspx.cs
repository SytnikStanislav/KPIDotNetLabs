using System;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Threading;
using DataAccess.Models;

namespace WebFormsClient
{
    public partial class TicketsPage : System.Web.UI.Page
    {
        private WebClientCrudService<Ticket> client = new WebClientCrudService<Ticket>("TicketService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = client.GetEntities();
                Repeater.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        client.DeleteEntity(e.CommandArgument.ToString());
                        scope.Complete();
                    }
                    Thread.Sleep(3000);
                    Response.Redirect("ticketspage");
                    break;

                case "Update":
                    Response.Redirect("ticketCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ticketCreatePage");
        }
    }
}