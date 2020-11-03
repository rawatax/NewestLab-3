<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Lab3.Events" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Events</h1>
    <br />
    <form>
        <h3>Register a Volunteer</h3>
        <br />
        <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
        <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        <br />
        <br />
        <label>Volunteer</label>
        <asp:DropDownList ID="vDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Selected_volunteer"></asp:DropDownList>
        <label>Event</label>
        <asp:DropDownList ID="eDropDown" runat="server" AutoPostBack="false"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="REGISTER" />
        <br />
        <br />
        <asp:Label ID="contactLabel" runat="server"></asp:Label>
        <asp:GridView ID="contactTable" runat="server"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="cEventLabel" runat="server"></asp:Label>
        <asp:GridView ID="cEventTable" runat="server"></asp:GridView>
    </form>
    <div>
        <h3>Register a Coordinator</h3>
        <br />
        <asp:Label ID="ErrorLabel2" runat="server"></asp:Label>
        <asp:Label ID="SuccessLabel2" runat="server"></asp:Label>
        <br />
        <br />
        <label>Coordinator</label>
        <asp:DropDownList ID="cDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Selected_coordinator"></asp:DropDownList>
        <label>Event</label>
        <asp:DropDownList ID="eDropDown2" runat="server" AutoPostBack="false"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnRegister2" OnClick="btnRegister2_Click" runat="server" Text="REGISTER" />
        <br />
        <br />
        <asp:Label ID="contactLabel2" runat="server"></asp:Label>
        <asp:GridView ID="contactTable2" runat="server"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="cEventLabel2" runat="server"></asp:Label>
        <asp:GridView ID="cEventTable2" runat="server"></asp:GridView>
    </div>
</asp:Content>
