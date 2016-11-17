using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPanel.Websites
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["loginname"] != "")
                gridSQL.DataSource = ((LinkedList<string>)Session["Servers"]).ToList();
        }
    }
}