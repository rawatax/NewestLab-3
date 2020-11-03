<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="Lab3.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <h1>FUN FIELD DAY PROGRAM</h1>
    </div>
    <asp:Label ID="welcomeLabel" runat="server"></asp:Label>
    <br /> <br />
    <label>Students</label>
    <asp:DropDownList ID="studentDropDown" runat="server" DataTextField="Event" DataValueField="StudentID" AutoPostBack="true" OnSelectedIndexChanged="Selected_student"></asp:DropDownList>
    <asp:GridView ID="studentEventsTable" runat="server"></asp:GridView>
    <asp:Label ID="Teacherlabel" runat="server"></asp:Label>
    <hr />
    <label>Events</label>
    <asp:DropDownList ID="eventDropDown" runat="server" DataTextField="Event" DataValueField="EventID" AutoPostBack="true" OnSelectedIndexChanged="Selected_event"></asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Label ID="StudentEvents" runat="server"></asp:Label>
    <asp:GridView ID="eventTable" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    <asp:Label ID="cEvents" runat="server"></asp:Label>
    <asp:GridView ID="cEventTable" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    <asp:Label ID="vEvents" runat="server"></asp:Label>
    <asp:GridView ID="vEventTable" runat="server"></asp:GridView>
</asp:Content>
