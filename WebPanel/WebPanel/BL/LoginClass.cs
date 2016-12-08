using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace WebPanel.BL
{
    public class LoginClass
    {
        private Boolean logged;
        private String loginname;
        private String path;
        private String msg;
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
                //LINQ documentin teko
                XDocument doc = new XDocument(
                    new XElement("users",
                        new XElement("user",
                            new XElement("username", "Test"),
                            new XElement("password", "me"),
                            new XElement("email", "Email@Email.com"),
                            new XElement("securityQuestion", "SecurityQuestion"),
                            new XElement("securityAnswer", "SecurityAnswer"),
                            new XElement("servers",
                                new XElement("server",
                                    new XElement("name", "jamk mysql"),
                                    new XElement("url", "mysql.labranet.jamk.fi")
                                    )))));
                //Tallenna documentti
                doc.Save(path);
                
            }
        }

        public Boolean RegisterUser(String path, List<String> userdata)
        {
            //Load doc
            XDocument doc = XDocument.Load(path);

            //Create data
            XElement userNode = new XElement("user",
                new XElement("username", userdata.Select(0),
                new XElement("password", userdata.Select(1)),
                new XElement("email", userdata.Select(2)),
                new XElement("securityQuestion", userdata.Select(3)),
                new XElement("securityAnswer", userdata.Select(4)),
                new XElement("servers",
                    new XElement("server",
                        new XElement("name", "None"),
                        new XElement("url", "None")
                        ))));
            doc.Descendants("users").Single().Add(userNode);

            //Save changes
            doc.Save(path);
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
            if (!File.Exists(this.path)) return false;
            XmlDocument doc = new XmlDocument();
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
                    }
                    msg += "Did not find user\n " + item.ChildNodes.Item(0).InnerText;
                }
            }
            //If successful
            return found;
        }



    }



}