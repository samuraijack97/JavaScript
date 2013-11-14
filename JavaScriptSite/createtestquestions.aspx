<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createtestquestions.aspx.cs" Inherits="JavaScriptSite.createtestquestions" MasterPageFile="~/MasterFiles/Master.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="body">
    <p>
        <asp:DropDownList runat="server" ID="ddlQuestionType">
            <asp:ListItem Text="Please select an option" />
            <asp:ListItem Text="Multiple Choice" Value="Multiple Choice" />
            <asp:ListItem Text="True/False" Value="True/False" />
            <asp:ListItem Text="Short Answer" Value="Short Answer" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ErrorMessage="Please select a value" ControlToValidate="ddlQuestionType" runat="server"
            ForeColor="Red" Display="Dynamic" />
    </p>
    <p>Question:
        <asp:TextBox runat="server" ID="txtQuestion" /></p>
    <asp:Panel runat="server">
        <%-- Short answer and multiple choice answers --%>
        <asp:Panel runat="server">
            <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer" /></p>
            <%-- Multiple choice answers --%>
            <asp:Panel runat="server">
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox1" /></p>
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox2" /></p>
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox3" /></p>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server">
            <asp:RadioButtonList runat="server">
                <asp:ListItem Text="True" Value="True" />
                <asp:ListItem Text="False" Value="False" />
            </asp:RadioButtonList>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
