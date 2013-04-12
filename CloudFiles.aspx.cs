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
        protected void CFProviderListContainers(string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            var CfContainers = CloudFilesProvider.ListContainers(null, null, null, dcregion, dcsnet);

            CFContainerDDL.DataSource = CfContainers;
            CFContainerDDL.DataTextField = "Name";
            CFContainerDDL.DataBind();
        }
        protected void CFProviderListContainerObjects(string cfcontainername, string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            var Cfobjects = CloudFilesProvider.ListObjects(cfcontainername, null, null, null, dcregion, dcsnet);

            CFContainerContentsDDL.DataSource = Cfobjects;
            CFContainerContentsDDL.DataTextField = "Name";
            CFContainerContentsDDL.DataBind();
        }
        protected void CFProvidersCreateContainer(string cfcreatecontainername, string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            var CfCreateContainer = CloudFilesProvider.CreateContainer(cfcreatecontainername, dcregion, dcsnet);
        }
        protected void CFProvidersDeleteContainer(string cfdeletecontainername, string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            var Cfdeletecontainer = CloudFilesProvider.DeleteContainer(cfdeletecontainername, dcregion, dcsnet);
        }
        protected void CFProvidersDeleteContainerObject(string cfcontainername, string cfdeletecontainerobject, string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            var Cfdeletecontainerobject = CloudFilesProvider.DeleteObject(cfcontainername, cfdeletecontainerobject, null, dcregion, dcsnet);
        }
        protected void CFProvidersCreateObjectFromFile(string cfcontainername, string cfcreateobjfilepath, string cfcreateobjfilename, int cfcreateobjchunksize, string dcregion, bool dcsnet = true)
        {
            var identity = new RackspaceCloudIdentity() { Username = CFUsernameText.Text, APIKey = CFApiKeyText.Text };

            CloudIdentityProvider identityProvider = new net.openstack.Providers.Rackspace.CloudIdentityProvider(identity);
            CloudFilesProvider CloudFilesProvider = new net.openstack.Providers.Rackspace.CloudFilesProvider(identity);

            CloudFilesProvider.CreateObjectFromFile(cfcontainername, cfcreateobjfilepath, cfcreateobjfilename, cfcreateobjchunksize, null, dcregion, null, dcsnet);
        }
        protected void ListContainerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                string fileName = HttpUtility.UrlPathEncode(FileUpload1.FileName);
                string path = Server.MapPath(HttpUtility.UrlPathEncode("~/temp"));
                string filePath = Path.Combine(path, fileName);

                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProviderListContainers("dfw", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProviderListContainers("dfw", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFContainerContentsDDL.Items.Clear();

                        CFProviderListContainers("dfw", snetTrue);

                        CFProviderListContainerObjects(containername, "dfw", snetTrue);
                    }
                    else
                    {
                        if (RegionDFW.Checked)
                        {
                            if (CFContainerContentsDDL.SelectedItem == null)
                            {
                                CFProviderListContainers("dfw", snetFalse);

                                CFProviderListContainerObjects(containername, "dfw", snetFalse);
                            }
                            else
                            {
                                CFProviderListContainers("dfw", snetFalse);
                            }
                        }
                        else
                        {
                            CFProviderListContainers("dfw", snetFalse);

                            CFProviderListContainerObjects(containername, "dfw", snetFalse);
                        }
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProviderListContainers("ord", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProviderListContainers("ord", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProviderListContainers("ord", snetTrue);

                        CFProviderListContainerObjects(containername, "ord", snetTrue);
                    }
                    else
                    {
                        if (RegionORD.Checked)
                        {
                            if (CFContainerContentsDDL.SelectedItem == null)
                            {
                                CFProviderListContainers("ord", snetFalse);

                                CFProviderListContainerObjects(containername, "ord", snetFalse);
                            }
                            else if (CFContainerContentsDDL.SelectedItem != null)
                            {
                                CFContainerContentsDDL.Items.Clear();

                                CFProviderListContainers("ord", snetFalse);

                                CFProviderListContainerObjects(containername, "ord", snetFalse);
                            }
                            else
                            {
                                CFProviderListContainers("ord", snetFalse);
                            }
                        }
                        else
                        {
                            CFProviderListContainers("ord", snetFalse);

                            CFProviderListContainerObjects(containername, "ord", snetFalse);
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
        protected void CreateContainer_Click(object sender, EventArgs e)
        {
            try
            {
                string containername = CFContainerDDL.Text;
                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "dfw", snetTrue);

                        CFProviderListContainers("dfw", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "dfw", snetFalse);

                        CFProviderListContainers("dfw", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "dfw", snetTrue);

                        CFProviderListContainers("dfw", snetTrue);
                    }
                    else
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "dfw", snetFalse);

                        CFProviderListContainers("dfw", snetFalse);
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "ord", snetTrue);

                        CFProviderListContainers("ord", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "ord", snetFalse);

                        CFProviderListContainers("ord", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "ord", snetTrue);

                        CFProviderListContainers("ord", snetTrue);
                    }
                    else
                    {
                        CFProvidersCreateContainer(CFCreateContainerTxt.Text, "ord", snetFalse);

                        CFProviderListContainers("ord", snetFalse);
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

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainer(containername, "dfw", snetTrue);

                        CFProviderListContainers("dfw", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersDeleteContainer(containername, "dfw", snetFalse);

                        CFProviderListContainers("dfw", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainer(containername, "dfw", snetTrue);

                        CFProviderListContainers("dfw", snetTrue);
                    }
                    else
                    {
                        CFProvidersDeleteContainer(containername, "dfw", snetFalse);

                        CFProviderListContainers("dfw", snetFalse);
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainer(containername, "ord", snetTrue);

                        CFProviderListContainers("ord", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersDeleteContainer(containername, "ord", snetFalse);

                        CFProviderListContainers("ord", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainer(containername, "ord", snetTrue);

                        CFProviderListContainers("ord", snetTrue);
                    }
                    else
                    {
                        CFProvidersDeleteContainer(containername, "ord", snetFalse);

                        CFProviderListContainers("ord", snetFalse);
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

                if (RegionDFW.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "dfw", snetTrue);
                        CFProviderListContainerObjects(containername, "dfw", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "dfw", snetFalse);

                        CFProviderListContainerObjects(containername, "dfw", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "dfw", snetTrue);

                        CFProviderListContainerObjects(containername, "dfw", snetTrue);
                    }
                    else
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "dfw", snetFalse);

                        CFProviderListContainerObjects(containername, "dfw", snetFalse);
                    }
                }
                else if (RegionORD.Checked)
                {
                    if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "ord", snetTrue);

                        CFProviderListContainerObjects(containername, "ord", snetTrue);
                    }
                    else if (CFContainerDDL.SelectedItem == null)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "ord", snetFalse);

                        CFProviderListContainerObjects(containername, "ord", snetFalse);
                    }
                    else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "ord", snetTrue);

                        CFProviderListContainerObjects(containername, "ord", snetTrue);
                    }
                    else
                    {
                        CFProvidersDeleteContainerObject(containername, CFContainerContentsDDL.SelectedValue, "ord", snetFalse);

                        CFProviderListContainerObjects(containername, "dfw", snetFalse);
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
                string containername = HttpUtility.UrlPathEncode(CFContainerDDL.Text);
                string fileName = HttpUtility.UrlPathEncode(FileUpload1.FileName);
                string path = Server.MapPath(HttpUtility.UrlPathEncode("~/temp"));
                string filePath = Path.Combine(path, fileName);

                bool snetTrue = bool.Parse(SnetCheck.Text);
                bool snetFalse = bool.Parse("false");

                if (FileUpload1.HasFile)
                {
                    //save the file to our local path
                    FileUpload1.SaveAs(Path.Combine(path, fileName));

                    if (RegionDFW.Checked)
                    {
                        if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetTrue);

                            CFProviderListContainerObjects(containername, "dfw", snetTrue);

                            File.Delete(filePath);
                        }
                        else if (CFContainerDDL.SelectedItem == null)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetFalse);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "dfw", snetFalse);
                        }
                        else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetTrue);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "dfw", snetTrue);
                        }
                        else
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetFalse);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "dfw", snetFalse);

                        }
                    }
                    else if (RegionORD.Checked)
                    {
                        if (CFContainerDDL.SelectedItem == null & SnetCheck.Checked)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetTrue);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "ord", snetTrue);
                        }
                        else if (CFContainerDDL.SelectedItem == null)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetFalse);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "ord", snetFalse);
                        }
                        else if (CFContainerDDL.SelectedItem != null & SnetCheck.Checked)
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetTrue);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "ord", snetTrue);
                        }
                        else
                        {
                            CFProvidersCreateObjectFromFile(containername, filePath, fileName, 4096, "dfw", snetFalse);

                            File.Delete(filePath);

                            CFProviderListContainerObjects(containername, "ord", snetFalse);
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