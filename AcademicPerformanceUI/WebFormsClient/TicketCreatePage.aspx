<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TicketCreatePage.aspx.cs" Inherits="TicketCreatePage" %>

<asp:Content ID="SubjectCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input arrival station</label>
                <asp:TextBox ID="arrivalStation" runat="server" Text=""></asp:TextBox><br />
                <label>Input departure station</label>
                <asp:TextBox ID="departureStation" runat="server" Text=""></asp:TextBox><br />
                <label>Input arrival date</label>
                <asp:TextBox ID="arrivalDate" runat="server" Text=""></asp:TextBox><br />
                <label>Input departure time</label>
                <asp:TextBox ID="departureDate" runat="server" Text=""></asp:TextBox><br />
                            
                <label>Input cart id</label>
                <asp:DropDownList ID="dropdownCart" runat="server" ></asp:DropDownList><br />

                <label>Input passanger id</label>
                <asp:DropDownList ID="dropdownPassanger" runat="server" ></asp:DropDownList><br />
    
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>