<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RackspaceDotNetV3.aspx.cs" Inherits="OpenStackDotNet_Test.RackspaceDotNetV3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    CloudFiles 3.0 Upload Test - OpenSwift Version
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProjectName" runat="server">
    CloudFiles 3.0 Upload Test - OpenSwift Version
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
    <asp:Button ID="ListContentsBtn" runat="server" CssClass="btn-primary" OnClick="ListContainerContents_Click" Text="List Contents" />
    <br />
    <br />
    <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
    <br />
    <div>
        ServiceNet:
                <br />
        <div style="width: 40px; float: left;">
            <asp:CheckBox ID="SnetTrue" Text="True" value="True" runat="server" />
        </div>
        <div style="width: 40px; float: left;">
            <br />
            Or
        </div>
        <div style="width: 40px; float: left;">
            <asp:CheckBox ID="SnetFalse" Text="False" value="False" runat="server" />
        </div>
        <div style="clear: both;">
        </div>
        <br />
        <br />
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" CssClass="btn-primary" Text="Upload" OnClick="btnUpload_Click"
        OnClientClick="return CallJS('Demo()');" />
    <br />
    <br />
    <br />
    <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
    <br />
</asp:Content>
