﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="CartCreatePage.aspx.cs" Inherits="WebFormsClient.CartCreatePage" %>


<asp:Content ID="GroupCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input name</label>
                <asp:TextBox ID="groupName" runat="server" Text=""></asp:TextBox><br />
                <label>Input max capasity</label>
                <asp:TextBox ID="groupMaxStudents" runat="server" Text=""></asp:TextBox><br />
                <label>Input smt its train id</label>
                <asp:TextBox ID="groupStudyYear" runat="server" Text=""></asp:TextBox><br />
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>