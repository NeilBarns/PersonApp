using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using PersonApp.Models;
using PersonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonApp.Helper;

namespace PersonApp
{
    public partial class PopupPage : Page
    {
        PersonService personService = new PersonService();
        Person personInfo;
        public string dateData, intData;

        protected void Page_Load(object sender, EventArgs e)
        {
            string personId = Request.QueryString["id"];
            RegisterAsyncTask(new PageAsyncTask(() => GetPersonData(Convert.ToInt32(personId))));
        }

        protected async Task GetPersonData(int personId)
        {
            personInfo = await personService.GetPerson(personId);

            Label1.Text = personInfo.Name;
            Label2.Text = personInfo.Age.ToString();
            Label3.Text = personInfo.Type.ToString();

            GenerateRandomizedData();
        }

        protected void GenerateRandomizedData()
        {
            List<DateTime> randomDate = new List<DateTime>();
            List<int> randomInteger = new List<int>();

            for (int counter = 0; counter < 9; counter++)
            {
                randomDate.Add(HelperFunctions.DateRandomizer());
                randomInteger.Add(HelperFunctions.NumberRandomizer());
            }

            dateData = "[";
            foreach (DateTime date in randomDate)
            {
                dateData += $"'{date.ToString("MM/dd/yyyy")}',";
            }
            dateData = dateData.Remove(dateData.Length - 1) + "]";

            intData = "[";
            foreach (int number in randomInteger)
            {
                intData += $"{number},";
            }
            intData = intData.Remove(intData.Length - 1) + "]";
        }
    }
}