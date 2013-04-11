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
    public partial class CloudFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListContainerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();

                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else
                    {
                        if (RegionDFW.Checked)
                        {
                            var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                            CFContainerDDL.DataSource = CfContainers;
                            CFContainerDDL.DataTextField = "Name";
                            CFContainerDDL.DataBind();
                        }
                        else
                        {
                            var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                            CFContainerDDL.DataSource = CfContainers;
                            CFContainerDDL.DataTextField = "Name";
                            CFContainerDDL.DataBind();

                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetFalse, identity);

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();

                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else
                    {
                        if (RegionORD.Checked)
                        {
                            var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                            CFContainerDDL.DataSource = CfContainers;
                            CFContainerDDL.DataTextField = "Name";
                            CFContainerDDL.DataBind();

                        }
                        else
                        {
                            var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                            CFContainerDDL.DataSource = CfContainers;
                            CFContainerDDL.DataTextField = "Name";
                            CFContainerDDL.DataBind();

                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetFalse, identity);

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                    }
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
        protected void TestList_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();

                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();

                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
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
        protected void CreateContainer_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "dfw", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "dfw", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "dfw", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "dfw", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "ord", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "ord", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "ord", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var CfCreateContainer = CloudFilesProvider.CreateContainer(CFCreateContainerTxt.Text, "ord", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
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
        protected void DeleteContainer_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "dfw", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "dfw", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "dfw", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "dfw", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "dfw", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "ord", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "ord", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "ord", snetTrue, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetTrue, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
                    else
                    {
                        var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(containername, "ord", snetFalse, identity);

                        var CfContainers = CloudFilesProvider.ListContainers(null, null, null, "ord", snetFalse, identity);

                        CFContainerDDL.DataSource = CfContainers;
                        CFContainerDDL.DataTextField = "Name";
                        CFContainerDDL.DataBind();
                    }
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
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider();
                CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider();

                var identity = new RackspaceCloudIdentity { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "dfw", snetTrue, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "dfw", snetFalse, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetFalse, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "dfw", snetTrue, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "dfw", snetFalse, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetFalse, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "ord", snetTrue, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "ord", snetFalse, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetFalse, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "ord", snetTrue, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
                    else
                    {
                        var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(containername, CFContainerContentsDDL.SelectedValue, null, "ord", snetFalse, identity);
                        var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetFalse, identity);

                        CFContainerContentsDDL.DataSource = Cfobjects;
                        CFContainerContentsDDL.DataTextField = "Name";
                        CFContainerContentsDDL.DataBind();
                    }
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
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

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
                        if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "dfw", null, snetTrue, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else if (CFContainerDDL.SelectedItem == null)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "dfw", null, snetFalse, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetFalse, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "dfw", null, snetTrue, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetTrue, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "dfw", null, snetFalse, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "dfw", snetFalse, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                    }
                    else if (RegionORD.Checked)
                    {
                        if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "ord", null, snetTrue, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else if (CFContainerDDL.SelectedItem == null)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "ord", null, snetFalse, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetFalse, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "ord", null, snetTrue, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetTrue, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
                        else
                        {
                            CloudFilesProvider.CreateObjectFromFile(containername, filePath, fileName, 4096, null, "ord", null, snetFalse, identity);
                            var Cfobjects = CloudFilesProvider.ListObjects(containername, null, null, null, "ord", snetFalse, identity);
                            File.Delete(filePath);

                            CFResultsGrid.DataSource = Cfobjects;
                            CFResultsGrid.DataBind();

                            CFContainerContentsDDL.DataSource = Cfobjects;
                            CFContainerContentsDDL.DataTextField = "Name";
                            CFContainerContentsDDL.DataBind();
                        }
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
    }
}