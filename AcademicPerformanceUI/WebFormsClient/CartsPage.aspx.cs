﻿using System;
using System.Transactions;
using System.Web.UI.WebControls;
using DataAccess.Models;

namespace WebFormsClient
{
    public partial class CartsPage : System.Web.UI.Page
    {
        private WebClientCrudService<Cart> webClient = new WebClientCrudService<Cart>("CartService.svc");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = webClient.GetEntities();
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
                        webClient.DeleteEntity(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Response.Redirect("cartspage");
                    break;
                case "Update":
                    Response.Redirect("cartCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("cartCreatePage");
        }
}
}