using PersonApp.Models;
using PersonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonApp
{
    public partial class PopupWindow : Page
    {
        PersonService personService = new PersonService();

        protected void Page_Load(object sender, EventArgs e)
        {
            string personId = Request.QueryString["id"];
            RegisterAsyncTask(new PageAsyncTask(() => GetPersonData(Convert.ToInt32(personId))));
        }

        protected async Task GetPersonData(int personId)
        {
            Person personInfo = await personService.GetPerson(personId);
        }
    }
}