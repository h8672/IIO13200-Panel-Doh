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
            //TODO Login check!
            //if()
        }

        private Boolean CheckLogin(String username, String password)
        {
            //Check login names and passwords from local xml file!

            return true;
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Check username and password
            e.Authenticated = CheckLogin(Login.UserName, Login.Password);

            //If login failed
            if (!e.Authenticated)
            {
                main.Visible = true;
            }
            //Hide login button if login was succesful
            else Button2.Visible = false;

            //No need to hide login, it hides automatically when page reloads
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Show Login and hide contents
            if (Register.Visible) Register.Visible = false;
            else
            {
                main.Visible = false;
                Login.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Show Register and hide contents
            if (Login.Visible)
            {
                Login.Visible = false;
            }
            else
            {
                main.Visible = false;
                Register.Visible = true;
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}