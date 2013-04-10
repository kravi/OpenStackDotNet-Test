using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using net.openstack.Providers;
using net.openstack.Core;
using net.openstack.Providers.Rackspace;

namespace OpenStackDotNet_Test
{
    public partial class CloudServers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListAvailableServers_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var serverdetails = CloudServersProvider.ListServersWithDetails(null, null, null, null, null, null, null, null, identity);

                    CFResultsGrid.DataSource = serverdetails;
                    CFResultsGrid.DataBind();
                }
                else if (RegionDFW.Checked)
                {
                    var serverdetails = CloudServersProvider.ListServersWithDetails(null, null, null, null, null, null, null, null, identity);

                    CFResultsGrid.DataSource = serverdetails;
                    CFResultsGrid.DataBind();
                }
                else
                {
                    LblInfo.Text = "Please select DFW or ORD not both.";
                }
            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
    }
}