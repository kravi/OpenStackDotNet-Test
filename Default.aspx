<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenStackDotNet_Test.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Rackspace/Openstack Upload Test
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProjectName" runat="server">
    Rackspace/Openstack Upload Test
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Instructions:</h1>
    <p>
        This is a Web Forms example of how to use both the orgianl<br />
        Rackspace OpenSwift V3 bindings as well as the new Openstack<br />
        V1 bindings.<br />
        <br />

        When uploading a file it's temporarily stored in the temp directory so<br />
        be sure to add your impersonation to your web.config so the file system
                <br />
        can upload the file.
                <br />
        <br />

        Click one of the urls above to view how this demo works or open up<br />
        Visual studio or a text editor of your choice and start review the code.
                <br />
        I hope my example helps!
                <br />
        <br />
    </p>
    <br />
</asp:Content>
