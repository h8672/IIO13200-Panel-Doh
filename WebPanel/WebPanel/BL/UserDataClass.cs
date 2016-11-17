using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;

namespace WebPanel.BL
{
    public class UserDataClass
    {
        private LinkedList<KeyValuePair<String, String>> list;

        #region ListMethods
        public LinkedList<KeyValuePair<String, String>> getServersList() { return list; }

        public void addServerToList(String name, String url)
        {
            //Adds server for list
            KeyValuePair<String, String> pair =
                new KeyValuePair<String, String>(name, url);
            //If list doesn't contain server already, add it to list
            if (!list.Contains(pair)) list.AddLast(pair);
        }
        #endregion

        #region UserDataMethods
        public LinkedList<KeyValuePair<String, String>> getUserServers(String username, String path)
        {
            //Return saved servers from xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //Select server nodes
            XmlNodeList nodes = doc.SelectNodes(string.Format("users/user[username={0}]/servers/server", username));
            list = new LinkedList<KeyValuePair<string, string>>();
            //Get server list
            foreach (XmlNode node in nodes)
            {
                KeyValuePair<String,String> pair = new KeyValuePair<String, String>(
                    node["name"].InnerXml,
                    node["url"].InnerXml
                );
                list.AddLast(pair);
            }
            return list;
        }

        //TODO Vielä tekeillä
        public void saveServersToUser(String username, String path)
        {
            //return saved servers from xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            //Select server nodes
            XmlNodeList nodes = doc.SelectNodes(string.Format("users/user[username={0}]/servers/server", username));
            //Tehdään väliaikainen lista
            LinkedList<KeyValuePair<String, String>> templist = new LinkedList<KeyValuePair<string, string>>(list);
            foreach (XmlNode node in nodes)
            {
                KeyValuePair<String, String> pair = new KeyValuePair<String, String>(
                    node["name"].InnerXml,
                    node["url"].InnerXml
                );
                //Jos nodelista sisältää parin, se poistetaan listasta
                if (templist.Contains(pair))
                {
                    templist.Remove(pair);
                }
            }
            //add servers to xml file
            foreach(KeyValuePair<String, String> pair in templist)
            {
                XmlElement server = doc.CreateElement("server");
                XmlElement name = doc.CreateElement("name");
                XmlElement url = doc.CreateElement("url");
                server.AppendChild(name);
                server.AppendChild(url);
                doc.DocumentElement.AppendChild(server);
                //TODO Hope it works...
            }
        }
        #endregion
    }
}