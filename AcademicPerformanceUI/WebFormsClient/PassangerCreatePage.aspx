<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassangerCreatePage.aspx.cs" Inherits="PassangerCreatePage"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="SubjectInroupCreatePage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label" runat="server" Text=""></asp:Label>
    </div>
    <label>Input firstname</label>
    <asp:TextBox ID="firstname" runat="server" Text=""></asp:TextBox><br />
    <label>Input lastname</label>
    <asp:TextBox ID="lastname" runat="server" Text=""></asp:TextBox><br />


    <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>
