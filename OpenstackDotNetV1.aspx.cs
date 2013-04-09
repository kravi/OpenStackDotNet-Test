using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using net.openstack.Providers;
using net.openstack.Core;
using net.openstack.Providers.Rackspace;

namespace OpenStackDotNet_Test
{
    public partial class OpenstackDotNetV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListContainerContents_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerText.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "dfw", identity);

                CFResultsGrid.DataSource = Cfobjects;
                CFResultsGrid.DataBind();
            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
        protected void CloudFilesUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerText.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (FileUpload1.HasFile)
                {
                    //create the path to save the file to
                    string fileName = FileUpload1.FileName;
                    string path = Server.MapPath("~/temp");

                    //save the file to our local path
                    FileUpload1.SaveAs(Path.Combine(path, fileName));

                    CloudFilesProvider.CreateObjectFromFile(containername, path, fileName, 4096, null, "dfw", null, identity);

                    Error.Text = FileUpload1.FileName + " Has Been Uploaded Successfully";

                }
                else
                {
                    Error.Text = FileUpload1.FileName + " Please select a file to upload.";
                }

            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
        protected void ListAvailableServers_Click(object sender, EventArgs e)
        {
            try
            {
                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudServersProvider CloudServersProvider = new net.openstack.Providers.Rackspace.CloudServersProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                var serverdetails = CloudServersProvider.ListServersWithDetails(null, null, null, null, null, null, null, null, identity);

                CFResultsGrid.DataSource = serverdetails;
                CFResultsGrid.DataBind();
            }
            catch (Exception ex)
            {
                Error.Text = "Something went terribly wrong! See below for more info. <br /> <br />" + ex.ToString();
            }
        }
    }
}