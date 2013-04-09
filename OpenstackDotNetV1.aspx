<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenstackDotNetV1.aspx.cs" Inherits="OpenStackDotNet_Test.OpenstackDotNetV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Openstack .NET V1 Bindings Test
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProjectName" runat="server">
    Openstack .NET V1 Bindings Test
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Instructions:</h1>
    <p>
        Please enter your Username, APIKey, and Container to upload to.<br>
        Once you have successfully entered this information please be sure<br />
        to select true of false for service net and then click upload.<br />
        <br />

        When uploading a file it's temporarily stored in the temp directory so<br />
        be sure to add your impersonation to your web.config so the file system
                <br />
        can upload the file.
                <br />
        <br />
    </p>
    <br />
    Username:
            <br />
    <asp:TextBox ID="CFUsernameText" runat="server"></asp:TextBox>
    <br />
    APIKey:
            <br />
    <asp:TextBox ID="CFApiKeyText" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    Container To Upload To:
            <br />
    <asp:TextBox ID="CFContainerText" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" CssClass="btn-primary" OnClick="ListContainerContents_Click" Text="List Container Contents" />
    <br />
    <br />
    <asp:Button ID="ListContentsBtn" runat="server" CssClass="btn-primary" OnClick="ListAvailableServers_Click" Text="List Available Servers" />
    <br />
    <br />
    <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="btn-primary" OnClick="CloudFilesUpload_Click" Text="Upload to Cloud Files" />
    <br />
    <br />
    <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
    <br />
</asp:Content>
