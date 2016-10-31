using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPanel.BL
{
    public class LoginClass
    {
        private Boolean LoggedIn;
        private String loginname;
        //TODO huhu
        public String Loginname
        {
            get { return loginname; }
        }

        public String Login(String username, String password)
        {
            if (!LoggedIn)
            {
                LoggedIn = TryLogin(username, password);
                if (LoggedIn)
                {
                    this.loginname = username;
                    return "Login successful!";
                }
                else return "Wrong username or password!";
            }
            else return "You're already logged in!";
        }

        private Boolean TryLogin(String username, String password)
        {
            //TODO Check username and password from xml file!
            
            //If successful
            return true;
        }
    }
}