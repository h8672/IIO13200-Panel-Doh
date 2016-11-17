﻿using System;
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
                //Username
                Session.Add("loginname", "");
                //MySQL server name selected from servers list
                Session.Add("Server", 0);
                //MySQL server names
                Session.Add("Servers", "");
            }
            //TODO If someone is logged in, forward page to user pages with user masterpage.
            //if (!(Session["loginname"] == "")) ;

            //"~/Websites/FrontPage.aspx";
        }

        private Boolean CheckLogin()
        {
            if(logg == null) logg = new LoginClass("D:/H8672/users.xml");
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
            Session["Servers"] = logg.getSavedSQL();
            //Hide login button if login was succesful
            Button2.Visible = false;
            //TODO change destination elsewhere...
            Login.DestinationPageUrl = "~/Websites/FrontPage.aspx";
        }

        #region Buttons
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
        #endregion
    }
}