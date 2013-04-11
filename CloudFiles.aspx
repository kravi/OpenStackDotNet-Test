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
    <div class="row">
        <div class="span4">
            Username:
            <br />
            <asp:TextBox ID="CFUsernameText" runat="server"></asp:TextBox>
            <br />
            APIKey:
            <br />
            <asp:TextBox ID="CFApiKeyText" TextMode="Password" runat="server"></asp:TextBox>
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
            </div>
            <div>
                Use service net?:
                <br />
                <div style="width: 40px; float: left;">
                    <asp:CheckBox ID="SnetCheck" Text="true" value="DFW" runat="server" />
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <asp:Button ID="btnListContainers" runat="server" CssClass="btn-primary" OnClick="ListContainerInfo_Click" Text="List Container Info" />
            <br />
            <br />
            <asp:Button ID="TestList" runat="server" CssClass="btn-primary" OnClick="TestList_Click" Text="Test ServiceNet External To Rackspace" />
        </div>
        <div class="span4">
            Container To Upload To:
            <br />
            <asp:DropDownList ID="CFContainerDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="btnDeleteContainer" runat="server" CssClass="btn-primary" OnClick="DeleteContainer_Click" Text="Delete Container" />
            <br />
            <br />
            Container Contents:
            <br />
            <asp:DropDownList ID="CFContainerContentsDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="btnDeleteContainerObject" runat="server" CssClass="btn-primary" OnClick="DeleteContainerObject_Click" Text="Delete Object" />
        </div>
        <div class="span4">
            New Container Name:
            <br />
            <asp:TextBox ID="CFCreateContainerTxt" runat="server"></asp:TextBox>
            <asp:Button ID="btnCreateContainer" runat="server" CssClass="btn-primary" OnClick="CreateContainer_Click" Text="Create Container" />
            <br />
            <br />

            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnCloudFilesUpload" runat="server" CssClass="btn-primary" OnClick="CloudFilesUpload_Click" Text="Upload to Cloud Files" />
            <br />
            <br />
        </div>
    </div>
    <div class="row">
        <div class="span10">
            <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
        </div>
    </div>
    <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LblInfo" ForeColor="Red" runat="server"></asp:Label>
    <br />
</asp:Content>
