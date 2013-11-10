<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gradetest.aspx.cs" Inherits="JavaScriptSite.gradetest" MasterPageFile="~/MasterFiles/Master.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">

</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="body">
    <div style="text-align: center; margin: auto;">
        <asp:DropDownList runat="server" ID="ddlTests" OnSelectedIndexChanged="ddlTests_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
    </div>
</asp:Content>