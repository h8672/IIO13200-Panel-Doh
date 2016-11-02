using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace WebPanel.BL
{
    public class LoginClass
    {
        private Boolean logged;
        private String loginname;
        private String path;
        //TODO huhu
        public String Loginname
        {
            get { return loginname; }
        }

        public Boolean LoggedIn
        {
            get { return logged; }
        }

        LoginClass(String path)
        {
            this.path = path;
            //TODO LoginClass
            if (!File.Exists(this.path))
            {
                String[] contents = {
                    "<users>",
                        "<user>",
                            "<username>Test</username>",
                            "<password>me</password>",
                            "<email>Email@Email.com</email>",
                            "<securityQuestion>SecurityQuestion</securityQuestion>",
                            "<securityAnswer>SecurityAnswer</securityAnswer>",
                        "</user>",
                    "</users>" };
                File.WriteAllLines(this.path, contents);
            }
        }

        public String Login(String username, String password)
        {
            if (!LoggedIn)
            {
                logged = TryLogin(username, password);
                if (logged)
                {
                    this.loginname = username;
                    return "Login successful!";
                }
                else return "Wrong username or password!";
            }
            else return "You have already logged in!";
        }

        private Boolean TryLogin(String username, String password)
        {
            //TODO Check username and password from xml file!
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(this.path)) return false;
            doc.Load(this.path);
            XmlNodeList nodes = doc.SelectNodes("/users/");
            Boolean found = false;
            foreach (XmlNode item in nodes){
                if (item["user"] != null)
                {
                    if(item.ChildNodes.Item(0).ToString() == username && item.ChildNodes.Item(1).ToString() == password)
                    {
                        //User exists with that username, password combination!
                        found = true;
                    }

                }
            }
            //If successful
            return found;
        }
    }
}