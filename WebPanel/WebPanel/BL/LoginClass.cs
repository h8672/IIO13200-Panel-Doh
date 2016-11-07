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
        private String msg;
        private LinkedList<string> servers;

        //TODO huhu
        public String Loginname
        {
            get { return loginname; }
        }

        public Boolean LoggedIn
        {
            get { return logged; }
        }

        public LoginClass(String path)
        {
            msg = "";
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
                            "<servers>",
                            "</servers>",
                        "</user>",
                    "</users>" };
                try
                {
                    File.WriteAllLines(this.path, contents);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public String Login(String username, String password)
        {
            if (!LoggedIn)
            {
                //Did login success?
                logged = TryLogin(username, password);
                if (LoggedIn)
                {
                    this.loginname = username;
                    return "Login successful!";
                }
                else return "Wrong username or password! " + this.msg;
            }
            else return "You have already logged in! " + this.msg;
        }

        private Boolean TryLogin(String username, String password)
        {
            //TODO Check username and password from xml file!
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(this.path)) return false;
            doc.Load(this.path);
            XmlNodeList nodes = doc.SelectNodes("/users/user");
            Boolean found = false;
            foreach (XmlNode item in nodes){
                if (item != null)
                {
                    if(item["username"].InnerText == username && item["password"].InnerText == password)
                    {
                        //User exists with that username, password combination!
                        found = true;
                        msg += "Found user\n";
                        XmlNodeList nods = item["servers"].ChildNodes;
                        //servers linkedlist initialize
                        servers = new LinkedList<string>();
                        foreach (XmlNode itemm in nods)
                        {
                            if (itemm != null)
                            {
                                //TODO List servers to LinkedList<String> and read them with getSavedSQL() function
                                servers.AddLast(itemm.InnerText);
                                msg += "Found server!\n";
                            }
                            else msg += "Did not find server for this user!\n";
                        }
                    }
                    msg += "Did not find user\n " + item.ChildNodes.Item(0).InnerText;
                }
            }
            //If successful
            return found;
        }

        public LinkedList<string> getSavedSQL()
        {
            //TODO return saved lists
            return this.servers;
        }
    }
}