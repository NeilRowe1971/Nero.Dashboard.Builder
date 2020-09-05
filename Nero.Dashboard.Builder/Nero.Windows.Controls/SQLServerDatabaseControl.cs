using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace Nero.Windows.Controls
{
    public partial class SQLServerDatabaseControl : UserControl
    {

        public ConnectionDetails SQLConnectionDetails { get; set; }

        private List<string> ServerList { get; set; } = new List<string>();

        public SQLServerDatabaseControl()
        {
            InitializeComponent();
        }

        private void ButtonRefreshServer_Click(object sender, EventArgs e)
        {
            ServerList = GetServerList();


            comboBoxSQLServers.DataSource = ServerList;
        }
        #region SQL Methods




        private List<string> GetServerList()
        {

            List<string> serverList = new List<string>();

            string myServer = Environment.MachineName;

            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)
                        serverList.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        serverList.Add(servers.Rows[i]["ServerName"].ToString());
                }
                else
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)
                        serverList.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        serverList.Add(servers.Rows[i]["ServerName"].ToString());


                }
            }

            return serverList;
        }






        #endregion

        private void SQLServerDatabaseControl_Load(object sender, EventArgs e)
        {

        }
    }


    public class ConnectionDetails
    {
        public string ServerName { get; set; }
        public string Database { get; set; }
        public Boolean IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }





}
