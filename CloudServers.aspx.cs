using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using net.openstack.Providers;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace OpenStackDotNet_Test
{
    public partial class CloudServers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OneClick_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var serverdetails = CloudServersProvider.ListServersWithDetails(null, null, null, null, null, null, null, "dfw", identity);

                    CSListDDL.DataSource = serverdetails;
                    CSListDDL.DataTextField = "Name";
                    CSListDDL.DataValueField = "Id";
                    CSListDDL.DataBind();

                    var flavordetails = CloudServersProvider.ListFlavors(0, 0, null, 0, "dfw", identity);

                    CSFlavorsDDL.DataSource = flavordetails;
                    CSFlavorsDDL.DataTextField = "Name";
                    CSFlavorsDDL.DataValueField = "Id";
                    CSFlavorsDDL.DataBind();

                    var serverimagedetails = CloudServersProvider.ListImages(null, null, "ACTIVE", DateTime.UtcNow, null, 100, null, "dfw", identity);

                    CSImageListDDL.DataSource = serverimagedetails;
                    CSImageListDDL.DataBind();
                    CSImageListDDL.DataTextField = "Name";
                    CSImageListDDL.DataValueField = "Id";
                    CSImageListDDL.DataSource = serverimagedetails;

                    CSImageListDDL.DataBind();
                }
                else if (RegionORD.Checked)
                {
                    var serverdetails = CloudServersProvider.ListServersWithDetails(null, null, null, null, null, null, null, "ord", identity);

                    CSListDDL.DataSource = serverdetails;
                    CSListDDL.DataTextField = "Name";
                    CSListDDL.DataValueField = "Id";
                    CSListDDL.DataBind();

                    var flavordetails = CloudServersProvider.ListFlavors(0, 0, null, 0, "ord", identity);

                    CSFlavorsDDL.DataSource = flavordetails;
                    CSFlavorsDDL.DataTextField = "Name";
                    CSFlavorsDDL.DataValueField = "Id";
                    CSFlavorsDDL.DataBind();

                    var serverimagedetails = CloudServersProvider.ListImages(null, null, null, DateTime.Now, null, 0, null, "ord", identity);

                    CFResultsGrid.DataSource = serverimagedetails;
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
        protected void ListCloudServerIpAddresses_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var serveripaddressdetails = CloudServersProvider.ListAddresses(CSImageListDDL.SelectedValue, "dfw", identity);
                }
                else if (RegionORD.Checked)
                {
                    var serveripaddressdetails = CloudServersProvider.ListAddresses(CSImageListDDL.SelectedValue, "dfw", identity);

                    CFResultsGrid.DataSource = serveripaddressdetails;
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
        protected void RebootServer_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    CloudServersProvider.RebootServer(CSImageListDDL.SelectedValue, RebootType.SOFT, "dfw", identity);
                }
                else if (RegionORD.Checked)
                {
                    CloudServersProvider.RebootServer(CSImageListDDL.SelectedValue, RebootType.SOFT, "ord", identity);
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
        protected void CreateServer_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    CloudServersProvider.CreateServer(CSName.Text, null, CSFlavorsDDL.Text, null, null, "dfw", identity);
                }
                else if (RegionORD.Checked)
                {
                    CloudServersProvider.CreateServer(CSName.Text, null, CSFlavorsDDL.Text, null, null, "ord", identity);
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