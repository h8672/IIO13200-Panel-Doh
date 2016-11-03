using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebPanel.Masters;

namespace WebPanel.Websites
{
    public partial class Frontpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUser.Text = Session.Count.ToString();
            lblUser.Text = (String) Session["loginname"];
        }
    }
}