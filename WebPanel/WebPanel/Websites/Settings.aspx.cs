using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanel.BL;

namespace WebPanel.Websites
{
    public partial class Settings : System.Web.UI.Page
    {
        private UserDataClass data;
        private String path = "D:/H8672/users.xml";

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((String)Session["loginname"] != "")
            {
                if (data == null) data = new UserDataClass();
                //Selected server is negative by default
                /*
                if ((String)Session["Server"] == "0")
                {

                }
                //Fill dropdownlists
                else
                {*/
                    /*
                    //Luetaan xml-tiedostosta tt:n tiedot ja esitetään new gvData:ssa
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    //DataView ei pakollinen, mutta hieno kuulemma
                    DataView dv = new DataView();
                    ds.ReadXml(path);
                    dt = ds.Tables[0];
                    dv = dt.DefaultView;
                    */
                    //Syötetään data näkyville
                    //gvData.DataSource = dt;
                    gvData.DataSource = data.getUserServers((String)Session["loginname"], path);
                    gvData.DataBind();
                    //TODO Add to dropdownlists data
                    
                //}

            }
            else
            {
                //If is not connected and tried to force his way in
                //Response.Redirect("~/Websites/Frontpage.aspx");
            }
        }
    }
}