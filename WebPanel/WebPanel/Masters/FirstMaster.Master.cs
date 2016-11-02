using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPanel.Masters
{
    public partial class FirstMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession) Session.Add("loginname", "");
            //TODO If someone is logged in, forward page to user pages with user masterpage.
            if (!(Session["loginname"] == "")) ;

            //"~/Websites/FrontPage.aspx";
        }

        private Boolean CheckLogin(String username, String password)
        {
            //TODO Check login names and passwords from local xml file!

            return true;
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Check username and password
            e.Authenticated = CheckLogin(Login.UserName, Login.Password);

            //If login failed
            if (!e.Authenticated) return;
            //Give session information that you have logged in
            Session["loginname"] = Login.UserName;
            //Hide login button if login was succesful
            Button2.Visible = false;
            //TODO change destination elsewhere...
            Login.DestinationPageUrl = "~/Websites/FrontPage.aspx";
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Loads Frontpage
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Show Login and hide contents
            main.Visible = false;
            Register.Visible = false;
            Login.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Show Register and hide contents
            main.Visible = false;
            Login.Visible = false;
            Register.Visible = true;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Loads Aboutpage
        }
    }
}