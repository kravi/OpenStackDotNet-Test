<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CloudFiles.aspx.cs" Inherits="OpenStackDotNet_Test.CloudFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Openstack.NET Cloud Files
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProjectName" runat="server">
    Openstack.NET Cloud Files
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Instructions:</h1>
    <p>
        Please enter your Username, APIKey, and Container to upload to.<br />
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
    <asp:DropDownList ID="CFContainerDDL" runat="server"></asp:DropDownList>
    <br />
    <br />
    Container Contents:
    <br />
    <asp:DropDownList ID="CFContainerContentsDDL" runat="server"></asp:DropDownList>
    <br />
    <br />
    <div>
        Please Select Region:
                <br />
        <div style="width: 40px; float: left;">
            <asp:CheckBox ID="RegionDFW" Text="DFW" value="DFW" runat="server" />
        </div>
        <div style="width: 40px; float: left;">
            <br />
            Or
        </div>
        <div style="width: 40px; float: left;">
            <asp:CheckBox ID="RegionORD" Text="ORD" value="ORD" runat="server" />
        </div>
        <div style="clear: both;">
        </div>
        <br />
        <br />
    </div>
    <asp:Button ID="btnListContainers" runat="server" CssClass="btn-primary" OnClick="ListContainers_Click" Text="List Containers" />
    <asp:Button ID="btnListContainerContents" runat="server" CssClass="btn-primary" OnClick="ListContainerContents_Click" Text="List Container Contents" />
    <asp:Button ID="btnDeleteContainerObject" runat="server" CssClass="btn-primary" OnClick="DeleteContainerObject_Click" Text="Delete Object" />
    <br />
    <br />
    <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnCloudFilesUpload" runat="server" CssClass="btn-primary" OnClick="CloudFilesUpload_Click" Text="Upload to Cloud Files" />
    <br />
    <br />
    <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LblInfo" ForeColor="Red" runat="server"></asp:Label>
    <br />
</asp:Content>
