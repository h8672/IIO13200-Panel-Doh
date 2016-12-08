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
                if (Session["Servers"] == null)
                    Session["Servers"] = data.getUserServers((String)Session["loginname"], path);
                else;
                dgData.DataSource = ((DataTable) Session["Servers"]);
                dgData.DataBind();
                //TODO Add to dropdownlists data
                //dgData.Items.Count;
                
                //}

            }
            else
            {
                //If is not connected and tried to force his way in
                //Response.Redirect("~/Websites/Frontpage.aspx");
            }
        }

        #region DataGrid_Methods
        protected void dgData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Server"] = dgData.SelectedIndex;
            dgData.SelectedItemStyle.BackColor = System.Drawing.Color.Aqua;
            tbServerUrl.Text = string.Format("{0}", dgData.SelectedIndex);
        }
        protected void btnEditServer_Click(object sender, EventArgs e)
        {

        }
        protected void btnDeleteServer_Click(object sender, EventArgs e)
        {

        }
        protected void Unnamed_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        protected void dgData_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            
        }
    }
}