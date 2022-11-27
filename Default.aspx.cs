using PersonApp.Helper;
using PersonApp.Models;
using PersonApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using static PersonApp.Constants.Enumerations;

namespace PersonApp
{
    public partial class _Default : Page
    {
        PersonService personService = new PersonService();

        private List<Person> _people = new List<Person>();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetData));
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = HelperFunctions.ToDataTable(_people);
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            ModifyData(e, DataEvent.Insert);
        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            ModifyData(e, DataEvent.Update);
        }

        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            ModifyData(e, DataEvent.Delete);
        }
        
        protected void RadGrid1_ItemDataBound(object source, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                TableCell typeId = item["Type"];
                ImageButton btn = (ImageButton)item["Info"].Controls[0];
                if (typeId.Text == "1")
                {
                    btn.ImageUrl = "Media/info.png";
                    int id = Convert.ToInt32(item.GetDataKeyValue("Id").ToString());
                    btn.Attributes.Add("onclick", $"OpenPopup({id});");
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "ShowInfo")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string strtxt = item["colProduct"].Text;

            }
        }

        protected void ModifyData(GridCommandEventArgs e, DataEvent dataEvent)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int id = 0;

            try
            {
                id = Convert.ToInt32(editedItem.GetDataKeyValue("Id").ToString());
            }
            catch
            {
                id = 0;
            }
            

            Hashtable newValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

            Person modifiedPerson = new Person()
            {
                Id = id,
                Name = newValues["Name"].ToString(),
                Age = Convert.ToInt32(newValues["Age"].ToString()),
                Type = Convert.ToInt32(newValues["Type"].ToString())
            };

            if (dataEvent == DataEvent.Insert || dataEvent == DataEvent.Update)
            {
                RegisterAsyncTask(new PageAsyncTask(() => UpdateData(modifiedPerson)));
            }
            else if (dataEvent == DataEvent.Delete)
            {
                RegisterAsyncTask(new PageAsyncTask(() => DeleteData(id)));
            }

            
            RegisterAsyncTask(new PageAsyncTask(GetData));
        }

        protected async Task GetData()
        {
            _people = await personService.GetPersonList();
            BindData();
        }

        protected async Task UpdateData(Person modifiedPerson)
        {
            await personService.UpdatePerson(modifiedPerson);
        }

        protected async Task DeleteData(int personId)
        {
            await personService.DeletePerson(personId);
        }

        private void BindData()
        {
            RadGrid1.DataSource = HelperFunctions.ToDataTable(_people);
            RadGrid1.DataBind();
        }
    }
}