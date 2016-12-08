using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebPanel.BL;

namespace WebPanel.Websites
{
    public partial class SQLview : System.Web.UI.Page
    {
        private UserDataClass data;
        private String path = "D:/H8672/users.xml";

        protected void Page_Load(object sender, EventArgs e)
        {
            if((String) Session["loginname"] != "")
            {
                if (data == null) data = new UserDataClass();
                //Selected server is negative by default
                if((String) Session["Server"] == "0")
                {
                    ddlDatabase.Items.Add("Empty");
                    ddlTable.Items.Add("Empty");
                    
                }
                //Fill dropdownlists
                else
                {
                    //TODO Add to dropdownlists data
                    ddlDatabase.Items.Add("");
                }

            }
            else
            {
                //If is not connected and tried to force his way in
                //Response.Redirect("~/Websites/Frontpage.aspx");
            }
        }

        protected void tabMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //Change tabview for page
            Menu menu = (Menu)sender;
            switch (menu.SelectedValue)
            {
                case "0":
                    MultiView.ActiveViewIndex = 0;
                    break;
                case "1":
                    MultiView.ActiveViewIndex = 1;
                    break;
                case "2":
                    MultiView.ActiveViewIndex = 2;
                    break;
                default:
                    //There is too many tabs!
                    break;
            }
        }

        //Gridview help buttons for those who aren't used to gridview
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Add item to gridview
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Edit item in gridview
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            //Remove item from gridview
        }
    }
}