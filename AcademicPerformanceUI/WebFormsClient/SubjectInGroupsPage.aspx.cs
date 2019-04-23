﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class SubjectInGroupsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = GetEntities();
                Repeater.DataBind();
            }
        }

        private List<SubjectInGroupDto> GetEntities()
        {
            string site = FormsSettings.HostUrl + "SubjectInGroupService.svc/Entities";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var text = "";
            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                text = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<SubjectInGroupDto>>(text);
        }

        private string DeleteEntity(string id)
        {
            string site = FormsSettings.HostUrl + "SubjectInGroupService.svc/Entities/" + id;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            req.Method = "DELETE";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return resp.StatusCode.ToString();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        DeleteEntity(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Thread.Sleep(3000);
                    Response.Redirect("subjectingroupspage");
                    break;
                case "Update":
                    Response.Redirect("subjectingroupCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("subjectingroupCreatePage");
        }
    }
}