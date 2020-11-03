<%@ Page Language="C#" Title="Edit Student" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Lab3.EditStudent" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Student</h1>
    <br />
    <form>
        <asp:Label ID="Errorlabel" runat="server"></asp:Label>
        <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        <br />
        <br />
        <label>First Name</label>
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="FirstName" Display="Static" ErrorMessage="First Name is required." ID="validateFirstName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Last Name</label>
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="LastName" Display="Static" ErrorMessage="Last Name is required." ID="validateLastName" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Age</label>
        <asp:TextBox ID="Age" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Age" Display="Static" ErrorMessage="Age is required." ID="validateAge" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Notes</label>
        <asp:TextBox ID="Notes" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="Notes" ErrorMessage="Notes are required." ID="validateNotes" runat="Server" ForeColor="Red" />
        <br />
        <br />
        <label>Shirt Size</label>
        <asp:DropDownList ID="dropShirtSize" runat="server">
            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
            <asp:ListItem Value="1" Text="Small"></asp:ListItem>
            <asp:ListItem Value="2" Text="Medium"></asp:ListItem>
            <asp:ListItem Value="3" Text="Large"></asp:ListItem>
            <asp:ListItem Value="4" Text="Extra Large"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <label>Shirt Color</label>
        <asp:DropDownList ID="dropShirtColor" runat="server">
            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
            <asp:ListItem Value="1" Text="Green"></asp:ListItem>
            <asp:ListItem Value="2" Text="Yellow"></asp:ListItem>
            <asp:ListItem Value="3" Text="Blue"></asp:ListItem>
            <asp:ListItem Value="4" Text="Black"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <label>Teacher</label>
        <asp:DropDownList ID="teacherDropDown" runat="server" DataTextField="Event" DataValueField="TeacherID" AutoPostBack="true"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="SAVE" />
        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="CANCEL" />
    </form>
</asp:Content>
