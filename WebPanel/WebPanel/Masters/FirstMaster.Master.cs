using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanel.BL;

namespace WebPanel.Masters
{
    public partial class FirstMaster : System.Web.UI.MasterPage
    {
        private LoginClass logg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                nullSessions();

                //Load else once
                Button5.Visible = false;
                Button5.Text = "";
                Button2.Visible = true;
                Button3.Visible = true;
            }
            else if ((String)Session["loginname"] != "")
            {
                //Hide stuff if logged in
                Button5.Visible = true;
                Button2.Visible = false;
                Button2.Text = "";
                Button3.Visible = false;
                Button3.Text = "";
            }
            else
            {
                Button5.Visible = false;
                Button5.Text = "";
                Button2.Visible = true;
                Button3.Visible = true;
            }
            //NOTODO If someone is logged in, forward page to user pages with user masterpage.
            //EXPLANATION No longer page forward needed, decided to use this same master here
            //if (!(Session["loginname"] == "")) ;

            //"~/Websites/FrontPage.aspx";
        }

        private void nullSessions()
        {
            //Username
            Session.Add("loginname", "");
            //MySQL server names
            Session.Add("Servers", "");
            //MySQL server name selected from servers list
            Session.Add("Server", "0");
        }

        private Boolean CheckLogin()
        {
            if (logg == null) logg = new LoginClass("D:/H8672/users.xml");
            //TODO Check login names and passwords from local xml file!
            String str = logg.Login(Login.UserName.ToString(), Login.Password.ToString());
            Login.UserNameLabelText = str;
            return logg.LoggedIn;
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Check username and password
            e.Authenticated = CheckLogin();

            //If login failed
            if (!e.Authenticated) return;
            //Give session information that you have logged in
            Session["loginname"] = Login.UserName.ToString();
            //TODO SecondMaster to route these things..
            //Session["Servers"] = logg.getSavedSQL();
            //TODO change destination elsewhere... maybe?
            Login.DestinationPageUrl = "~/Websites/FrontPage.aspx";
        }

        #region Buttons
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Loads Frontpage, but maynot refresh page
            main.Visible = true;
            Register.Visible = false;
            Login.Visible = false;
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
            //Server.TransferRequest("~/Websites/About.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            nullSessions();
            Server.TransferRequest("~/Websites/Frontpage.aspx");
        }
        #endregion

    }
}