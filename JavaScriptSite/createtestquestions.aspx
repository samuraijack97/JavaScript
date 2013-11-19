<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createtestquestions.aspx.cs" Inherits="JavaScriptSite.createtestquestions" MasterPageFile="~/MasterFiles/Master.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="body">
    <div>
        <asp:Literal Text="" runat="server" ID="litMessage" />
    </div>
    <p>
        <asp:DropDownList runat="server" ID="ddlQuestionType" OnSelectedIndexChanged="ddlQuestionType_SelectedIndexChanged" AutoPostBack="true">
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
    <asp:Panel runat="server" ID="pnlQuestionAnswers" Visible="false">
        <%-- Short answer and multiple choice answers --%>
        <asp:Panel runat="server" ID="pnlShortAnswerAnswer">
            <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer" /></p>
            <%-- Multiple choice answers --%>
            <asp:Panel runat="server" ID="pnlMulti">
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer1" /></p>
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer2" /></p>
                <p>Answer:
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer3" /></p>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlTrueFalse">
            <asp:RadioButtonList runat="server" ID="rdlTrueFalse">
                <asp:ListItem Text="True" Value="True" Selected="True" />
                <asp:ListItem Text="False" Value="False" />
            </asp:RadioButtonList>
        </asp:Panel>
        <asp:Button Text="Submit Question and Answer" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
    </asp:Panel>
</asp:Content>
