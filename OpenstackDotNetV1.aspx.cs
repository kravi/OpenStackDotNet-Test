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
        protected void ListContainers_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var Cfobjects = CloudFilesProvider.ListContainers(null, null, null, "json", "dfw", identity);

                    CFContainerDDL.DataSource = Cfobjects;
                    CFContainerDDL.DataTextField = "Name";
                    CFContainerDDL.DataBind();
                }
                else if (RegionORD.Checked)
                {
                    var Cfobjects = CloudFilesProvider.ListContainers(null, null, null, "json", "ord", identity);

                    CFContainerDDL.DataSource = Cfobjects;
                    CFContainerDDL.DataTextField = "Name";
                    CFContainerDDL.DataBind();
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
        protected void ListContainerContents_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "dfw", identity);

                    CFContainerContentsDDL.DataSource = Cfobjects;
                    CFContainerContentsDDL.DataTextField = "Name";
                    CFContainerContentsDDL.DataBind();
                }
                else if (RegionORD.Checked)
                {
                    var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "ord", identity);

                    CFContainerContentsDDL.DataSource = Cfobjects;
                    CFContainerContentsDDL.DataTextField = "Name";
                    CFContainerContentsDDL.DataBind();
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
        protected void DeleteContainerObject_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    var Cfdelete = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "dfw", identity);
                    var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "dfw", identity);

                    CFContainerContentsDDL.DataSource = Cfobjects;
                    CFContainerContentsDDL.DataTextField = "Name";
                    CFContainerContentsDDL.DataBind();
                }
                else if (RegionORD.Checked)
                {
                    var Cfdelete = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "ord", identity);
                    var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "ord", identity);

                    CFContainerContentsDDL.DataSource = Cfobjects;
                    CFContainerContentsDDL.DataTextField = "Name";
                    CFContainerContentsDDL.DataBind();
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
        protected void CloudFilesUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (FileUpload1.HasFile)
                {
                    //create the path to save the file to
                    string fileName = FileUpload1.FileName;
                    string path = Server.MapPath("~/temp");
                    string filePath = Path.Combine(path, fileName);

                    //save the file to our local path
                    FileUpload1.SaveAs(Path.Combine(path, fileName));

                    if (RegionDFW.Checked)
                    {
                        CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "dfw", null, identity);
                        var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "dfw", identity);
                        File.Delete(filePath);

                        CFResultsGrid.DataSource = Cfobjects;
                        CFResultsGrid.DataBind();

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else if (RegionDFW.Checked)
                    {
                        CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "ord", null, identity);
                        var Cfobjects = CloudFilesProvider.GetObjects(containername, null, null, null, "json", "ord", identity);
                        File.Delete(filePath);

                        CFResultsGrid.DataSource = Cfobjects;
                        CFResultsGrid.DataBind();

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else
                    {
                        LblInfo.Text = "Please select DFW or ORD not both.";
                    }

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