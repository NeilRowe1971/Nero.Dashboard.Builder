using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nero.Windows.Controls
{
    public partial class SQLServerDatabaseControl : UserControl
    {

        public ConnectionDetails SQLConnectionDetails { get; set; }

        public SQLServerDatabaseControl()
        {
            InitializeComponent();
        }

        private void buttonRefreshServer_Click(object sender, EventArgs e)
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
