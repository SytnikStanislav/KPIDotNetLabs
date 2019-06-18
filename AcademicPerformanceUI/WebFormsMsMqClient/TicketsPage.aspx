<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketsPage.aspx.cs" Inherits="WebFormsClient.TicketsPage" MasterPageFile="~/Site.Master"%>
<%@ Import Namespace="DataAccess.Models" %>

<asp:Content ID="SubjectsPage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Tickets list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater ID="Repeater" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h6>ArrivalDate: <%#Eval("ArrivalDate") %></h6>
                    <h6>ArrivalStation:  <%#Eval("ArrivalStation") %></h6>
                    <h6>DepartureTime: <%#Eval("DepartureTime") %></h6>
                    <h6>DepartureStation:  <%#Eval("DepartureStation") %></h6>
                    <h6>PassangerId: <%#Eval("PassangerId") %></h6>
                    <h6>CartId:  <%#Eval("CartId") %></h6>
                </div>
                <asp:Button ID="test" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Delete"></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>