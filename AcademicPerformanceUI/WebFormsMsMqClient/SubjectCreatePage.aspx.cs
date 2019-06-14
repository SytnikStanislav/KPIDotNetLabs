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
    public partial class SubjectCreatePage : System.Web.UI.Page
    {
        private readonly IRepository<Train> Repository = Singleton.UnitOfWork.TrainRepostitory;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        private Guid _id;
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

                    subjectName.Text = _loadedSubject.Name;
                    subjectHours.Text = _loadedSubject.AmountOfCarts.ToString();
                    subjectTestType.Text = _loadedSubject.FinalTestType.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update subject";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new subject";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Train train = new Train();
            train.Id = Guid.NewGuid();
            train.Name = subjectName.Text;
            train.AmountOfCarts = int.Parse(subjectHours.Text);
            Enum.TryParse(subjectTestType.Text, out DataAccess.Models.FinalTestType rang);
            train.FinalTestType = rang;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(train);
                serviceClient.CreateSubject(serialized);
                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("subjectsPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var subject = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();
            subject.Name = subjectName.Text;
            subject.AmountOfCarts = int.Parse(subjectHours.Text);
            Enum.TryParse(subjectTestType.Text, out FinalTestType rang);
            subject.FinalTestType = rang;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(subject);
                serviceClient.UpdateSubject(serialized);
                scope.Complete();
            }

            Response.Redirect("subjectsPage");
        }
    }
}