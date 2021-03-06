﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CloudServers.aspx.cs" Inherits="OpenStackDotNet_Test.CloudServers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Openstack.NET Cloud Servers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ProjectName" runat="server">
    Openstack.NET Cloud Servers
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
    <br />
    List of live Cloud Servers:
    <br />
    <asp:DropDownList ID="CSListDDL" runat="server"></asp:DropDownList>
    <br />
    <br />
    List of available Images:
    <br />
    <asp:DropDownList ID="CSImageListDDL" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:TextBox ID="CSName" runat="server"></asp:TextBox>
    <br />
    <br />
    List of available Flavors:
    <br />
    <asp:DropDownList ID="CSFlavorsDDL" runat="server"></asp:DropDownList>
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
    <asp:Button ID="btnOneClick" runat="server" CssClass="btn-primary" OnClick="OneClick_Click" Text="Load Cloud Server Info" />
    <br />
    <br />
    <asp:Button ID="btnListCloudServerIpAddresses" runat="server" CssClass="btn-primary" OnClick="ListCloudServerIpAddresses_Click" Text="List All Ip Addresses" />
    <asp:Button ID="btnRebootCloudServer" runat="server" CssClass="btn-primary" OnClick="RebootServer_Click" Text="Reboot Cloud Server" />
    <br />
    <br />
    <asp:Button ID="btnCreateCloudServer" runat="server" CssClass="btn-primary" OnClick="CreateServer_Click" Text="Create Cloud Server" />
    <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
    <br />
    <br />
    <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
    <br />
    <asp:Label ID="LblInfo" ForeColor="Red" runat="server"></asp:Label>
    <br />
</asp:Content>
