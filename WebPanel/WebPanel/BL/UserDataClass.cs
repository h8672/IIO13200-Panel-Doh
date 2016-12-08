using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Data.SqlClient;
using System.Data;

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

        #region UserLocalDataMethods
        public DataTable getUserServers(String username, String path)
        {
            /*Muutos datatableks
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
            */

            //Return saved servers from xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //Select server nodes
            XmlNodeList nodes = doc.SelectNodes(string.Format("users/user[username='{0}']/servers/server", username));
            DataTable dt = new DataTable();
            //columns
            dt.Columns.Add("Server name", typeof(string));
            dt.Columns.Add("Server url", typeof(string));
            //Get server list to rows
            foreach (XmlNode node in nodes)
            {
                dt.Rows.Add(node["name"].InnerXml, node["url"].InnerXml);
            }
            return dt;
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

        #region UserServerDataMethods
        //TODO injection defenses on all methods!

        public List<String> getDatabases(String url, String username, String password)
        {
            //Get databases from MySQL server http://stackoverflow.com/questions/12862604/c-sharp-connect-to-database-and-list-the-databases
            String connectionStr =
                "Data Source=" + url + ";" +
                "User ID=" + username + ";" +
                "Password=" + password + ";" +
                "Integrated Security=True;";
            List<String> lists = new List<string>();
            using (var con = new SqlConnection(connectionStr))
            {
                con.Open();
                DataTable data = con.GetSchema("Databases");
                foreach (DataRow row in data.Rows)
                {
                    String databaseName = row.Field<String>("database_name");
                    lists.Add(databaseName);
                }
            }
            return lists;
        }

        public List<String> getTables(String url, String username, String password)
        {
            //Get databases from MySQL server http://stackoverflow.com/questions/12862604/c-sharp-connect-to-database-and-list-the-databases
            String connectionStr =
                "Data Source=" + url + ";" +
                "User ID=" + username + ";" +
                "Password=" + password + ";" +
                "Integrated Security=True;";
            List<String> lists = new List<string>();
            using (var con = new SqlConnection(connectionStr))
            {
                con.Open();
                DataTable data = con.GetSchema("Tables");
                foreach (DataRow row in data.Rows)
                {
                    String tableName = row.Field<String>("database_name");
                    lists.Add(tableName);
                }
            }
            return lists;
        }

        /*
            String connectionStr, viesti, taulu;
            connectionStr = "Data Source="+url+";Initial Catalog=master;User ID=koodari;Password=koodari16" providerName = "System.Data.SqlClient";
            taulu = "Tablename";
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + taulu, myConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, taulu);
                viesti = "Tiedot haettu onnistuneesti tietokannasta " + myConn.DataSource;
                return ds.Tables[taulu];
            }
            catch (Exception ex)
            {
                viesti = ex.Message;
                throw;
            }
            return databases;
    */

        #endregion

    }
}